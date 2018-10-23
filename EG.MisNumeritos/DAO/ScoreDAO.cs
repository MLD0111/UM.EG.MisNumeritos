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
        public static bool GuardarScore(Score score)
        {
            string sql = "INSERT INTO score (user, attemps) ";
            sql += "VALUES ('" + score.User + "', " + score.Attemps.ToString() + ");";

            return DataAccess.Ejecutar(sql);
        }

        public static List<Score> RecuperarTopTen()
        {
            string sql = "SELECT TOP 10 * FROM score ORDER BY attemps, ID";

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