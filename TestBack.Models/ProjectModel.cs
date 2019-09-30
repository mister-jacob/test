using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models
{
    public class ProjectModel
    {
        [JsonProperty("projects")]
        public IEnumerable<DataModel> Projects { get; set; }
    }
}
