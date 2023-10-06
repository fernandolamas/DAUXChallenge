using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DauxChallengeCommon.Models
{
    public class EncryptServiceResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; } = null!;
    }
}
