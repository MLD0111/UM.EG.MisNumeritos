using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace EG.MisNumeritos.Source
{
    [DataContract]
    public class ScoreContract
    {
        [JsonProperty("score")]
        [DataMember(Name = "score")]
        public List<Score> Scores { get; set; }
    }
}
