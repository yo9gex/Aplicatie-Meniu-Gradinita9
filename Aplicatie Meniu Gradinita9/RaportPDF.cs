using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


using IContainer = QuestPDF.Infrastructure.IContainer;

namespace Aplicatie_Meniu_Gradinita9
{
    internal class RaportPDF(MeniulZilei meniulZilei) : IDocument
    {
        private readonly MeniulZilei _meniulZilei = meniulZilei;
        public string Date;
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(40);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
                page.Size(PageSizes.A3);
            });
        }
        private void ComposeHeader(IContainer container)
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "G_M.png");

            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Height(2, Unit.Centimetre).Image(imagePath);
                    //  column.Item().Text("");
                    column.Item().Text("Gradinita nr. " + _meniulZilei.NumeGradinita);
                    column.Item().Text(_meniulZilei.OrasGradinita);
                    column.Item().Text(_meniulZilei.JudetGradinita);
                    column.Item().Text("=============");


                });
                row.RelativeItem().Column(column =>
                {
                    //var padding = 5;
                    var scale = 1.15f;
                    // column.Item().BorderBottom(1).Padding(padding).Text("Meniul zilei: ").SemiBold();
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Scale(scale).Text("MENIUL ZILEI  ").SemiBold();
                    column.Item().Text("=============");
                    column.Item().Text($"Date: {Date = DateTime.Now.ToString("dd-MM-yyyy")}");
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Text("Meniu pentru un copil,");
                    column.Item().Text("  calculat pe 100 grame produs.");
                });
            });
        }

        private void ComposeContent(IContainer container)

        {
            container.PaddingVertical(20).Column(column =>
            {
                column.Item().Element(ComposeTable);
            });
        }
        private void ComposeTable(IContainer container)
        {
            NecesarAlimente nal = new NecesarAlimente();

            nal.CalculeazaParametri(out int numarCopiiTotal, out string tBrut, out string tC, out string tP, out string tP_veg, out string tP_anim, out string tL, out string tL_veg, out string tL_anim, out string tG, out string tFier,
             out string tCalciu, out string tCal, out string procentProteine, out string procentGlucide, out string procentLipide,
            nal.GetTotalCantitate_lbl());

            double.TryParse(tP, out double proteine);
            double.TryParse(tL, out double lipide);
            double.TryParse(tG, out double glucide);
            double.TryParse(tCal, out double calorii);
            double.TryParse(tBrut, out double brut);
            double.TryParse(tC, out double cantitate);

            container.Table(table =>
            {
                // defineste coloane

                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(16);  //No.
                    columns.RelativeColumn(4);  //Produs
                    columns.RelativeColumn();   //Proteine
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn(2); //TBrut
                    columns.RelativeColumn();  //TNet
                    columns.RelativeColumn(2);  //TProtein
                    columns.RelativeColumn();  //TLipide
                    columns.RelativeColumn();  //Glucide
                    columns.RelativeColumn();  //TCalorii

                });
                // defineste antet
                table.Header(header =>
                {
                    header.Cell().Element(CellStyling).Text("#");
                    header.Cell().Element(CellStyling).Text("| Produs");
                    header.Cell().Element(CellStyling).Text("Proteine").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("Lipide").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("Glucide").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("Calorii").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TBrut").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TNet").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TProteine").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TLipide").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TGlucide").AlignCenter().FontSize(11).SemiBold();
                    header.Cell().Element(CellStyling).AlignRight().Text("TCalorii").AlignCenter().FontSize(11).SemiBold();
                    

                    static IContainer CellStyling(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).Padding(0).BorderBottom(1).BorderColor(Colors.Black);
                    }

                });

                // defineste continutul de date
                NecesarAlimenteData na = new NecesarAlimenteData();
                List<NecesarAlimenteData> pdList = na.ListaNecesarAlimenteData();

                for (var i = 0; i < pdList.Count; i++)
                {
                    var pd = pdList[i];
                    double proteineDouble = Convert.ToDouble(pd.TProteine);
                    double lipideDouble = Convert.ToDouble(pd.TLipide);
                    double glucideDouble = Convert.ToDouble(pd.TGlucide);
                    double caloriiDouble = Convert.ToDouble(pd.TCalorii);
                    double cantitateDouble = Convert.ToDouble(pd.TCantitate);
                    double netDouble = Convert.ToDouble(pd.TNet);

                    table.Cell().Element(CellStyling).Padding(0).Text((i + 1).ToString());
                    table.Cell().Element(CellStyling).Padding(0).Text(pd.NumeProdus.ToString());
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text(pd.Proteine.ToString());
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text(pd.Lipide.ToString());
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text(pd.Glucide.ToString());
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text(pd.Calorii.ToString());
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((cantitateDouble / numarCopiiTotal).ToString("0.00"));
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((netDouble / numarCopiiTotal).ToString("0.00"));
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((proteineDouble / numarCopiiTotal).ToString("0.00"));
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((lipideDouble / numarCopiiTotal).ToString("0.00"));
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((glucideDouble / numarCopiiTotal).ToString("0.00"));
                    table.Cell().Element(CellStyling).Padding(0).AlignRight().Text((caloriiDouble / numarCopiiTotal).ToString("0.00"));
                    

                    static IContainer CellStyling(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }

                // Calcul total nutrienti pe un singur copil
                table.Cell()
                .ColumnSpan(5)
                .PaddingVertical(6)
                .BorderBottom(0)
                .BorderColor(Colors.Black);

                table.Cell().Padding(2).Text("TOTAL /copil").Bold().AlignCenter();
                table.Cell().AlignRight().Text((brut / numarCopiiTotal).ToString("0.00"));
                table.Cell().AlignRight().Text((cantitate / numarCopiiTotal).ToString("0.00"));
                table.Cell().AlignRight().Text((proteine / numarCopiiTotal).ToString("0.00"));
                table.Cell().AlignRight().Text((lipide / numarCopiiTotal).ToString("0.00"));
                table.Cell().AlignRight().Text((glucide / numarCopiiTotal).ToString("0.00"));
                table.Cell().AlignRight().Text((calorii / numarCopiiTotal).ToString("0.00"));
               


                string totalProteineCopii = (proteine).ToString("0");
                string totalLipideCopii = (lipide).ToString("0");
                string totalGlucideCopii = (glucide).ToString("0");
                string totalCaloriiCopii = (calorii).ToString("0");
                string totalBrutCopii = (brut).ToString("0");
                string totalCantitateCopii = (cantitate).ToString("0");

                table.Cell()
                    .ColumnSpan(5)
                    .PaddingVertical(6)
                    .BorderBottom(0)
                    .BorderColor(Colors.Black);
                table.Cell().Padding(4).Text("TOTAL" + "\n" + numarCopiiTotal + "  copii").Bold().AlignCenter();
                table.Cell().AlignRight();
                table.Cell().AlignRight();
                table.Cell().AlignRight().Text(totalProteineCopii);
                table.Cell().AlignRight().Text(totalLipideCopii);
                table.Cell().AlignRight().Text(totalGlucideCopii);
                table.Cell().AlignRight().Text(totalCaloriiCopii);
               
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

}
