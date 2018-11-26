using System;
using System.Runtime.Serialization;
using SQLite;
using Newtonsoft.Json;

namespace EG.MisNumeritos.Source
{
    [JsonObject("score", MemberSerialization = MemberSerialization.OptIn)]
    [DataContract(Name = "score")]
    public class Score
    {
        public Score ()
        {
            // Parameterless constructor to allow simple querying with SQLite
        }

        public Score(string user, int attempts)
        {
            this.User = user;
            this.Attempts = attempts;
            Date = DateTime.UtcNow.Date;
        }

        [JsonProperty("id")]
        [DataMember(Name = "id")]
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [DataMember(Name = "name")]
        public string User { get; set; }

        [JsonProperty("attempts")]
        [DataMember(Name = "attempts")]
        public int Attempts { get; set; }

        [JsonProperty("date")]
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("Intentos: {0} - {1}", Attempts.ToString("D2"), User);
        }
    }
}