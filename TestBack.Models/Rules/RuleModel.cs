using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.Rules
{
    public class RuleModel
    {
        public bool AndOperator => Operator == "and";

        public bool OrOperator => Operator == "or";

        [JsonProperty("operator")]
        public string Operator { get; set; }

        [JsonProperty("conditions")]
        public List<ConditionModel> Conditions { get; set; } = new List<ConditionModel>();

        [JsonProperty("effects")]
        public List<EffectModel> Effects { get; set; } = new List<EffectModel>();
    }
}
