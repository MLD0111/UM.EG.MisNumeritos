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
    [Activity(Label = "ScoreActivity")]
    public class ScoreActivity : Activity
    {
        private ScoreDAO bd;

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
            bd = new ScoreDAO(this);
            List<Score> topTenList =  bd.devolverScore();
            //List<Score> topTenList = ScoreDAO.RecuperarTopTen();


            string showText = string.Empty;
            int i = 0;
            
            /*
            List<Score> topTenList = new List<Score>();
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
            textView.Text = showText;
        }
    }
}