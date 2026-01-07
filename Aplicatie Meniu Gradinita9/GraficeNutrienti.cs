using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Aplicatie_Meniu_Gradinita9
{
    public partial class GraficeNutrienti : UserControl
    {
        private string dbPath;
        private string connectionString;

        public GraficeNutrienti()
        {
            InitializeComponent();
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "meniul.mdf");
            connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security=True;Connect Timeout=30";
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            //Proteine
            InitializeChart(chartProteine, "Grafic Proteine Totale", "Valoare Proteine", "proteine", "total_proteine", 0, 60, 10, 36, 52.8);
            //Lipide
            InitializeChart(chartLipide, "Grafic Lipide Totale", "Valoare Lipide", "lipide", "total_lipide", 0, 60, 10, 20.00, 54.4);
            //Glucide
            InitializeChart(chartGlucide, "Grafic Glucide", "Valoare Glucide", "glucide", "total_glucide", 0, 180, 20, 136.8, 159.2);
            //Calorii
            InitializeChart(chartCalorii, "Grafic Calorii", "Valoare Calorii", "calorii", "total_calorii", 0, 1600, 200, 936, 1456);
        }

        private void InitializeChart(Chart chart, string title, string yAxisTitle, string tableName, string columnName, double yMin, double yMax, double yInterval, double necesarMin, double necesarMax)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();
            chart.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);

            chartArea.AxisX.Title = "Numar zile";
            chartArea.AxisX.Minimum = 1;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisX.Interval = 1;

            chartArea.AxisY.Title = yAxisTitle;
            chartArea.AxisY.Minimum = yMin;
            chartArea.AxisY.Maximum = yMax;
            chartArea.AxisY.Interval = yInterval;

            Series minSeries = new Series("Necesar Minim");
            minSeries.ChartType = SeriesChartType.Line;
            minSeries.Color = Color.Green;
            minSeries.BorderWidth = 2;

            Series realizatSeries = new Series("Valoare Realizata");
            realizatSeries.ChartType = SeriesChartType.Line;
            realizatSeries.Color = Color.Red;
            realizatSeries.BorderWidth = 2;

            Series maxSeries = new Series("Necesar Maxim");
            maxSeries.ChartType = SeriesChartType.Line;
            maxSeries.Color = Color.Blue;
            maxSeries.BorderWidth = 2;

            chart.Series.Add(minSeries);
            chart.Series.Add(realizatSeries);
            chart.Series.Add(maxSeries);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $@"SELECT TOP 10 {columnName}, ""data_adaugare"" FROM {tableName} ORDER BY ""data_adaugare"" DESC";
                    List<double> realizatValues = new List<double>();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                realizatValues.Add(Convert.ToDouble(reader[columnName]));
                            }
                        }
                    }
                    
                    realizatValues.Reverse();

                    for (int day = 1; day <= realizatValues.Count; day++)
                    {
                        double realizat = realizatValues[day - 1];

                        minSeries.Points.AddXY(day, necesarMin);
                        realizatSeries.Points.AddXY(day, realizat);
                        maxSeries.Points.AddXY(day, necesarMax);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching chart data for {title}: " + ex.Message);
                }
            }

            chart.Titles.Add(title);
            Legend legend = new Legend("MyLegend");
            chart.Legends.Add(legend);
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
        }

        public void RefreshData()
        {
            InitializeCharts();
        }
    }
}
