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
    [Activity(Label = "InstructionsActivity")]
    public class InstructionsActivity : Activity
    {
        TextView textView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
            SetContentView(Resource.Layout.activity_instructions);

            textView = FindViewById<TextView>(Resource.Id.listView_instructions);

            loadText();

            addListeners();
        }

        private void addListeners()
        {
        }

        private void loadText()
        {
            string showText = string.Empty;

            showText += "El objetivo del juego consiste en tratar de adivinar un número aleatorio, y en cada jugada se irá indicando la cantidad de dígitos acertados o regulares.";
            showText += "\n" + "El número a adivinar (y por tanto el de cada jugada), debe cumplir las siguientes condiciones:";
            showText += "\n" + "Ser de 4 dígitos, los cuales no pueden estar repetidos:";
            showText += "\n" + "No comenzar con el dígito 0 (cero)";
            showText += "\n" + "Con estas condiciones, el número debe estar entre 1023 y 9876, y excluyendo cualquier combinación en la que hayan dígitos iguales";
            showText += "\n" + "En cada jugada, se indicará el Nº jugado, y la cantidad de aciertos (BIEN) y de existentes pero en otra posición (REGULARES)";
            showText += "\n" + "Ejemplos de números NO Válidos:\n0389 (comienza con cero)\n1424 (se repite uno o más dígitos)\n629 (no es de 4 dígitos)";
            showText += "\n" + "En caso de adivinar el número, si está entre los 10 con menor cantidad de intentos, su nombre ingresará al TOP TEN";

            textView.Text = showText;
        }

    }
}