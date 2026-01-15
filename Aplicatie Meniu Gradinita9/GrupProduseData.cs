using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
     class GrupProduseData
    {
        public string Data { get; set; } //0
        public string ProduseLapte { get; set; } //1
        public string ProduseCarne { get; set; } //2
        public string Peste { get; set; } //3
        public string ProduseOu { get; set; } //4
        public string GrasimiTotale { get; set; } //5
        public string GrasimiAnimale { get; set; } //6
        public string GrasimiVegetale { get; set; } //7
        public string ProduseCereale { get; set; } //8
        public string Cartofi { get; set; } //9
        public string AlteLegume { get; set; } //10
        public string LegumeUscate { get; set; } //11
        public string Fructe { get; set; } //12
        public string Zaharuri { get; set; } //13


        string dbPath;
        string connectionString;
        SqlConnection connection;
        public GrupProduseData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<GrupProduseData> ListaData()
        {
            List<GrupProduseData> grupProduseList = new List<GrupProduseData>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM grupProduse";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GrupProduseData dataGrup = new GrupProduseData();
                    {

                        // Initialize properties here based on your table columns
                        dataGrup.Data = Convert.ToDateTime(reader["data_adaugare"]).ToString("dd/MM/yyyy ");
                        dataGrup.ProduseLapte = reader.IsDBNull(reader.GetOrdinal("lapteProduseLapte")) ? "0.00" : reader["lapteProduseLapte"].ToString();
                        dataGrup.ProduseCarne = reader.IsDBNull(reader.GetOrdinal("carneProduseCarne")) ? "0.00" : reader["carneProduseCarne"].ToString();
                        dataGrup.Peste = reader.IsDBNull(reader.GetOrdinal("pestePreparatePeste")) ? "0.00" : reader["pestePreparatePeste"].ToString();
                        dataGrup.ProduseOu = reader.IsDBNull(reader.GetOrdinal("oua")) ? "0.00" : reader["oua"].ToString();
                        dataGrup.GrasimiTotale = reader.IsDBNull(reader.GetOrdinal("grasimiTotale")) ? "0.00" : reader["grasimiTotale"].ToString();
                        dataGrup.GrasimiAnimale = reader.IsDBNull(reader.GetOrdinal("grasimiAnimale")) ? "0.00" : reader["grasimiAnimale"].ToString();
                        dataGrup.GrasimiVegetale = reader.IsDBNull(reader.GetOrdinal("grasimiVegetale")) ? "0.00" : reader["grasimiVegetale"].ToString();
                        dataGrup.ProduseCereale = reader.IsDBNull(reader.GetOrdinal("cerealeProduseCereale")) ? "0.00" : reader["cerealeProduseCereale"].ToString();
                        dataGrup.Cartofi = reader.IsDBNull(reader.GetOrdinal("cartofi")) ? "0.00" : reader["cartofi"].ToString();
                        dataGrup.AlteLegume = reader.IsDBNull(reader.GetOrdinal("alteLegume")) ? "0.00" : reader["alteLegume"].ToString();
                        dataGrup.LegumeUscate = reader.IsDBNull(reader.GetOrdinal("legumeUscate")) ? "0.00" : reader["legumeUscate"].ToString();
                        dataGrup.Fructe = reader.IsDBNull(reader.GetOrdinal("fructe")) ? "0.00" : reader["fructe"].ToString();
                        dataGrup.Zaharuri = reader.IsDBNull(reader.GetOrdinal("zaharuri")) ? "0.00" : reader["zaharuri"].ToString();
                    }
                    ;
                    grupProduseList.Add(dataGrup);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return grupProduseList;
        }
    }
}
