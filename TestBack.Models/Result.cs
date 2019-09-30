using System;
using System.Collections.Generic;
using System.Text;

namespace TestBack.Models
{
    public class Result
    {
        public int ProjectId { get; set; } 

        public bool Success { get; set; }

        public List<string> Errors { get; set; }

        public object Data { get; set; }
    }
}
