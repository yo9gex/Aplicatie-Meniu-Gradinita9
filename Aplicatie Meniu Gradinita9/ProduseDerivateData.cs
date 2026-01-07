using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.CodeDom;
using System.Data.SqlTypes;

namespace Aplicatie_Meniu_Gradinita9
{


    class ProduseDerivateData
    {
        // public int Id { set; get; } //0
        public string NumeProdus { set; get; } //0
        public decimal Proteine { set; get; } //1
        public decimal ProteineVegetale { set; get; } //2
        public decimal ProteineAnimale { set; get; } //3
        public decimal Lipide { set; get; }  //4
        public decimal LipideVegetale { set; get; }  //5
        public decimal LipideAnimale { set; get; }  //6
        public decimal Glucide { set; get; } //7
        public decimal Fier { set; get; } //8
        public decimal Calciu { set; get; } //9
        public decimal Calorii { set; get; }  //10
        public decimal Scazamant { set; get; }  //11
        public decimal Cantitate { set; get; }  //12
        public int GrupProduse1 { set; get; }  //13
        public decimal CoeficientEchiv1 { set; get; }  //14
        public int GrupProduse2 { set; get; }  //15
        public decimal CoeficientEchiv2 { set; get; }  //16
        public string Status { set; get; }  //17

        // public decimal Bucati { set; get; }  //8
        //public DateTime DataAdaugare { set; get; }  //9


        //SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\LeVantinik\Documents\meniul.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""F:\8_Proiecte visual studio\Test\Aplicatie Meniu Gradinita9\Aplicatie Meniu Gradinita9\meniul.mdf"";Integrated Security=True");
        string dbPath;
        string connectionString;
        SqlConnection conn;
        public ProduseDerivateData()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }

        public List<ProduseDerivateData> produseDerivateListData()
        {
            List<ProduseDerivateData> produseList = new List<ProduseDerivateData>();
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM produseDerivateCereale";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProduseDerivateData pd = new ProduseDerivateData();
                       // pd.Id = (int)reader["id"];
                        pd.NumeProdus = reader["nume"].ToString();
                        pd.Proteine = Convert.ToDecimal(reader["proteine"] == DBNull.Value ? 0 : reader["proteine"]);
                        pd.ProteineVegetale = Convert.ToDecimal(reader["proteine_vegetale"] == DBNull.Value ? 0 : reader["proteine_vegetale"]);
                        pd.ProteineAnimale = Convert.ToDecimal(reader["proteine_animale"] == DBNull.Value ? 0 : reader["proteine_animale"]);
                        pd.Lipide = Convert.ToDecimal(reader["lipide"] == DBNull.Value ? 0 : reader["lipide"]);
                        pd.LipideVegetale = Convert.ToDecimal(reader["lipide_vegetale"] == DBNull.Value ? 0 : reader["lipide_vegetale"]);
                        pd.LipideAnimale = Convert.ToDecimal(reader["lipide_animale"] == DBNull.Value ? 0 : reader["lipide_animale"]);
                        pd.Glucide = Convert.ToDecimal(reader["glucide"] == DBNull.Value ? 0 : reader["glucide"]);
                        pd.Fier = Convert.ToDecimal(reader["fier"] == DBNull.Value ? 0 : reader["fier"]);
                        pd.Calciu = Convert.ToDecimal(reader["calciu"] == DBNull.Value ? 0 : reader["calciu"]);
                        pd.Calorii = Convert.ToDecimal(reader["calorii"] == DBNull.Value ? 0 : reader["calorii"]);
                        pd.Scazamant = Convert.ToDecimal(reader["scazamant"] == DBNull.Value ? 0 : reader["scazamant"]);
                        pd.Cantitate = Convert.ToDecimal(reader["cantitate"] == DBNull.Value ? 0 : reader["cantitate"]);
                        pd.GrupProduse1 = Convert.ToInt32(reader["grupa_produse1"] == DBNull.Value ? 0 : reader["grupa_produse1"]);
                        pd.CoeficientEchiv1 = Convert.ToDecimal(reader["coeficient_echivalent1"] == DBNull.Value ? 0 : reader["coeficient_echivalent1"]);
                        pd.GrupProduse2 = Convert.ToInt32(reader["grupa_produse2"] == DBNull.Value ? 0 : reader["grupa_produse2"]);
                        pd.CoeficientEchiv2 = Convert.ToDecimal(reader["coeficient_echivalent2"] == DBNull.Value ? 0 : reader["coeficient_echivalent2"]);
                        pd.Status = reader["status"].ToString();

                        produseList.Add(pd);
                    }
                    reader.Close();
                   
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            return produseList;
        }

        public List<ProduseDerivateData> listaNecesarAlimenteData()
        {
            List<ProduseDerivateData> produseList = new List<ProduseDerivateData>();
            if (conn.State == ConnectionState.Closed)
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM produseDerivateCereale WHERE status = 'Alege' ";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProduseDerivateData pd = new ProduseDerivateData();
                       // pd.Id = (int)reader["id"];
                        pd.NumeProdus = reader["nume"].ToString();
                        pd.Proteine = Convert.ToDecimal(reader["proteine"] == DBNull.Value ? 0 : reader["proteine"]);
                        pd.ProteineVegetale = Convert.ToDecimal(reader["proteine_vegetale"] == DBNull.Value ? 0 : reader["proteine_vegetale"]);
                        pd.ProteineAnimale = Convert.ToDecimal(reader["proteine_animale"] == DBNull.Value ? 0 : reader["proteine_animale"]);
                        pd.Lipide = Convert.ToDecimal(reader["lipide"] == DBNull.Value ? 0 : reader["lipide"]);
                        pd.LipideVegetale = Convert.ToDecimal(reader["lipide_vegetale"] == DBNull.Value ? 0 : reader["lipide_vegetale"]);
                        pd.LipideAnimale = Convert.ToDecimal(reader["lipide_animale"] == DBNull.Value ? 0 : reader["lipide_animale"]);
                        pd.Glucide = Convert.ToDecimal(reader["glucide"] == DBNull.Value ? 0 : reader["glucide"]);
                        pd.Fier = Convert.ToDecimal(reader["fier"] == DBNull.Value ? 0 : reader["fier"]);
                        pd.Calciu = Convert.ToDecimal(reader["calciu"] == DBNull.Value ? 0 : reader["calciu"]);
                        pd.Calorii = Convert.ToDecimal(reader["calorii"] == DBNull.Value ? 0 : reader["calorii"]);
                        pd.Scazamant = Convert.ToDecimal(reader["scazamant"] == DBNull.Value ? 0 : reader["scazamant"]);
                        pd.Cantitate = Convert.ToDecimal(reader["cantitate"] == DBNull.Value ? 0 : reader["cantitate"]);
                        pd.GrupProduse1 = Convert.ToInt32(reader["grupa_produse1"] == DBNull.Value ? 0 : reader["grupa_produse1"]);
                        pd.CoeficientEchiv1 = Convert.ToDecimal(reader["coeficient_echivalent1"] == DBNull.Value ? 0 : reader["coeficient_echivalent1"]);
                        pd.GrupProduse2 = Convert.ToInt32(reader["grupa_produse2"] == DBNull.Value ? 0 : reader["grupa_produse2"]);
                        pd.CoeficientEchiv2 = Convert.ToDecimal(reader["coeficient_echivalent2"] == DBNull.Value ? 0 : reader["coeficient_echivalent2"]);
                        pd.Status = reader["status"].ToString();

                        produseList.Add(pd);
                    }
                    reader.Close();

                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log it)
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            return produseList;
        }

    }

}
    


