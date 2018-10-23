using System;
using System.Collections.Generic;
using System.Linq;

namespace EG.MisNumeritos.Source
{
    public class Game
    {
        // Game status
        private static byte PLAYING = 1;
        private static byte ABORTED = 2;
        private static byte FINISHED = 3;

        // Business rules
        private static int MAXIMUM_NUMBER = 1023;
        private static int MINIMUM_NUMBER = 9876;
        private static int NUMBERS_LENGTH = 4;

        private List<Move> moves;
        private byte state;

        private string numberToGuess;

        public Game()
        {
            this.state = Game.PLAYING;
            this.moves = new List<Move>();
            SetRandomNumber();
        }

        private void SetRandomNumber()
        {
            this.numberToGuess = GetRandomNumber();
        }

        private string GetRandomNumber()
        {
            Random randomizer = new Random();
            double belowOneRandom = randomizer.NextDouble();

            int randomNumber = MINIMUM_NUMBER + (int)(belowOneRandom * ((MAXIMUM_NUMBER - MINIMUM_NUMBER) + 1));

            while (!this.IsAValidRandomNumber(randomNumber))
            {
                randomizer = new Random();
                belowOneRandom = randomizer.NextDouble();
                randomNumber = MINIMUM_NUMBER + (int)(belowOneRandom * ((MAXIMUM_NUMBER - MINIMUM_NUMBER) + 1));
            }

            return randomNumber.ToString();
        }

        public bool IsAValidRandomNumber(int randomNumber)
        {
            string checkNumber = randomNumber.ToString();

            for (int i = 0; i < NUMBERS_LENGTH; i++)
            {
                for (int j = i + 1; j < NUMBERS_LENGTH; j++)
                {
                    if (checkNumber[i] == checkNumber[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public Move DoNewMove(string playedNumber)
        {
            if (state != PLAYING)
            {
                throw new Exception("PARTIDA FINALIZADA");
                // TODO: delete the throws and go to the finished activity
            }

            Move output = new Move(this.numberToGuess, playedNumber);
            moves.Add(output);

            if (IsWinnerMove())
            {
                state = Game.FINISHED;
            }

            return output;
        }

        public string GetNumberToGuess()
        {
            return numberToGuess;
        }

        private bool IsWinnerMove()
        {
            return LastMove().GetAssertedNumberAndIndex() == Game.NUMBERS_LENGTH;
        }

        public Move LastMove()
        {
            return moves.Last();
        }

        public List<Move> GetMoves()
        {
            return moves;
        }

        public void Leave()
        {
            state = Game.ABORTED;
        }

        public bool IsGameFinished()
        {
            //return (state != Game.ABORTED && state != Game.FINISHED);
            return (state == Game.ABORTED || state == Game.FINISHED);
        }

        public int GetNumberOfMoves()
        {
            return moves.Count;
        }

        public bool IsGameWon()
        {
            return state == Game.FINISHED;
        }
    }
}