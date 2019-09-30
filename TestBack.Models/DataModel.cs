﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models
{
    public class DataModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("stage")]
        public string Stage { get; set; }

        [JsonProperty("categories")]
        public List<int> Categories { get; set; }

        [JsonProperty("created_at")]
        public long Created_At { get; set; }

        [JsonProperty("modified_at")]
        public long Modified_At { get; set; }
    }
}
