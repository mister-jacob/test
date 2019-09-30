using System;
using System.Collections.Generic;
using System.Linq;
using TestBack.Models.Rules;
using TestBack.Models;
using TestBack.BL.Services.Abstraction;
using Microsoft.Extensions.Options;

namespace TestBack.BL.Services.Concrete.Rules
{
    internal class RuleJson : IRuleService
    {
        private List<RuleModel> rules;
        private readonly IConditionService<ConditionModel> _conditionService;

        public RuleJson(IConditionService<ConditionModel> conditionService, IOptionsMonitor<List<RuleModel>> rulesAccessor)
        {
            _conditionService = conditionService ?? throw new ArgumentNullException(nameof(conditionService));
            rules = rulesAccessor.CurrentValue;
        }

        public IEnumerable<DataModel> GetValidRules(IEnumerable<DataModel> data)
        {
            List<DataModel> validModels = new List<DataModel>();

            foreach (var item in data)
            {
                if (_conditionService.Build(item, rules.First().Conditions).All(x => x == true && rules.First().AndOperator))
                    validModels.Add(item);
            }

            return validModels;
        }

        public IEnumerable<EffectModel> GetEffects() => rules.First().Effects;
    }
}
