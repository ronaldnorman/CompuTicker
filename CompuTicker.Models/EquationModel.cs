using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompuTicker.Models
{
    public class EquationModel
    {
        [JsonProperty("parm1")]
        public double Param1 { get; set; }

        [JsonProperty("parm2")]
        public double Param2 { get; set; }

        [JsonProperty("op")]
        public string Operation { get; set; }
    }
}
