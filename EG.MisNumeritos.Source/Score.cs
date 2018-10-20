namespace EG.MisNumeritos.Source
{
    public class Score
    {
        private string user;
        private int attempts;

        public Score(string user, int attempts)
        { 
            this.user = user;
            this.attempts = attempts;
        }

        public string GetUser()
        {
            return user;
        }
        public void SetUser(string user)
        {
            this.user = user;
        }

        public int GetAttempts()
        {
            return attempts;
        }
        public void SetAttempts(int _attempts)
        {
            this.attempts = _attempts;
        }
    }
}