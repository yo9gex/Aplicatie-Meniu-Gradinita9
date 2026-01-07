using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie_Meniu_Gradinita9
{
     class PranzAlimenteDataActualizate
     {
       
            public string NumeProdus { get; set; }//0
            public string TCantitatea { get; set; }//1
            public string TNet { get; set; }//2
            public string TProteine { get; set; }//3
            public string TLipide { get; set; }//4
            public string TGlucide { get; set; }//5
            public string TCalorii { get; set; }//6
            public string TipMeniu { get; set; }//7
            public string TipFel { get; set; }//8


        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public PranzAlimenteDataActualizate()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            connection = new SqlConnection(connectionString);
        }
        public List<PranzAlimenteDataActualizate> ListaPranzAlimenteDataActualizate()
            {
                List<PranzAlimenteDataActualizate> produseList = new List<PranzAlimenteDataActualizate>();
                if (connection.State != ConnectionState.Open)
                {
                    try
                    {
                        connection.Open();
                        string query = "SELECT * FROM totalAlimentePranz WHERE status = 'Alege' AND (tip_meniu = 'P' OR tip_meniu = 'MD+P' OR tip_meniu = 'G+P') ";
                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                PranzAlimenteDataActualizate pada = new PranzAlimenteDataActualizate();
                                pada.NumeProdus = reader["nume"].ToString();
                                pada.TCantitatea = reader["TCantitate"].ToString();
                                pada.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                                pada.TProteine = reader.IsDBNull(reader.GetOrdinal("TProteine")) ? "0.00" : reader["TProteine"].ToString();
                                pada.TLipide = reader.IsDBNull(reader.GetOrdinal("TLipide")) ? "0.00" : reader["TLipide"].ToString();
                                pada.TGlucide = reader.IsDBNull(reader.GetOrdinal("TGlucide")) ? "0.00" : reader["TGlucide"].ToString();
                                pada.TCalorii = reader.IsDBNull(reader.GetOrdinal("TCalorii")) ? "0.00" : reader["TCalorii"].ToString();
                                pada.TipMeniu = reader["tip_meniu"].ToString();
                                pada.TipFel = reader["tip_fel"].ToString();
                                produseList.Add(pada);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A aparut o eroare: " + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                return produseList;
            }      
     }
}
