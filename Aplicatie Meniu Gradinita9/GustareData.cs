using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
     class GustareData
    {
        public string NumeProdus { get; set; }//0        
        public string TCantitatea { get; set; }//1
        public string TNet { get; set; }//2
        public override string ToString()
        {
            return $"{NumeProdus} - {TCantitatea} - {TNet}";
        }

        //SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
            public GustareData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<GustareData> ListaGustareData()
        {
            List<GustareData> listaGustare = new List<GustareData>();

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nume, TCantitate, TNet FROM totalAlimenteGustare";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            GustareData lista = new GustareData();
                            lista.NumeProdus = reader["nume"].ToString();
                            lista.TCantitatea = reader["TCantitate"].ToString();
                            lista.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            listaGustare.Add(lista);
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
            return listaGustare;
        }
    }
}
