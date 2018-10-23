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
using EG.MisNumeritos.DAO;
using EG.MisNumeritos.Source;

namespace EG.MisNumeritos
{
    [Activity(Label = "FinishedGameActivity")]
    public class FinishedGameActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_finished_game);

            Bundle extras = this.Intent.Extras;

            tvTitle = (TextView)FindViewById(Resource.Id.tvAFG_title);
            tvMessage = (TextView)FindViewById(Resource.Id.tvAFG_message);
            tvNumber = (TextView)FindViewById(Resource.Id.tvAFG_number);
            tvAttempts = (TextView)FindViewById(Resource.Id.tvAFG_attempts);
            tvTopTen = (TextView)FindViewById(Resource.Id.tvAFG_topten);

            if (extras != null)
            {
                numberToGuess = extras.GetString("NumberToGuess");
                username = extras.GetString("Username");
                attempts = extras.GetInt("Attempts");
                isGameWon = extras.GetBoolean("IsGameWon");
            }

            if (isGameWon)
            {
                // TODO Replace this section for the checking and adding to TopTen
                //string key = "ToDo";
                //ScoreNode scoreNode = new ScoreNode(key, new Score(username, attempts));

                //Toast.MakeText(this, scoreNode.GetScore().User + "-" + scoreNode.GetScore().Attemps, ToastLength.Short).Show();
            }
        }

        List<Score> topTenList = new List<Score>();
        private string numberToGuess;
        private string username;
        private int attempts;
        private bool isGameWon;
        private TextView tvTitle;
        private TextView tvMessage;
        private TextView tvNumber;
        private TextView tvAttempts;
        private TextView tvTopTen;

        protected override void OnStart()
        {
            base.OnStart();

            LoadUIMessages();
            LoadTopTen();
        }

        private void LoadTopTen()
        {
            // Get top ten from database
            topTenList = ScoreDAO.RecuperarTopTen();
            string showText = string.Empty;
            int i = 0;
            /*
            topTenList = new List<Score>();
            topTenList.Add(new Score { Attemps = 12, User = "Usuario anonimo" });
            topTenList.Add(new Score { Attemps = 10, User = "Usuario anonimo" });
            topTenList.Add(new Score { Attemps = 8, User = "Usuario anonimo" });
            */
            foreach (var item in topTenList.OrderBy(x => x.Attemps))
            {
                i++;
                //showText = showText + i + ". " + item.User + " Attempts: " + item.Attemps + "\n";
                showText = showText + item.ToString() + "\n";
            }

            // TODO put the top ten in the activity
            tvTopTen.Text = showText;
        }

        public void LoadUIMessages()
        {
            string title;
            string message;

            if (isGameWon)
            {
                title = "GANASTE!";
                if (attempts == 1)
                {
                    title = "GENIO/A!!!";
                    message = "En un solo intento!";
                }
                else if (attempts <= 4)
                {
                    message = "Adivinaste el número";
                }
                else if (attempts <= 10)
                {
                    message = "Probá hacerlo en menos intentos";
                }
                else
                {
                    message = "Pero son muchos intentos...";
                }
            }
            else
            {
                title = "Pecho frío!";
                message = "No te animaste a adivinarlo...";
            }

            tvTitle.Text = title;
            tvMessage.Text = message;
            tvAttempts.Text = attempts + " intentos";
            tvNumber.Text = "Número jugado: " + numberToGuess;
        }
    }
}