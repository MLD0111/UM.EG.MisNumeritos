﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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

            listview = FindViewById<ListView> (Resource.Id.listView_score);

            LoadTopTen();
        }

        ListView listview;
        List<ScoreNode> topTenList = new List<ScoreNode>();

        private void LoadTopTen()
        {
            // TODO Add database logic to load top ten
        }   
    }
}