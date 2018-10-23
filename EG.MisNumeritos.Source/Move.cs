using System;
using System.Collections.Generic;
using System.Linq;

namespace EG.MisNumeritos.Source
{
    public class Move {
        private string playedNumber;
        private int assertedNumberAndIndex = 0;
        private int assertedNumber = 0;


        public Move(string numberToGuess, string playedNumber)
        {
            this.playedNumber = playedNumber;
            ValidatePlayerNumber(numberToGuess, playedNumber);
        }

        private void ValidatePlayerNumber(string numberToGuess, string playerNumberList)
        {
            for (int i = 0; i < numberToGuess.Length; i++)
            {
                if (numberToGuess[i] == playedNumber[i])
                {
                    assertedNumberAndIndex++;
                }
                else if (numberToGuess.Contains(playedNumber[i]) )
                {
                    assertedNumber++;
                }
            }
        }

        public int GetAssertedNumberAndIndex()
        {
            return assertedNumberAndIndex;
        }

        public int GetAssertedNumber()
        {
            return assertedNumber;
        }

        public override string ToString()
        {
            return "Resultado: " + playedNumber + " - Bien=" + assertedNumberAndIndex +
                    ", Regular=" + assertedNumber;
        }
    }
}