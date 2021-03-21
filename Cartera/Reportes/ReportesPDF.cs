using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cartera.Reportes
{
    public class ReportesPDF
    {
        public string HistorialPagos(DataTable report)
        {
            string nombre = "Historial de pagos";

            var dir2 = @"C:\Users\RASEC\Documents\Cartera\CarteraSI\Cartera";

            //Dirección del proyecto donde se va a guardar
            string file = nombre + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
            //string file = "report1.pdf";
            string FilePath = dir2 + @"\Documento\" + file;

            Document document = new Document(PageSize.LETTER, 30, 20, 50, 50);
            MemoryStream m = new MemoryStream();

            //********************** Encabezado *******************************
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.OpenOrCreate));
            writer.PageEvent = new HeaderFooter();

            Paragraph texto = new Paragraph();
            texto.Alignment = Element.ALIGN_CENTER;
            texto.Font = FontFactory.GetFont("Verdana", 12);
            texto.Add("Nombre empresa");

            Paragraph info = new Paragraph();
            info.Alignment = 1;
            info.Font = FontFactory.GetFont("Verdana", 8, Font.BOLD);
            //*********************** Encabezado *************************

            //******* abrir documento
            document.Open();

            //******* Lineas **********            
            PdfContentByte pdfContent = writer.DirectContent;
            //****** Lineas **********

            //********* inicio portada**************
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    document.Add(texto);
                    texto.RemoveAt(0);
                }
                else if (i == 1)
                {
                    texto.Font = FontFactory.GetFont("Verdana", 8, Font.BOLD);
                    texto.Add("NIT: 1992883834".ToUpper());
                    texto.Alignment = 1;
                    document.Add(texto);
                    texto.RemoveAt(0);

                    texto.Add("asdas");
                    document.Add(texto);
                    texto.RemoveAt(0);

                    texto.Add("sdfsadf");
                    document.Add(texto);
                    texto.RemoveAt(0);

                    texto.Font = FontFactory.GetFont("Verdana", 7);
                    texto.Add("ANALISIS HISTORICO - CLIENTES");
                    document.Add(texto);
                    texto.RemoveAt(0);
                    string fecha;
                    //if (fecha1.Equals(""))
                    //{
                    //    DateTime Fechaf = Convert.ToDateTime(fecha2);

                    //    DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                    //    fecha = dtinfo.GetMonthName(Fechaf.Month) + " " + Fechaf.Day + " DE " + Fechaf.Year;
                    //}
                    //else
                    //{
                    //    DateTime Fechai = Convert.ToDateTime(fecha1);
                    //    DateTime Fechaf = Convert.ToDateTime(fecha2);

                    //    DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
                    //    fecha = dtinfo.GetMonthName(Fechai.Month) + " " + Fechai.Day + " DE " + Fechai.Year + " (A) " + dtinfo.GetMonthName(Fechaf.Month) + " " + Fechaf.Day + " DE " + Fechaf.Year;
                    //}
                    texto.Add(DateTime.Now.ToString());
                    document.Add(texto);
                    texto.RemoveAt(0);

                    texto.Add("Nombre del cliente");
                    document.Add(texto);
                    texto.RemoveAt(0);

                    document.Add(new Paragraph(" "));

                    //*** Linea cabesera
                    pdfContent.MoveTo(30, document.PageSize.Height - 120);
                    pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 120);
                    pdfContent.Stroke();
                    //*** Linea detalle
                    pdfContent.MoveTo(30, document.PageSize.Height - 150);
                    pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 150);
                    pdfContent.Stroke();
                }
                else if (i == 2)
                {
                    document.Add(TablasLetras(report, new float[] { 53f, 7f, 7f, 7f }, 100, 7));
                }
                else
                {
                    document.Add(new Paragraph(" "));
                }
            }
            //********************** Cerrar documento ********************           
            document.Close();

            //doc.Add(new Chunk("/n")); cuendo se necesite imprimir un enter en el documento
            return file;
        }
        public PdfPTable TablasLetras(DataTable Cons, float[] Size, int Porcentaje, int Letra)
        {

            PdfPTable objetivo = new PdfPTable(Size.Length);
            objetivo.SetWidths(Size);
            Phrase frase;
            PdfPCell celda;
            //**** Encabezado de Tabla
            foreach (DataColumn column in Cons.Columns)
            {
                celda = new PdfPCell();
                celda.Rowspan = 1;
                celda.Colspan = 1;
                celda.VerticalAlignment = Element.ALIGN_MIDDLE;
                celda.BorderColor = BaseColor.WHITE;

                frase = new Phrase();
                frase.Font = FontFactory.GetFont("Verdana", Letra, iTextSharp.text.Font.BOLD);
                frase.Add(column.ColumnName);

                celda.Phrase = frase;
                objetivo.AddCell(celda);
            }

            Boolean TextoNegrita;

            //*****Filas de Tabla********
            for (int i = 0; i < Cons.Rows.Count; i++)
            {
                TextoNegrita = false;
                foreach (DataColumn column in Cons.Columns)
                {

                    frase = new Phrase();
                    if (TextoNegrita)
                        frase.Font = FontFactory.GetFont("Verdana", Letra, Font.BOLD);
                    else
                        frase.Font = FontFactory.GetFont("Verdana", Letra);
                    frase.Add(Cons.Rows[i][column.ColumnName].ToString());


                    celda = new PdfPCell();
                    celda.BorderColor = BaseColor.WHITE;
                    celda.Phrase = frase;
                    objetivo.AddCell(celda);
                }
            }
            objetivo.WidthPercentage = Porcentaje;
            return objetivo;
        }

        class HeaderFooter : IPdfPageEvent
        {
            public PdfContentByte pdfContent;

            public HeaderFooter()
            {
            }
            public void OnChapter(PdfWriter writer, Document document, float paragraphPosition, Paragraph title)
            {
            }
            public void OnChapterEnd(PdfWriter writer, Document document, float paragraphPosition)
            {
            }
            public void OnCloseDocument(PdfWriter writer, Document document)
            {
            }
            public void OnEndPage(PdfWriter writer, Document document)
            {
                //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
                Phrase p1Header = new Phrase("", FontFactory.GetFont("verdana", 8));
                Phrase p2Header = new Phrase("", FontFactory.GetFont("verdana", 8));
                //create iTextSharp.text Image object using local image path
                //->iTextSharp.text.Image imgPDF = iTextSharp.text.Image.GetInstance(HttpRuntime.AppDomainAppPath + @"\Content\imagenes\logopipe.png");
                //imgPDF.Width = 10;
                //->imgPDF.ScaleAbsolute(55, 25);
                //Create PdfTable object
                PdfPTable pdfTab = new PdfPTable(2);
                //We will have to create separate cells to include image logo and 2 separate strings
                //->PdfPCell pdfCell1 = new PdfPCell(imgPDF);
                PdfPCell pdfCell2 = new PdfPCell(p1Header);
                PdfPCell pdfCell3 = new PdfPCell(p2Header);
                //set the alignment of all three cells and set border to 0
                //->pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                //->pdfCell1.VerticalAlignment = Element.ALIGN_CENTER;
                pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;

                pdfCell3.VerticalAlignment = Element.ALIGN_CENTER;

                //->pdfCell1.Border = 0;
                pdfCell2.Border = 0;
                pdfCell3.Border = 0;
                //add all three cells into PdfTable
                //->pdfTab.AddCell(pdfCell1);
                pdfTab.AddCell(pdfCell2);
                pdfTab.AddCell(pdfCell3);
                pdfTab.TotalWidth = document.PageSize.Width - 20;
                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                pdfTab.WriteSelectedRows(0, -1, 10, document.PageSize.Height - 20, writer.DirectContent);
                //set pdfContent value
                pdfContent = writer.DirectContent;
                //Move the pointer and draw line to separate header section from rest of page
                pdfContent.MoveTo(30, document.PageSize.Height - 45);
                pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 45);
                //linea footer
                pdfContent.MoveTo(30, document.PageSize.Height - 750);
                pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 750);
                //We are going to add two strings in header. Create separate Phrase object with font setting and string to be included
                Phrase pie = new Phrase("Documento generado por ", FontFactory.GetFont("verdana", 8));
                Phrase pie2 = new Phrase("Pagina  " + writer.PageNumber, FontFactory.GetFont("verdana", 8));
                Phrase usu = new Phrase("" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), FontFactory.GetFont("verdana", 8));
                //create iTextSharp.text Image object using local image path
                //imgPDF.Width = 10;
                //Create PdfTable object
                PdfPTable pdffo = new PdfPTable(3);
                //We will have to create separate cells to include image logo and 2 separate strings
                PdfPCell pdfCel2 = new PdfPCell(pie);
                PdfPCell pdfCel3 = new PdfPCell(pie2);
                PdfPCell pdfCel4 = new PdfPCell(usu);
                //set the alignment of all three cells and set border to 0
                pdfCel2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCel3.HorizontalAlignment = Element.ALIGN_RIGHT;
                pdfCel2.VerticalAlignment = Element.ALIGN_BOTTOM;
                pdfCel4.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCel4.VerticalAlignment = Element.ALIGN_BOTTOM;

                pdfCel3.VerticalAlignment = Element.ALIGN_CENTER;

                pdfCel2.Border = 0;
                pdfCel3.Border = 0;
                pdfCel4.Border = 0;
                //add all three cells into PdfTable
                pdffo.AddCell(pdfCel2);
                pdffo.AddCell(pdfCel4);
                pdffo.AddCell(pdfCel3);
                pdffo.TotalWidth = document.PageSize.Width - 20;
                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                pdffo.WriteSelectedRows(0, -1, 10, (document.PageSize.Height - document.PageSize.Height) + 40, writer.DirectContent);
                //set pdfContent value
                pdfContent = writer.DirectContent;
                //Move the pointer and draw line to separate header section from rest of page
                //   pdfContent.MoveTo(30, document.PageSize.Height - 35);
                // pdfContent.LineTo(document.PageSize.Width - 20, document.PageSize.Height - 35);
                pdfContent.Stroke();

            }
            public void OnGenericTag(PdfWriter writer, Document document, Rectangle rect, string text)
            {
            }
            public void OnOpenDocument(PdfWriter writer, Document document)
            {
            }
            public void OnParagraph(PdfWriter writer, Document document, float paragraphPosition)
            {
            }
            public void OnParagraphEnd(PdfWriter writer, Document document, float paragraphPosition)
            {
            }
            public void OnSection(PdfWriter writer, Document document, float paragraphPosition, int depth, Paragraph title)
            {
            }
            public void OnSectionEnd(PdfWriter writer, Document document, float paragraphPosition)
            {
            }
            public void OnStartPage(PdfWriter writer, Document document)
            {
            }
        }
    }
}
