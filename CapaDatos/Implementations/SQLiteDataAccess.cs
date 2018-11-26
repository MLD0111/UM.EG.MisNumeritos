using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CapaDatos.Interfaces;
using EG.MisNumeritos.Source;
using SQLite;

namespace CapaDatos.Implementations
{
    public class SQLiteDataAccess : IDataAccess
    {
        private static readonly string DbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "database.db3");

        public void AddScoreToTopTen(Score record)
        {
            try
            {
                var topTen = GetTopTen();

                if (topTen == null)
                {
                    throw new Exception("Error al recuperar datos.");
                }
                else if (topTen.Count >= 10)
                {
                    // Delete last record from top ten
                    DeleteRecord<Score>(topTen.Last().Id);
                }

                // Add new record (in no particular order; sorting is performed when retrieving data)
                InsertRecord(record);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al persistir datos: " + ex.Message);
            }
        }

        public List<Score> GetTopTen()
        {
            List<Score> records = new List<Score>();
            try
            {
                using (var db = new SQLiteConnection(DbPath))
                {
                    // Creates a table if it doesn't exist, based on the class definition
                    db.CreateTable<Score>();

                    // Retrieve scores and sort them by attempts and date
                    var table = db.Table<Score>().OrderBy(s => s.Attempts).ThenBy(s => s.Date).Take(10).ToList();

                    // Retrieve results only if there are any, else return an empty list
                    if (table != null && table.Count > 0)
                    {
                        records = table;
                    }

                    return records;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar datos.\n"+ex.Message);
            }
        }

        private void DeleteRecord<T>(int id)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                // Start transaction
                var checkpoint = db.SaveTransactionPoint();
                // Delete record
                var rowcount = db.Delete<T>(id);
                // Commit or rollback transaction
                if (rowcount == 1)
                {
                    db.Release(checkpoint);
                }
                else
                {
                    db.RollbackTo(checkpoint);
                    throw new Exception("Error al eliminar datos. Rowcount = " + rowcount);
                }
            }
        }

        private void InsertRecord<T>(T record)
        {
            using (var db = new SQLiteConnection(DbPath))
            {
                // Creates a table if it doesn't exist, based on the class definition.
                db.CreateTable<T>();
                // Start transaction
                var checkpoint = db.SaveTransactionPoint();
                // Insert record
                var rowcount = db.Insert(record);
                // Commit or rollback transaction
                if (rowcount == 1)
                {
                    db.Release(checkpoint);
                }
                else
                {
                    db.RollbackTo(checkpoint);
                    throw new Exception("Error al insertar datos. Rowcount = " + rowcount);
                }
            }
        }
    }
}
