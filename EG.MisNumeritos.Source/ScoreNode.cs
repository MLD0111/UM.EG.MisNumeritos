﻿namespace EG.MisNumeritos.Source
{
    public class ScoreNode
    {
        private string key;
        private Score score;

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

        public Score GetScore()
        {
            return score;
        }

        public void SetScore(Score score)
        {
            this.score = score;
        }

        public override string ToString()
        {
            string response = "En " + score.GetAttempts();
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