using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.Rules
{
    public class ConditionModel
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("condition")]
        public string Condition { get; set; }

        [JsonProperty("val")]
        public object Val { get; set; }
    }
}
