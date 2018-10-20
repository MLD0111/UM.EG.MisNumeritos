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
    public class Score
    {
        private string user;
        private int attempts;

        public Score() { }

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