using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DataAccess
    {
        private static OleDbCommand cmd;
        private static OleDbDataAdapter da;
        private static OleDbConnection con;
        private static DataSet ds;

        // EG.MisNumeritos\bin\Debug
        public static readonly string baseDirDB = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + baseDirDB + "\\..\\..\\mis-num-database.mdb";

        

        public static bool Recuperar(List<ArrayList> atributos, string sql)
        {
            ArrayList row;
            bool ok;
            try
            {
                con = new OleDbConnection(strCon);
                con.Open();
                da = new OleDbDataAdapter(sql, con);
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    row = new ArrayList();
                    IEnumerator en = ds.Tables[0].Rows[i].ItemArray.GetEnumerator();
                    while (en.MoveNext())
                    {
                        row.Add(en.Current);
                    }
                    atributos.Add(row);
                }
                ok = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Debug.WriteLine("MisNumeritos Error: " + error);
                ok = false;
            }
            finally
            {
                con.Close();
            }
            return ok;
        }

        public static bool ejecutar(string sql)
        {
            bool ok = false;
            try
            {
                con = new OleDbConnection(strCon);
                con.Open();
                cmd = new OleDbCommand(sql, DataAccess.con);
                cmd.ExecuteNonQuery();
                ok = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Debug.WriteLine("MisNumeritos error: " + error);
            }
            finally
            {
                DataAccess.con.Close();
            }

            return ok;
        }
    }
}
