using System;
using System.Collections;
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

namespace EG.MisNumeritos.DAO
{
    public class ScoreDAO
    {
        public static bool guardarScore(Score score)
        {
            string sql = "INSERT INTO score (user, attemps, date) ";
            sql += "VALUES ('" + score.User + "', '" + score.Attemps.ToString() + "', '" + DateTime.Today.ToString("dd/MM/yyyy") + "');";

            return DataAccess.ejecutar(sql);
        }

        public static List<Score> recuperarTopTen()
        {
            string sql = "SELECT TOP(10) * FROM customers ORDER BY attemp DESC";

            List<Score> topTen = ProcesarRecuperar(sql);

            return topTen;
        }

        private static List<Score> ProcesarRecuperar(string sql)
        {
            List<Score> resultado;

            List<ArrayList> atributos = new List<ArrayList>();
            if (DataAccess.Recuperar(atributos, sql))
            {
                resultado = new List<Score>();

                Score iScore;
                foreach (ArrayList attr in atributos)
                {
                    iScore = new Score();
                    iScore.armar(attr);
                    resultado.Add(iScore);
                }

                return resultado;
            }
            return null;
        }
    }
}