using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using TestBack.BL.Extensions;
using TestBack.BL.Services.Abstraction;
using TestBack.Models.Rules;

namespace TestBack.BL.Services.Concrete
{
    internal class ConditionService : IConditionService<ConditionModel>
    {
        public List<bool> Build<T>(T item, List<ConditionModel> conditions)
        {
            var resultRules = new List<bool>();

            conditions.ForEach(rule =>
            {
                ParameterExpression genericType = Expression.Parameter(typeof(T));
                Type type = GetType<T>(genericType, rule.Key);

                if (!type.IsGenericType)
                {
                    Expression left = Expression.Property(genericType, rule.Key);
                    Expression right = Expression.Constant(Convert.ChangeType(rule.Val, type));
                    resultRules.Add(GenerateExpression<T>(rule.Condition.ToString().GetExpressionType(), left, right, genericType)(item));
                }

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                    resultRules.Add(GenerateExpressionContains<T>(rule, type)(item));
            });

            return resultRules;
        }



        private Func<T, bool> GenerateExpression<T>(ExpressionType type, Expression left, Expression right, ParameterExpression genericType)
        {
            var binaryExpression = Expression.MakeBinary(type, left, right);
            return Expression.Lambda<Func<T, bool>>(binaryExpression, genericType).Compile();
        }

        private Type GetType<T>(ParameterExpression genericType, string key)
        {
            return typeof(T).GetProperty(key, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase).PropertyType;
        }

        private Func<T, bool> GenerateExpressionContains<T>(ConditionModel rule, Type propertyType)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, rule.Key);
            var listType = propertyType.GenericTypeArguments[0];
            MethodInfo method = propertyType.GetMethod("Contains", new[] { listType });
            var someValue = Expression.Constant(Convert.ChangeType(rule.Val, listType));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp).Compile();
        }
    }
}
