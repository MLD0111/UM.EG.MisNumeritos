using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace EG.MisNumeritos
{
    [Activity(Label = "MIS NUMERITOS", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            userNameTextView = FindViewById<TextView>(Resource.Id.nameTextView);
            //userIdTextView = FindViewById<TextView>(Resource.Id.idTextView);

            playButton = (Button) FindViewById(Resource.Id.playButton);
            scoresButton = (Button) FindViewById(Resource.Id.scoresButton);
            //instructionsButton = FindViewById(Resource.Id.instructionsButton);
            //aboutButton = FindViewById(Resource.Id.aboutButton);
            //logOutButton = FindViewById(Resource.Id.logOutButton);
            //revokeButton = FindViewById(Resource.Id.revokeButton);

            AddListeners();
        }

        private string username = "Usuario Anónimo";
        // UI
        private Button playButton;
        private Button scoresButton;
        //private Button instructionsButton;
        //private Button aboutButton;
        //private Button logOutButton;
        //private Button revokeButton;

        private TextView userNameTextView;
        //private TextView userIdTextView;

        private void AddListeners()
        {
            playButton.Click += (sender, e) => 
            {
                Intent gameActivity = new Intent(this, new GameActivity().Class);
                gameActivity.PutExtra("Username", username);
                StartActivity(gameActivity);
            };

            scoresButton.Click += (sender, e) =>
            {
                Intent scoreActivity = new Intent(this, new ScoreActivity().Class);
                StartActivity(scoreActivity);
            };
        }
    
        protected override void OnStart()
        {
            base.OnStart();
            //userIdTextView.Text = "0";
        }
    }
}