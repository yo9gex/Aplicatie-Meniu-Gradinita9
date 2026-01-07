using MigraDoc.DocumentObjectModel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using IContainer = QuestPDF.Infrastructure.IContainer;


namespace Aplicatie_Meniu_Gradinita9
{
    internal class MeniuPDF(MeniulZilei meniulZilei) : IDocument 
    {
        private readonly MeniulZilei _meniulZilei = meniulZilei;
        public string Date;
       
        public void Compose(IDocumentContainer container)
        {
            
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
                page.Size(PageSizes.A2.Landscape());
                                            
            });
        }
        private void ComposeHeader(IContainer container)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "G_M.png");
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Height(2, QuestPDF.Infrastructure.Unit.Centimetre).Image(imagePath);
                    column.Item().Text("Gradinita nr. " + _meniulZilei.NumeGradinita);                   
                    column.Item().Text(_meniulZilei.OrasGradinita);
                    column.Item().Text(_meniulZilei.JudetGradinita);                  
                    column.Item().Text("=============");
                });
                row.RelativeItem().Column(column =>
                {
                    var scale = 1.15f;
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Scale(scale).Text("MENIUL ZILEI  ").SemiBold();
                    column.Item().Text("=============");
                    column.Item().Text($"Date: {Date = DateTime.Now.ToString("dd-MM-yyyy")}");
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Text("Meniu pentru un copil,");
                    column.Item().Text("  calculat pe 100 grame produs.");
                    column.Item().Text("");
                });

                //row.RelativeItem().Column(column =>
                //{
                //    column.Item().Table(table =>
                //    {
                //        table.ColumnsDefinition(columns =>
                //        {
                //            columns.RelativeColumn();
                //        });

                //        table.Cell().Text("Mic Dejun: " + _meniulZilei.MicDejunText);
                //        column.Item().Text("");
                //        table.Cell().Text("Pranz Felul 1: " + _meniulZilei.Felul1Text);
                //        column.Item().Text("");
                //        table.Cell().Text("Pranz Felul 2: " + _meniulZilei.Felul2Text);
                //        column.Item().Text("");
                //        table.Cell().Text("Gustare: " + _meniulZilei.GustareText);
                //    });
                //});
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text("Mic Dejun: " + _meniulZilei.MicDejunText);
                    column.Item().Text("");
                    column.Item().Text("Pranz Felul 1: " + _meniulZilei.Felul1Text);
                    column.Item().Text("");
                    column.Item().Text("Pranz Felul 2: " + _meniulZilei.Felul2Text);
                    column.Item().Text("");
                    column.Item().Text("Gustare: " + _meniulZilei.GustareText);
                });
            });
        }
        private void ComposeContent(IContainer container)
        {
            var mz = new MeniulZilei();
           
            mz.MeniuDejun();
            mz.MeniuGustare();
            mz.MeniuPranzFel1();
            mz.MeniuPranzFel2();
            NecesarAlimente na = new NecesarAlimente();
            na.CalculeazaParametri(out int NumarCopiiTotal, out string tBrut, out string tC, out string tP, out string tL, out string tG, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
                na.GetTotalCantitate_lbl());

            MicDejunAlimente md = new MicDejunAlimente();
            md.CalculeParametriNutrienti(out decimal totalProteine, out decimal totalLipide, out decimal totalGlucide, out decimal totalCalorii);

            PranzAlimente pa = new PranzAlimente();
            pa.CalculParametriNutrientiFel1(out decimal totalProteine1, out decimal totalLipide1, out decimal totalGlucide1, out decimal totalCalorii1);
            pa.CalculParametriNutrientiFel2(out decimal totalProteine2, out decimal totalLipide2, out decimal totalGlucide2, out decimal totalCalorii2);

            GustareAlimente ga = new GustareAlimente();
            ga.CalculParametriNutrienti(out decimal totalProteine3, out decimal totalLipide3, out decimal totalGlucide3, out decimal totalCalorii3);

            container.Border(0)
                .Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(2);

                });
                table.Cell().TableLabelCell("Mic Dejun" + "\n" +  "    TBrut - TNet");
                table.Cell().TableLabelCell("Pranz" + "\n" +  "Felul1");
                table.Cell().TableLabelCell("Pranz" + "\n" + "Felul2");
                table.Cell().TableLabelCell("Gustare");
                table.Cell().TableLabelCell("Total declaratie" + "\n" + "  nutritionala");

                


                table.Cell().TableValueCell().Text(mz.ListaMicDejun + " gr").SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text(mz.ListaPranzFel1 + " gr").SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text(mz.ListaPranzFel2 + " gr").SemiBold().FontSize(12);
                table.Cell().TableValueCell().AspectRatio(16 / 9f).Text(mz.ListaGustare + " gr").SemiBold().FontSize(12);
                table.Cell().TableValueCell()
                .Text("\n \n \n" + " Proteine = " + tP + " gr" + "\n \n" + " Lipide = " + tL + " gr" + "\n \n" + " Glucide = " + tG + " gr" + "\n \n" + " Calorii = " + tCal + " Kcal/copil")
                .SemiBold().FontSize(12);

                table.Cell().TableLabelCell("Declaratie" + "\n" + " Nutritionala");
                table.Cell().TableLabelCell("Declaratie" + "\n" + " Nutritionala");
                table.Cell().TableLabelCell("Declaratie" + "\n" + " Nutritionala");
                table.Cell().TableLabelCell("Declaratie" + "\n" + " Nutritionala");
                table.Cell().TableLabelCell("Necesar estimativ" + "\n" + " Copil (3-6 ani)" + "\n" + " 80%");

                table.Cell().TableValueCell().Text("\n \n" + " Proteine = " + totalProteine + " gr" + "\n \n" + " Lipide = " + totalLipide + " gr" + "\n \n" + " Glucide = " + totalGlucide + " gr" + "\n \n" + " Calorii = " + totalCalorii + " Kcal/copil" + "\n")
                .SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text("\n \n" + " Proteine = " + totalProteine1 + " gr" + "\n \n" + " Lipide = " + totalLipide1 + " gr" + "\n \n" + " Glucide = " + totalGlucide1 + " gr" + "\n \n" + " Calorii = " + totalCalorii1 + " Kcal/copil" + "\n")
               .SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text("\n \n" + " Proteine = " + totalProteine2 + " gr" + "\n \n" + " Lipide = " + totalLipide2 + " gr" + "\n \n" + " Glucide = " + totalGlucide2 + " gr" + "\n \n" + " Calorii = " + totalCalorii2 + " Kcal/copil" + "\n")
               .SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text("\n \n" + " Proteine = " + totalProteine3 + " gr" + "\n \n" + " Lipide = " + totalLipide3 + " gr" + "\n \n" + " Glucide = " + totalGlucide3 + " gr" + "\n \n" + " Calorii = " + totalCalorii3 + " Kcal/copil" + "\n")
                .SemiBold().FontSize(12);
                table.Cell().TableValueCell()
                .Text("\n \n" + "Proteine = " + decimal.Parse(procentProteine).ToString("#.##") + " %" + "\n \n" + "Lipide = " + decimal.Parse(procentLipide).ToString("#.##") + " %" + "\n \n" + "Glucide = " + decimal.Parse(procentGlucide).ToString("#.##") + " %" + "\n")  
                .SemiBold().FontSize(12);

                table.Cell()
                .ColumnSpan(5)
                .PaddingVertical(6)
                .AlignCenter()
                .BorderBottom(0);
                
                // Allergen information
                table.Cell().TableLabelCell("Alimente posibil alergene:");
                table.Cell().TableLabelCell("Alimente posibil alergene:");
                table.Cell().TableLabelCell("Alimente posibil alergene:");
                table.Cell().TableLabelCell("Alimente posibil alergene:");
                table.Cell().TableLabelCell(""); // Empty cell for the last column

                table.Cell().TableValueCell().Text(_meniulZilei.NumeProdusAlergen1).SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text(_meniulZilei.NumeProdusAlergen2).SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text(_meniulZilei.NumeProdusAlergen3).SemiBold().FontSize(12);
                table.Cell().TableValueCell().Text(_meniulZilei.NumeProdusAlergen4).SemiBold().FontSize(12);
                table.Cell().TableValueCell().Border(0).Text("").SemiBold().FontSize(8); // Empty cell for the last column

                table.Cell().Padding(40).Text("DIRECTOR").Bold().AlignRight();
                table.Cell().Padding(40).Text("MEDIC").Bold().AlignRight();
                table.Cell().Padding(40).Text("AS.MEDICAL").Bold().AlignRight();
                table.Cell().Padding(40).Text("ADMINISTRATOR").Bold().AlignRight();
                table.Cell().Padding(40).Text("BUCATAR").Bold().AlignRight();
               
            });
           

        }

        private void ComposeFooter(IContainer container)
        {
            
            container.AlignCenter().Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
                
            });
        }
    }

public static class TableExtensions
    {
        private static  IContainer TableCellStyle(this IContainer container, string backgroundColor) => container
                .Border(1)
                .BorderColor(QuestPDF.Helpers.Colors.Black)
                .Background(backgroundColor)
                .Padding(10);

        public static void TableLabelCell(this IContainer container, string text)
        {
            container
                .TableCellStyle(QuestPDF.Helpers.Colors.Grey.Lighten4)
                .Text(text)
                .Bold()
                .AlignCenter()
                .FontSize(12);

        }

        public static IContainer TableValueCell(this IContainer container)
        {
            return container.TableCellStyle(QuestPDF.Helpers.Colors.Transparent);
        }
    }
} 
