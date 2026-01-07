using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace Aplicatie_Meniu_Gradinita9.Services
{
    public class MeniulZileiPdf
    {
        public PdfDocument GetInvoice()
        {
            var document = new Document();

            BuildDocument(document);


            var pdfRenderer = new PdfDocumentRenderer();

            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            return pdfRenderer.PdfDocument;
        }

        private void BuildDocument(Document document)
        {
            var section = document.AddSection();
            var paragraph = section.AddParagraph("Meniul Zilei");

            paragraph.Format.Font.Size = 18;
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = "1cm";


            var table = section.AddTable();
            table.Borders.Width = 0.75;
            var column = table.AddColumn("5cm");
            column.Format.Alignment = ParagraphAlignment.Left;
            column = table.AddColumn("10cm");
            column.Format.Alignment = ParagraphAlignment.Left;


            var row = table.AddRow();
            row.Cells[0].AddParagraph("Data:");
            row.Cells[1].AddParagraph(DateTime.Now.ToString("dd-MM-yyyy"));
            row = table.AddRow();
            row.Cells[0].AddParagraph("Mic Dejun:");
            row.Cells[1].AddParagraph("Lapte cu biscuiti");
            row = table.AddRow();
            row.Cells[0].AddParagraph("Pranz:");
            row.Cells[1].AddParagraph("Ciorba de pui, friptura de pui cu piure cartofi");
            row = table.AddRow();
            row.Cells[0].AddParagraph("Gustare:");
            row.Cells[1].AddParagraph("Banana");
            
        }
    }
}

