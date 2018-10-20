using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EG.MisNumeritos.Source
{
    public class ScoreNode
    {
        private string key;
        private Score score;

        public ScoreNode() { }

        public ScoreNode(string key, Score score)
        {
            this.key = key;
            this.score = score;
        }

        public string GetKey()
        {
            return key;
        }

        public void SetKey(string key)
        {
            this.key = key;
        }

        public Score getScore()
        {
            return score;
        }

        public void SetScore(Score score)
        {
            this.score = score;
        }

        public override string ToString()
        {
            String response = "En " + score.GetAttempts();
            if (score.GetAttempts() == 1)
                response += " intento!!! :D";
            else if (score.GetAttempts() <= 4)
                response += " intentos! :)";
            else if (score.GetAttempts() <= 10)
                response += " intentos :|";
            else
                response += " intentos :(";
            response += "   " + score.GetUser();
            return response;
        }
    }
}