using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models.Rules
{
    public class EffectModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("template_id")]
        public int Template_Id { get; set; }

        [JsonProperty("placeholders")]
        public Placeholder Placeholders { get; set; }
    }
}
