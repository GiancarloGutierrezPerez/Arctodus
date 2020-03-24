using Arctodus.Models.Viewmodel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Arctodus.Utilidades.Documentos
{
    public class Pdf
    {
        public static byte[] CreatePdf(List<Folio> folios)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document(PageSize.LETTER))
                {
                    PdfWriter pdfWriter = PdfWriter.GetInstance(document, ms);

                    // pdfWriter.AddViewerPreference(PdfName.PRINTSCALING,new PdfNumber(90));

                    document.Open();

                    Font font = FontFactory.GetFont("Calibri", 10.5f);
                    Font font2 = FontFactory.GetFont("Arial", 10f, iTextSharp.text.Font.BOLD);


                    document.AddTitle("Folios");
                    document.AddCreationDate();
                    document.AddAuthor("Sistema Arctodus");

                    //Ancho de Columnas
                    float[] ColumnsWidth = { 25f, 25f, 12f, 15f, 70f, 60f, 30f };

                    //Contadores
                    int contadorRegistros = 0;
                    int RowCountBackgroundColor = 0;

                    //Se Inicializa primer tabla
                    PdfPTable table = null;

                    if (folios != null && folios.Count > 0)
                    {
                        foreach (Folio f in folios)
                        {

                            contadorRegistros++;
                            RowCountBackgroundColor++;

                            //Primer Tabla
                            if (contadorRegistros == 1)
                            {
                                table = new PdfPTable(7);
                                table.SetWidths(ColumnsWidth);
                                table.TotalWidth = 237f;
                                table.LockedWidth = true;

                                //Encabezado

                                AddCellToTable(table, "NS", font2, 3, true);
                                AddCellToTable(table, "C", font2, 1, false);
                                AddCellToTable(table, "COLOR", font2, 1, false);
                                AddCellToTable(table, "Fecha", font2, 1, false);
                                AddCellToTable(table, "NPE", font2, 1, false);

                            }

                            BaseColor baseColor = null;

                            //Escirbe el folio en la tabla
                            if (RowCountBackgroundColor <= 10)
                            {
                                baseColor = new BaseColor(231, 230, 230, 150);

                            }
                            else if (RowCountBackgroundColor == 20)
                            {
                                RowCountBackgroundColor = 0;
                            }

                            AddCellToTable(table, f.Lote.ToString(), font, 1, false, baseColor);
                            AddCellToTable(table, f.ContadorLote.ToString(), font, 1, false, baseColor);
                            AddCellToTable(table, f.Homoclave.ToString(), font, 1, false, baseColor);
                            AddCellToTable(table, "", font, 1, false, baseColor);
                            AddCellToTable(table, f.Color_Producto, font, 1, false, baseColor);
                            AddCellToTable(table, "", font, 1, false, baseColor);
                            AddCellToTable(table, f.Contador.ToString(), font, 1, false, baseColor);

                            if ((contadorRegistros == folios.Count && contadorRegistros < 100 && contadorRegistros < 50) || (contadorRegistros % 50 == 0 && contadorRegistros % 100 != 0))
                            {
                                table.WriteSelectedRows(0, -1, document.Left, document.Top , pdfWriter.DirectContent);

                            }
                            else if (contadorRegistros == folios.Count && contadorRegistros % 100 > 50)
                            {
                                table.WriteSelectedRows(0, -1, document.Left + 275, document.Top , pdfWriter.DirectContent);

                            }
                            else if (contadorRegistros == folios.Count && contadorRegistros % 100 <= 50)
                            {
                                table.WriteSelectedRows(0, -1, document.Left, document.Top , pdfWriter.DirectContent);

                            }


                            if (((contadorRegistros % 100) + 1) == 51)
                            {
                                RowCountBackgroundColor = 0;

                                table = new PdfPTable(7);
                                table.SetWidths(ColumnsWidth);
                                table.TotalWidth = 237f;
                                table.LockedWidth = true;

                                //Encabezado
                                AddCellToTable(table, "NS", font2, 3, true);
                                AddCellToTable(table, "C", font2, 1, false);
                                AddCellToTable(table, "COLOR", font2, 1, false);
                                AddCellToTable(table, "Fecha", font2, 1, false);
                                AddCellToTable(table, "NPE", font2, 1, false);

                            }

                            if (contadorRegistros % 100 == 0)
                            {
                                table.WriteSelectedRows(0, -1, document.Left + 275, document.Top , pdfWriter.DirectContent);

                                document.NewPage();

                                RowCountBackgroundColor = 0;


                                document.Add(new Paragraph("Texto"));
                                document.Add(new Paragraph("Texto"));


                                table = new PdfPTable(7);
                                table.SetWidths(ColumnsWidth);
                                table.TotalWidth = 237f;
                                table.LockedWidth = true;



                                //Encabezado Tabla

                                AddCellToTable(table, "NS", font2, 3, true);
                                AddCellToTable(table, "C", font2, 1, false);
                                AddCellToTable(table, "COLOR", font2, 1, false);
                                AddCellToTable(table, "Fecha", font2, 1, false);
                                AddCellToTable(table, "NPE", font2, 1, false);




                            }


                        }


                    }






                }
                byte[] d;
                //byte [] d = AddWatermark(ms.ToArray(), BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), "Confidencial");

                d = ms.ToArray();
                return d;
            }
        }

        public static void AddCellToTable(PdfPTable table, string text, Font font, int Colspan, bool AlingCenter, BaseColor BackgroundColor = null)
        {
            Phrase pharse = new Phrase(text, font);

            PdfPCell cell = new PdfPCell(pharse);

            if (AlingCenter)
            {
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
            }

            if (BackgroundColor != null)
            {
                cell.BackgroundColor = BackgroundColor;

            }

            cell.Colspan = Colspan;

            table.AddCell(cell);
        }

        private static byte[] AddWatermark(byte[] bytes, BaseFont baseFont, string watermarkText)
        {
            using (var ms = new MemoryStream(10 * 1024))
            {
                using (var reader = new PdfReader(bytes))
                using (var stamper = new PdfStamper(reader, ms))
                {
                    var pages = reader.NumberOfPages;
                    for (var i = 1; i <= pages; i++)
                    {
                        var dc = stamper.GetUnderContent(i);
                        AddWaterMarkText(dc, watermarkText, baseFont, 75, 45, BaseColor.GRAY, reader.GetPageSizeWithRotation(i));
                    }
                    stamper.Close();
                }
                return ms.ToArray();
            }
        }

        public static void AddWaterMarkText(PdfContentByte pdfData, string watermarkText, BaseFont font, float fontSize, float angle, BaseColor color, Rectangle realPageSize)
        {
            var gstate = new PdfGState { FillOpacity = 1f, StrokeOpacity = 0.3f };
            pdfData.SaveState();
            pdfData.SetGState(gstate);
            pdfData.SetColorFill(color);
            pdfData.BeginText();
            pdfData.SetFontAndSize(font, fontSize);
            var x = (realPageSize.Right + realPageSize.Left) / 2;
            var y = (realPageSize.Bottom + realPageSize.Top) / 2;
            pdfData.ShowTextAligned(Element.ALIGN_CENTER, watermarkText, x, y, angle);
            pdfData.EndText();
            pdfData.RestoreState();
        }

    }
}