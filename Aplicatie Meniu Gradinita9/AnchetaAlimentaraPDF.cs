using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using QuestPDF.Fluent;
using IContainer = QuestPDF.Infrastructure.IContainer;

namespace Aplicatie_Meniu_Gradinita9
{
    internal class AnchetaAlimentaraPDF(AnchetaAlimentara anchetaAlimentara) : IDocument
    {
        private readonly AnchetaAlimentara _anchetaAlimentara = anchetaAlimentara;
        public string Date;
       
        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(50);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
                page.Size(PageSizes.A3.Landscape());

            });
        }
        public void ComposeHeader(IContainer container) 
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "G_M.png");
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Height(2, QuestPDF.Infrastructure.Unit.Centimetre).Image(imagePath);
                    column.Item().Text("Gradinita nr. " + _anchetaAlimentara.MeniulZileiInstance.NumeGradinita);
                    column.Item().Text(_anchetaAlimentara.MeniulZileiInstance.OrasGradinita);
                    column.Item().Text(_anchetaAlimentara.MeniulZileiInstance.JudetGradinita);
                    column.Item().Text("=============");
                });
                row.RelativeItem().Column(column =>
                {
                    var scale = 1.15f;
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Scale(scale).Text("ANCHETA ALIMENTARA PENTRU 10 ZILE ").SemiBold();
                    column.Item().Text("=====================================");
                    column.Item().Text($"          Date: {Date = DateTime.Now.ToString("dd-MM-yyyy")}");
                    column.Item().Text("");
                    column.Item().Text("");                
                    column.Item().Text("");
                    column.Item().Text("");
                    column.Item().Text("");
                });
            });
        }
        private void ComposeContent(IContainer container)
        {
            TotalNutrienti tn = new TotalNutrienti();
            _anchetaAlimentara.CalculAbatereMedie(out string totalAbatereC, out string totalAbatereP, out string totalAbatereL, out string totalAbatereG);
            _anchetaAlimentara.InterpretareRezultate(out string interpretareC, out string interpretareP, out string interpretareL, out string interpretareG);

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
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                    });
                    table.Cell().TableValueCell();
                    table.Cell().TableLabelCell("Valoare realizata" + "\n" + "/copil");
                    table.Cell().TableLabelCell("Necesar estimat /copil" + "\n" + "(3-6 ani)" +"\n" + "100%");
                    table.Cell().TableLabelCell("Necesar estimat /copil" + "\n" + "(3-6 ani)" + "\n" + "80%");
                    table.Cell().TableLabelCell("Interpretare");
                    table.Cell().TableLabelCell("Abatere de la medie" + "\n" + "pe necesar estimat" + "\n" + "80%");
                    table.Cell().TableLabelCell("Valoarea realizata" + "\n" + "%");
                 
                    table.Cell().TableLabelCell("Calorii" + "\n" + "(kcal)");
                    table.Cell().TableValueCell().Text(tn.TotalCalorii).AlignCenter();
                    table.Cell().TableValueCell().Text("1469 calorii" + "\n\n" +  "(1170-1820)").AlignCenter();
                    table.Cell().TableValueCell().Text("1175.2 calorii" + "\n\n" + "(936-1456)").AlignCenter();
                    table.Cell().TableValueCell().Text(interpretareC).AlignCenter();
                    table.Cell().TableValueCell().Text(totalAbatereC).AlignCenter();
                    table.Cell().TableValueCell();

                    table.Cell().TableLabelCell("Proteine Totale" + "\n" + "(gr.)");
                    table.Cell().TableValueCell().Text(tn.TotalProteine).AlignCenter();
                    table.Cell().TableValueCell().Text("37 g" + "\n\n" + "(45-66)").AlignCenter();
                    table.Cell().TableValueCell().Text("29.6 g" + "\n\n" + "(36-52.8)").AlignCenter();
                    table.Cell().TableValueCell().Text(interpretareP).AlignCenter();
                    table.Cell().TableValueCell().Text(totalAbatereP).AlignCenter();
                    table.Cell().TableValueCell().Text(tn.ProcentProteine).AlignCenter();

                    table.Cell().TableLabelCell("Lipide Totale" + "\n" + "(gr.)");
                    table.Cell().TableValueCell().Text(tn.TotalLipide).AlignCenter();
                    table.Cell().TableValueCell().Text("44 g" + "\n\n" + "(25-68)").AlignCenter();
                    table.Cell().TableValueCell().Text("35.2" + "\n\n" +"(20-54.4)").AlignCenter();
                    table.Cell().TableValueCell().Text(interpretareL).AlignCenter();
                    table.Cell().TableValueCell().Text(totalAbatereL).AlignCenter();
                    table.Cell().TableValueCell().Text(tn.ProcentLipide).AlignCenter();

                    table.Cell().TableLabelCell("Glucide Totale" + "\n" + "(gr.)");
                    table.Cell().TableValueCell().Text(tn.TotalGlucide).AlignCenter();
                    table.Cell().TableValueCell().Text("191 g" + "\n\n" + "(171-199)").AlignCenter();
                    table.Cell().TableValueCell().Text("158.2 g" + "\n\n" + "(136.2-159.2)").AlignCenter();
                    table.Cell().TableValueCell().Text(interpretareG).AlignCenter();
                    table.Cell().TableValueCell().Text(totalAbatereG).AlignCenter();
                    table.Cell().TableValueCell().Text(tn.ProcentGlucide).AlignCenter();

                    table.Cell()
            .ColumnSpan(1)
            .PaddingVertical(40)
            .AlignCenter()
            .BorderBottom(0);


                    table.Cell().Padding(20).Text("DIRECTOR").Bold().AlignRight();
                    table.Cell().Padding(20).Text("MEDIC").Bold().AlignRight();
                    table.Cell().Padding(20).Text("AS.MEDICAL").Bold().AlignRight();
                    table.Cell().Padding(20).Text("ADMINISTRATOR").Bold().AlignRight();
                    table.Cell().Padding(20).Text("BUCATAR").Bold().AlignRight();

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
