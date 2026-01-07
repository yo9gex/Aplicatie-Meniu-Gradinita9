using Microsoft.Data.SqlClient;

namespace Aplicatie_Meniu_Gradinita9
{
    class PranzDataFel2
    {
        public string NumeProdus { get; set; }//0        
        public string TCantitatea { get; set; }//1
        public string TNet { get; set; }//2
        public override string ToString()
        {
            return $"{NumeProdus} - {TCantitatea} - {TNet}";
        }
        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection connection;
        public PranzDataFel2()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public List<PranzDataFel2> ListaPranzDataFel2()
        {
            List<PranzDataFel2> listaPranzFel2 = new List<PranzDataFel2>();

            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                    string query = "SELECT nume, TCantitate, TNet FROM totalAlimentePranz WHERE tip_fel = 'Felul 2' OR tip_fel ='Ambele' ";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            PranzDataFel2 lista = new PranzDataFel2();
                            lista.NumeProdus = reader["nume"].ToString();
                            lista.TCantitatea = reader["TCantitate"].ToString();
                            lista.TNet = reader.IsDBNull(reader.GetOrdinal("TNet")) ? "0.00" : reader["TNet"].ToString();
                            listaPranzFel2.Add(lista);
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
            return listaPranzFel2;
        }
    }
}
