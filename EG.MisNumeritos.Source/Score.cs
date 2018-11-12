using System;
using System.Collections;
using SQLite;

namespace EG.MisNumeritos.Source
{
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
            Date = DateTime.Today;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string User { get; set; }

        public int Attempts { get; set; }

        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("Intentos: {0} - {1}", Attempts.ToString("D2"), User);
        }
    }
}