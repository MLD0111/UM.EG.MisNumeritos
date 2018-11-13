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
using CapaDatos;
using EG.MisNumeritos.Source;

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

            LoadTopTen();
        }

        TextView textView;

        private void LoadTopTen()
        {
            // Get top ten from database
            var topTenList = SQLiteDataAccess.GetTopTen();

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