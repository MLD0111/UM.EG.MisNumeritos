using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CapaDatos;
using EG.MisNumeritos.Source;

namespace EG.MisNumeritos.DAO
{
    public class ScoreDAO : SQLiteOpenHelper
    {

        private static int idGandaor; // INTEGER PRIMARY KEY AUTOINCREMENT, 
        private static string nombre;
        private static int intentos;
        private static string dataBase = "baseDeDatos.db";

        public ScoreDAO(Context context) : base(context, dataBase, null, 1)
        {

        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL("drop table if exists score");
            db.ExecSQL("CREATE TABLE score (idGandaor INTEGER PRIMARY KEY AUTOINCREMENT, nombre TEXT, intentos INT)");
        }

        public override void OnUpgrade(SQLiteDatabase db, int versionAnte, int versionNue)
        {
            db.ExecSQL("drop table if exists score");
            OnCreate(db);
        }

        public void agregarPuntaje(Score score)
        {  
            ContentValues valores = new ContentValues();
            valores.Put("nombre", score.User);
            valores.Put("intentos", score.Attemps);
            this.WritableDatabase.Insert("score", null, valores);
        }
        public ICursor getScores()
        {
            string[] columnas = { "idGandaor", "nombre", "intentos" };
            ICursor c = this.ReadableDatabase.RawQuery("SELECT * FROM score  ORDER BY intentos ASC, idGandaor DESC ", null); ;
            return c;
        }

        public List<Score> devolverScore()
        {
            ICursor c = this.getScores();
            List<Score> scores = new List<Score>();
            Score score;
            if (c.MoveToFirst() == false)
            {
                Console.Out.WriteLine("Problem getting score");
            }
            else
            {
                do
                {
                    score = new Score(c.GetString(1), c.GetInt(2));
                    scores.Add(score);
                } while (c.MoveToNext());
            }

            return scores;
        }

        public int cantidadDeRegistros()
        {
            ICursor fila = this.ReadableDatabase.RawQuery("Select * FROM score", null);
            int countFila = -1;
            if (fila != null)
            {
                countFila = fila.Count;
            }
            return countFila;
        }

        public Boolean noHayscore()
        { //Permite saber si la tabla está vacía
            Boolean noHayscore = true;
            ICursor fila = this.ReadableDatabase.RawQuery("Select * FROM score", null);
            if (fila != null)
            {
                int countFila = fila.Count;
                if (countFila > 0)
                    noHayscore = false;
                else
                    noHayscore = true;
            }
            return noHayscore;
        }

        public Boolean eliminarRegistroPuesto10()
        {
            String query = "SELECT idGandaor FROM score WHERE idGandaor = (SELECT MIN(idGandaor) FROM score WHERE intentos = (SELECT MAX(intentos) FROM score) )";
            ICursor fila = this.ReadableDatabase.RawQuery(query, null);
            Boolean seElimino = true;
            string idEliminar;
            if (fila != null)
                if (fila.MoveToFirst())
                {
                    idEliminar = fila.GetString(0);
                    this.WritableDatabase.ExecSQL("DELETE FROM score WHERE idGandaor in (" + query + ");");
                    //this.WritableDatabase.Delete("score", idGandaor = int.Parse(idEliminar), )

                }
                else
                {
                    seElimino = false;
                }
            else
            {
                seElimino = false;
            }
            return seElimino;
        }

        public void registrarPuntaje(Score score)
        {
            if (!(noHayscore()) && (cantidadDeRegistros() == 10))
                eliminarRegistroPuesto10();
            this.agregarPuntaje(score);
        }

        public void eliminarTabla()
        {
            this.WritableDatabase.ExecSQL("drop table if exists score");
        }

        public void crearTabla()
        {
            this.WritableDatabase.ExecSQL("CREATE TABLE score (idGandaor INTEGER PRIMARY KEY AUTOINCREMENT, nombre TEXT, intentos INT)");
        }

        public int consultarMaximoNumeroDeIntentosDeLaBase()
        {

            ICursor fila = this.ReadableDatabase.RawQuery("SELECT MAX(intentos) FROM score", null);
            // bd.close();
            if (fila != null)
            {
                if (fila.MoveToFirst())
                {
                    return Convert.ToInt32(fila.GetString(0));
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                //Toast.MakeText(this, "No existe base de datos", ToastLength.Long).Show();
                return 0;
            }

        }

        internal ICursor rawQuery(string v, object p)
        {
            throw new NotImplementedException();
        }

        internal ScoreDAO OnUpgrade()
        {
            throw new NotImplementedException();
        }

        internal ScoreDAO OnCreate()
        {
            throw new NotImplementedException();
        }

        internal int delete(string v1, string v2, object p)
        {
            throw new NotImplementedException();
        }


        /*public static List<Score> RecuperarTopTen()
        {
            
            List<Score> topTen = new List<Score>();
            topTen.Add(new Score("juan", 1));
            topTen.Add(new Score("Fede", 2));
            topTen.Add(new Score("Mile", 3));
            topTen.Add(new Score("Matias", 4 ));
            topTen.Add(new Score("Nacho", 5));
            topTen.Add(new Score("jose", 6));
            topTen.Add(new Score("pedro", 7));
            topTen.Add(new Score("peter", 8));
            topTen.Add(new Score("jorge", 9));
            topTen.Add(new Score("raul", 10));


            return topTen;
        }*/
    }
}