using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using CapaDatos.Implementations;
using CapaDatos.Interfaces;
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
                attempts = extras.GetInt("Attempts");
                isGameWon = extras.GetBoolean("IsGameWon");
            }
        }

        List<Score> topTenList = new List<Score>();
        private string numberToGuess;
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
            IDataAccess dataAccessObject = DataAccessFactory.GetDataAccessObject();
            // Get top ten from database
            topTenList = dataAccessObject.GetTopTen();

            string showText = string.Empty;
            int i = 1;

            foreach (var item in topTenList)
            {
                showText = showText + i + ". " + item.ToString() + "\n";
                i++;
            }

            // Put the top ten in the activity
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