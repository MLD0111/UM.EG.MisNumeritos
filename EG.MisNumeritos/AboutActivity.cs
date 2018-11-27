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

namespace EG.MisNumeritos
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        TextView textView;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            SetContentView(Resource.Layout.activity_about);

            textView = FindViewById<TextView>(Resource.Id.listView_aboutApp);

            loadText();

            addListeners();
        }

        private void addListeners()
        {
        }


        private void loadText()
        {
            string showText = string.Empty;

            showText += "Esta app de juego ha sido desarrollada por alumnos de la Universidad de Morón.";
            showText += "\n" + "449 - ELECTIVA GENERAL\n713 - PROGRAMACIÓN AVANZADA II";
            showText += "\n" + "Alumnos:";
            showText += "\n" + "Alessio, Federico    3701-0374";
            showText += "\n" + "Alonso, Matías       4601-0229";
            showText += "\n" + "Lewitzki, Milena     4501-0701";
            showText += "\n" + "Roldós, Ignacio      3901-2463";
            showText += "\n" + "UM - 2018 C2";

            textView.Text = showText;
        }

    }
}