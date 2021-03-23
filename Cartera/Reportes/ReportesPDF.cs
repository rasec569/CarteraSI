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
using System.Windows.Forms;

namespace Cartera.Reportes
{
    public class ReportesPDF
    {
        public void HistorialPagos(DataTable report, string cedula, string Nombres, string producto, string proyecto, string valor_total,string Valor_deduda, string valor_pagado)
        {
            //string nombre = "Historial de pagos";
            
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ////Dirección del proyecto donde se va a guardar


                    ////string file = "report1.pdf";
                    //string FilePath = dir2 + @"\Documento\" + file;
                    var nombre = sfd.FileName;
                    var nombre2 = sfd.Title;
                    string file = nombre2 + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
                    Document document = new Document(PageSize.LETTER, 30, 20, 50, 50);
                    try
                    {
                        //Save pdf file
                        //PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                        MemoryStream m = new MemoryStream();

                        //********************** Encabezado *******************************
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(nombre, FileMode.OpenOrCreate));
                        writer.PageEvent = new HeaderFooter();
                        //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.OpenOrCreate)); writer.PageEvent = new HeaderFooter();

                        Paragraph texto = new Paragraph();
                        texto.Alignment = Element.ALIGN_CENTER;
                        texto.Font = FontFactory.GetFont("Verdana", 12);
                        texto.Add("URBANIZADORA Y CONSTRUCTORA SAN ISIDRO S.A.S");
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
                                texto.Add("NIT: 901100097-1".ToUpper());
                                texto.Alignment = 1;
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("Conjunto el Encanto Calle 24 No. 19C-24 Local 4");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("3126120806");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Font = FontFactory.GetFont("Verdana", 7);
                                texto.Add("HISTORIAL PAGOS - CLIENTE: " + cedula + " " + Nombres + " PRODUCTO: " + producto + " " + proyecto);
                                document.Add(texto);
                                texto.RemoveAt(0);
                                //string fecha;
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
                                texto.Add(" VALOR PAGADO: $" + valor_pagado + " DEUDA: $" + Valor_deduda + " VALOR PRODUCTO: $" + valor_total + " FECHA REPORTE: " + DateTime.Now.ToString());
                                document.Add(texto);
                                texto.RemoveAt(0);

                                //texto.Add(Nombres);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

                                //texto.Add(cedula);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

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
                                document.Add(TablasLetras(report, new float[] { 16f, 17f, 17f, 17f, 17f, 16f }, 100, 8));
                            }
                            else
                            {
                                document.Add(new Paragraph(" "));
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        //********************** Cerrar documento ********************         
                        document.Close();
                    }                    
                }
                //return file;
            }            
        }
        public void Cartera(DataTable report, string total, string recaudado, string deuda )
        {
            //string nombre = "Historial de pagos";

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ////Dirección del proyecto donde se va a guardar


                    ////string file = "report1.pdf";
                    //string FilePath = dir2 + @"\Documento\" + file;
                    var nombre = sfd.FileName;
                    var nombre2 = sfd.Title;
                    string file = nombre2 + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
                    Document document = new Document(PageSize.LETTER, 30, 20, 50, 50);
                    try
                    {
                        //Save pdf file
                        //PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                        MemoryStream m = new MemoryStream();

                        //********************** Encabezado *******************************
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(nombre, FileMode.OpenOrCreate));
                        writer.PageEvent = new HeaderFooter();
                        //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.OpenOrCreate)); writer.PageEvent = new HeaderFooter();

                        Paragraph texto = new Paragraph();
                        texto.Alignment = Element.ALIGN_CENTER;
                        texto.Font = FontFactory.GetFont("Verdana", 12);
                        texto.Add("URBANIZADORA Y CONSTRUCTORA SAN ISIDRO S.A.S");
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
                                texto.Add("NIT: 901100097-1".ToUpper());
                                texto.Alignment = 1;
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("Conjunto el Encanto Calle 24 No. 19C-24 Local 4");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("3126120806");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Font = FontFactory.GetFont("Verdana", 7);
                                texto.Add("REPORTE - CARTERA " +  " FECHA: " + DateTime.Now.ToString());
                                document.Add(texto);
                                texto.RemoveAt(0);

                                //string fecha;
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
                                texto.Add(" TOTAL CARTERA: " + total + " VALOR RECAUDADO: " + recaudado + " VALOR DEUDA: " + deuda);
                                document.Add(texto);
                                texto.RemoveAt(0);

                                //texto.Add(Nombres);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

                                //texto.Add(cedula);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

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
                                document.Add(TablasLetras(report, new float[] { 12f, 20f, 20f, 13f, 12f, 10f, 12f, 13f}, 100, 7));
                            }
                            else
                            {
                                document.Add(new Paragraph(" "));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        //********************** Cerrar documento ********************         
                        document.Close();
                    }
                }
                //return file;
            }
        }
        public void Clientes(DataTable report)
        {
            //string nombre = "Historial de pagos";

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ////Dirección del proyecto donde se va a guardar


                    ////string file = "report1.pdf";
                    //string FilePath = dir2 + @"\Documento\" + file;
                    var nombre = sfd.FileName;
                    var nombre2 = sfd.Title;
                    string file = nombre2 + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".pdf";
                    Document document = new Document(PageSize.LETTER, 30, 20, 50, 50);
                    try
                    {
                        //Save pdf file
                        //PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.OpenOrCreate));
                        MemoryStream m = new MemoryStream();

                        //********************** Encabezado *******************************
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(nombre, FileMode.OpenOrCreate));
                        writer.PageEvent = new HeaderFooter();
                        //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.OpenOrCreate)); writer.PageEvent = new HeaderFooter();

                        Paragraph texto = new Paragraph();
                        texto.Alignment = Element.ALIGN_CENTER;
                        texto.Font = FontFactory.GetFont("Verdana", 12);
                        texto.Add("URBANIZADORA Y CONSTRUCTORA SAN ISIDRO S.A.S");
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
                                texto.Add("NIT: 901100097-1".ToUpper());
                                texto.Alignment = 1;
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("Conjunto el Encanto Calle 24 No. 19C-24 Local 4");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Add("3126120806");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                texto.Font = FontFactory.GetFont("Verdana", 7);
                                texto.Add("REPORTE - CLIENTES ");
                                document.Add(texto);
                                texto.RemoveAt(0);

                                //string fecha;
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
                                //texto.Add(" TOTAL CARTERA: " + total + " VALOR RECAUDADO: " + recaudado + " VALOR DEUDA: " + deuda);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

                                texto.Add(" FECHA REPORTE: " + DateTime.Now.ToString());
                                document.Add(texto);
                                texto.RemoveAt(0);

                                //texto.Add(cedula);
                                //document.Add(texto);
                                //texto.RemoveAt(0);

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
                                document.Add(TablasLetras(report, new float[] { 15f, 20f, 20f, 15f, 15f, 15f }, 100, 7));
                            }
                            else
                            {
                                document.Add(new Paragraph(" "));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        //********************** Cerrar documento ********************         
                        document.Close();
                    }
                }
                //return file;
            }
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
                Image image1 = Image.GetInstance(@"C:\Users\RASEC\Documents\Cartera\CarteraSI\Cartera\img\logo San Isidro.png");
                //image1.ScalePercent(50f);
                image1.Alignment = Element.ALIGN_LEFT;
                image1.ScaleAbsoluteWidth(60);
                image1.ScaleAbsoluteHeight(60);
                ////create iTextSharp.text Image object using local image path
                //Image imgPDF = Image.GetInstance(@"C:\Users\RASEC\Documents\Cartera\CarteraSI\Cartera\img\logo 2 San Isidro.png");
                //imgPDF.Width = 10;
                //imgPDF.ScaleAbsolute(55, 55);
                ////Create PdfTable object
                PdfPTable pdfTab = new PdfPTable(3);
                //We will have to create separate cells to include image logo and 2 separate strings
                PdfPCell pdfCell1 = new PdfPCell(image1);
                PdfPCell pdfCell2 = new PdfPCell(p1Header);
                PdfPCell pdfCell3 = new PdfPCell(p2Header);
                //set the alignment of all three cells and set border to 0
                pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell1.PaddingLeft = 35f;
                pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                pdfCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell1.PaddingTop = 35f;
                pdfCell2.VerticalAlignment = Element.ALIGN_BOTTOM;
                pdfCell3.VerticalAlignment = Element.ALIGN_CENTER;

                pdfCell1.Border = 0;
                pdfCell2.Border = 0;
                pdfCell3.Border = 0;
                //add all three cells into PdfTable
                pdfTab.AddCell(pdfCell1);
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
                Phrase pie = new Phrase("Especialistas en el sector de la construcción", FontFactory.GetFont("verdana", 8));
                Phrase pie2 = new Phrase("Pagina  " + writer.PageNumber, FontFactory.GetFont("verdana", 8));
                //Phrase usu = new Phrase("" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), FontFactory.GetFont("verdana", 8));
                //create iTextSharp.text Image object using local image path
                //imgPDF.Width = 10;
                //Create PdfTable object
                PdfPTable pdffo = new PdfPTable(2);
                //We will have to create separate cells to include image logo and 2 separate strings
                PdfPCell pdfCel2 = new PdfPCell(pie);
                PdfPCell pdfCel3 = new PdfPCell(pie2);
                //PdfPCell pdfCel4 = new PdfPCell(usu);
                //set the alignment of all three cells and set border to 0
                pdfCel2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCel2.PaddingLeft=20f;
                pdfCel3.HorizontalAlignment = Element.ALIGN_RIGHT;
                pdfCel3.PaddingRight = 15f;
                pdfCel2.VerticalAlignment = Element.ALIGN_BOTTOM;
                pdfCel3.VerticalAlignment = Element.ALIGN_CENTER;
                //pdfCel4.HorizontalAlignment = Element.ALIGN_CENTER;
                //pdfCel4.VerticalAlignment = Element.ALIGN_BOTTOM;
                pdfCel2.Border = 0;
                pdfCel3.Border = 0;
                //pdfCel4.Border = 0;
                //add all three cells into PdfTable
                pdffo.AddCell(pdfCel2);
                //pdffo.AddCell(pdfCel4);
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
