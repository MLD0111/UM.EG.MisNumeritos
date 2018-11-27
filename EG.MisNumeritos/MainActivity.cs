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

            playButton = (Button) FindViewById(Resource.Id.playButton);
            scoresButton = (Button) FindViewById(Resource.Id.scoresButton);
            instructionsButton = (Button) FindViewById(Resource.Id.instructionsButton);
            aboutButton = (Button)FindViewById(Resource.Id.aboutButton);

            AddListeners();
        }

        // UI
        private Button playButton;
        private Button scoresButton;
        private Button instructionsButton;
        private Button aboutButton;
        private TextView userNameTextView;

        private void AddListeners()
        {
            playButton.Click += (sender, e) => 
            {
                Intent gameActivity = new Intent(this, new GameActivity().Class);
                StartActivity(gameActivity);
            };

            scoresButton.Click += (sender, e) =>
            {
                Intent scoreActivity = new Intent(this, new ScoreActivity().Class);
                StartActivity(scoreActivity);
            };

            instructionsButton.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, new InstructionsActivity().Class);
                StartActivity(intent);
            };

            aboutButton.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, new AboutActivity().Class);
                StartActivity(intent);
            };

        }
    
        protected override void OnStart()
        {
            base.OnStart();
        }
    }
}