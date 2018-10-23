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
using EG.MisNumeritos.Source;

namespace EG.MisNumeritos
{
    [Activity(Label = "Mis Numeritos", Theme = "@style/AppTheme", MainLauncher = false)]
    public class GameActivity : Activity
    {
        private Game game;
        private string username;

        // From view
        private TextView numberView;
        private Button executeButton;
        private Button leaveButton;
        private TextView statusView;
        private EditText movesET;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_game);

            Bundle extras = this.Intent.Extras;
            
            if (extras != null)
            {
                username = extras.GetString("Username");
            }

            // Layout references
            executeButton = (Button) FindViewById(Resource.Id.executeButton);
            leaveButton = (Button) FindViewById(Resource.Id.leaveButton);
            numberView = (TextView) FindViewById(Resource.Id.numberInputText);
            statusView = (TextView) FindViewById(Resource.Id.statusText);
            movesET = (EditText) FindViewById(Resource.Id.movesET);
            movesET.Text = string.Empty;

            // Create new Game
            game = new Game();

            Toast.MakeText(this, "Ya tenemos un numerito para que adivines", ToastLength.Short).Show();

            // Test show
            this.statusView.Text = game.GetNumberToGuess();

            // events
            AddListeners();
        }

        private void AddListeners()
        {
            executeButton.Click += (sender, e) =>
            {
                string playerNumber = numberView.Text;
                string moves = string.Empty;

                if (playerNumber.Length < 4)
                {
                    Toast.MakeText(this, "Debe ingresar un número de 4 cifras", ToastLength.Short).Show();
                }
                else
                {
                    Move lastMove;
                    try
                    {
                        if (game.IsAValidRandomNumber(int.Parse(playerNumber)))
                        {
                            lastMove = game.DoNewMove(playerNumber);

                            moves = lastMove.ToString() + "\n" + movesET.Text;

                            // IF THE PLAYER WON OR LEFT (FINISHED IS ABORTED OR WON), OPEN FINISHED GAME ACTIVITY
                            if (game.IsGameFinished())
                            {
                                GoToFinishedGameActivity();
                            }
                        }
                        else
                        {
                            moves = movesET.Text;
                            Toast.MakeText(this, "El número ingresado no puede contener dígitos repetidos.", ToastLength.Short).Show();
                        }

                    }
                    catch (Exception ex)
                    {
                        Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                        return;
                    }

                    movesET.Text = moves;
                    numberView.Text = string.Empty;
                }
            };

            leaveButton.Click += (sender, e) =>
            {
                game.Leave();
                GoToFinishedGameActivity();
            };
        }

        private void GoToFinishedGameActivity()
        {
            Intent finishedGameActivity = new Intent(this, new FinishedGameActivity().Class);
            finishedGameActivity.PutExtra("NumberToGuess", game.GetNumberToGuess());
            finishedGameActivity.PutExtra("Username", username);
            finishedGameActivity.PutExtra("Attempts", game.GetNumberOfMoves());
            finishedGameActivity.PutExtra("IsGameWon", game.IsGameWon());

            StartActivity(finishedGameActivity);
            this.Finish();
        }
    }
}