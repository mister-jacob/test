using System.Linq.Expressions;

namespace TestBack.BL.Extensions
{
    public static class ExtensionString
    {
        public static ExpressionType GetExpressionType(this string value)
        {
            switch (value)
            {
                case "equal":
                    return ExpressionType.Equal;
                case "moreThan":
                    return ExpressionType.GreaterThan;
                case "lessThan":
                    return ExpressionType.LessThan;
                default:
                    return ExpressionType.Default;
            }
        }
    }
}
