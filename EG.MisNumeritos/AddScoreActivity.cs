using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using CapaDatos.Implementations;
using CapaDatos.Interfaces;
using EG.MisNumeritos.Source;

namespace EG.MisNumeritos
{
    [Activity(Label = "Mis Numeritos", Theme = "@style/AppTheme", MainLauncher = false)]
    public class AddScoreActivity : Activity
    {

        private string numberToGuess;
        private int attempts;
        private bool isGameWon;

        private Button executeButton;
        private EditText input;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_score);

            Bundle extras = this.Intent.Extras;

            if (extras != null)
            {
                numberToGuess = extras.GetString("NumberToGuess");
                attempts = extras.GetInt("Attempts");
                isGameWon = extras.GetBoolean("IsGameWon");
            }

            // Layout references
            executeButton = (Button)FindViewById(Resource.Id.btnUserConfirmed);
            input = (EditText)FindViewById(Resource.Id.txtUserName);

            // events
            AddListeners();

        }

        private void AddListeners()
        {
            executeButton.Click += (sender, e) =>
            {
                string user = input.Text;
                Score score;
                IDataAccess dataAccessObject = DataAccessFactory.GetDataAccessObject();

                if (string.IsNullOrWhiteSpace(user))
                {
                    Toast.MakeText(this, "Debe ingresar su nombre de usuario", ToastLength.Short).Show();
                }
                else
                {
                    score = new Score(user, attempts);

                    dataAccessObject.AddScoreToTopTen(score);

                    GoToFinishedGameActivity();
                }
            };
        }

        private void GoToFinishedGameActivity()
        {
            Intent finishedGameActivity = new Intent(this, new FinishedGameActivity().Class);
            finishedGameActivity.PutExtra("NumberToGuess", numberToGuess);
            finishedGameActivity.PutExtra("Attempts", attempts);
            finishedGameActivity.PutExtra("IsGameWon", isGameWon);

            StartActivity(finishedGameActivity);
            this.Finish();
        }
    }
}