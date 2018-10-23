using System;
using System.Collections;
using EG.MisNumeritos.Interfaces;

namespace EG.MisNumeritos.Source
{
    public class Score : IGuardable
    {
        private string user;
        private int attempts;

        public Score() { }

        public Score(string user, int attempts)
        { 
            this.user = user;
            this.attempts = attempts;
        }

        public void armar(ArrayList atributos)
        {
            // atributos[0] = id
            user = atributos[1].ToString();
            attempts = int.Parse(atributos[2].ToString());
        }

        public string User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }

        public int Attemps
        {
            get
            {
                return attempts;
            }
            set
            {
                attempts = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Intentos: {0} - {1}", Attemps.ToString("D2"), User);
        }
    }
}