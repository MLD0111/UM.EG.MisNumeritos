using Android.App;
using Android.OS;
using Android.Text.Method;
using Android.Widget;
using CapaDatos.Implementations;
using CapaDatos.Interfaces;

namespace EG.MisNumeritos
{
    [Activity(Label = "ScoreActivity")]
    public class ScoreActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_score);

            textView = FindViewById<TextView>(Resource.Id.textView3);
            textView.VerticalScrollBarEnabled = true;
            textView.NestedScrollingEnabled = true;

            LoadTopTen();
        }

        TextView textView;

        private void LoadTopTen()
        {
            IDataAccess dataAccessObject = DataAccessFactory.GetDataAccessObject();
            // Get top ten from database
            var topTenList = dataAccessObject.GetTopTen();

            string showText = string.Empty;
            int i = 1;

            foreach (var item in topTenList)
            {
                showText = showText + i.ToString("D2") + ". " + item.ToString() + "\n";
                i++;
            }

            // Put the top ten in the activity
            textView.Text = showText;
        }
    }
}