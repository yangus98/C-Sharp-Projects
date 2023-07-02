using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GestioneVeicoli
{
    public class Database
    {
        private static string sc = "Data Source = LAPTOP-OK3FRIM1; Initial Catalog = Veicolo;" +
            "Integrated Security = True; Trust Server Certificate = True";
        private static SqlConnection cn = new SqlConnection(sc);
        private static string query;
        public Database() 
        {
        }

        public bool ottieniConnessione()
        {
            try
            {      
                cn.Open();
                return true;
                
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public bool chiudiConnessione()
        {
            try
            {
                cn.Close();
                return true;    
            }
            catch (SqlException e)
            {
                return false; 
            }

        }

        public string leggiDati()
        {
            string result = "";
            query = "SELECT * FROM Autocarri";
            SqlCommand sqlc = new SqlCommand(query, cn);
            SqlDataReader reader = sqlc.ExecuteReader();
            while (reader.Read())
            {
                result += $"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetDouble(4)}\n";
            }
            query = "SELECT * FROM Autoveicoli";
            sqlc = new SqlCommand(query, cn);
            reader = sqlc.ExecuteReader();
            while (reader.Read())
            {
                result += $"{reader.GetString(0)} {reader.GetString(1)} {reader.GetString(2)} {reader.GetInt32(3)} {reader.GetInt32(4)}\n";
            }
            return result;
        }

        public SqlDataReader leggiAutocarro()
        {
            query = "SELECT * FROM Autocarri";
            SqlCommand sqlc = new SqlCommand(query, cn);
            SqlDataReader reader = sqlc.ExecuteReader();
            return reader;
        }

        public SqlDataReader leggiAutoveicolo()
        {
            query = "SELECT * FROM Autoveicoli";
            SqlCommand sqlc = new SqlCommand(query, cn);
            SqlDataReader reader = sqlc.ExecuteReader();
            return reader;
        }

        public bool inserisciAutocarro(Autocarro autocarri)
        {
            try
            {
                query = "INSERT INTO Autocarri VALUES(@targa, @marca, @modello, @numeroPosti, @capacitaMassimaCarico)";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(query, cn);
                adapter.InsertCommand.Parameters.Add("@targa", SqlDbType.VarChar, 7);
                adapter.InsertCommand.Parameters["@targa"].Value = autocarri.Targa;
                adapter.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 10);
                adapter.InsertCommand.Parameters["@marca"].Value = autocarri.Marca;
                adapter.InsertCommand.Parameters.Add("@modello", SqlDbType.VarChar, 10);
                adapter.InsertCommand.Parameters["@modello"].Value = autocarri.Modello;
                adapter.InsertCommand.Parameters.Add("@numeroPosti", SqlDbType.Int);
                adapter.InsertCommand.Parameters["@numeroPosti"].Value = autocarri.NumeroPosti;
                adapter.InsertCommand.Parameters.Add("@capacitaMassimaCarico", SqlDbType.Float);
                adapter.InsertCommand.Parameters["@capacitaMassimaCarico"].Value = autocarri.CapacitaMassimaCarico;
                adapter.InsertCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool inserisciAutoveicolo(Autoveicolo autoveicoli)
        {
            try
            {
                query = "INSERT INTO Autoveicoli VALUES(@targa, @marca, @modello, @numeroPosti, @numeroPorte)";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(query, cn);
                adapter.InsertCommand.Parameters.Add("@targa", SqlDbType.VarChar, 7);
                adapter.InsertCommand.Parameters["@targa"].Value = autoveicoli.Targa;
                adapter.InsertCommand.Parameters.Add("@marca", SqlDbType.VarChar, 10);
                adapter.InsertCommand.Parameters["@marca"].Value = autoveicoli.Marca;
                adapter.InsertCommand.Parameters.Add("@modello", SqlDbType.VarChar, 10);
                adapter.InsertCommand.Parameters["@modello"].Value = autoveicoli.Modello;
                adapter.InsertCommand.Parameters.Add("@numeroPosti", SqlDbType.Int);
                adapter.InsertCommand.Parameters["@numeroPosti"].Value = autoveicoli.NumeroPosti;
                adapter.InsertCommand.Parameters.Add("@numeroPorte", SqlDbType.Int);
                adapter.InsertCommand.Parameters["@numeroPorte"].Value = autoveicoli.NumeroPorte;
                adapter.InsertCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public static bool updateAutocarro(double capacitaMassimaCarico, string targa)
        {
            query = "UPDATE Autocarri SET capacitaMassimaCarico = @capacitaMassimaCarico WHERE targa = @targa";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = new SqlCommand(query, cn);
            adapter.InsertCommand.Parameters.Add("@capacitaMassimaCarico", SqlDbType.Int);
            adapter.InsertCommand.Parameters["@capacitaMassimaCarico"].Value = capacitaMassimaCarico;
            adapter.InsertCommand.Parameters.Add("@targa", SqlDbType.VarChar);
            adapter.InsertCommand.Parameters["@targa"].Value = targa;

            try
            {
                adapter.InsertCommand.ExecuteNonQuery();
                return true;

            }catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
