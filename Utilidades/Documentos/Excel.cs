using Arctodus.Models.Viewmodel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace Arctodus.Utilidades.Documentos
{
    public class Excel
    {
        public static byte[] CrearExcelFolios(List<Folio> folios)
        {
            byte[] FileBytesArray = { };

            try
            {

                using (ExcelPackage excelPackage = new ExcelPackage())
                {




                    //Set some properties of the Excel document
                    excelPackage.Workbook.Properties.Author = "Sistema Arctodus";
                    excelPackage.Workbook.Properties.Title = "Folios";
                    excelPackage.Workbook.Properties.Subject = "";
                    excelPackage.Workbook.Properties.Created = DateTime.Now;

                    //Create the WorkSheet
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Folios");

                    worksheet.PrinterSettings.PaperSize = ePaperSize.Letter;
                    worksheet.PrinterSettings.LeftMargin = 0.71M;
                    worksheet.PrinterSettings.RightMargin = 0.71M;
                    worksheet.PrinterSettings.TopMargin = 0.75M;
                    worksheet.PrinterSettings.BottomMargin = 0.75M;
                    worksheet.PrinterSettings.HeaderMargin = 0.31M;
                    worksheet.PrinterSettings.FooterMargin = 0.31M;

                    worksheet.PrinterSettings.Scale = 85;

                    worksheet.Column(1).Width = GTCW(3.29);
                    worksheet.Column(2).Width = GTCW(3.00);
                    worksheet.Column(3).Width = GTCW(1.29);
                    worksheet.Column(4).Width = GTCW(1.43);
                    worksheet.Column(5).Width = GTCW(8.57);
                    worksheet.Column(6).Width = GTCW(9.14);
                    worksheet.Column(7).Width = GTCW(3.57);

                    worksheet.Column(8).Width = GTCW(3.29);
                    worksheet.Column(9).Width = GTCW(4.71);

                    worksheet.Column(10).Width = GTCW(3.29);
                    worksheet.Column(11).Width = GTCW(3.00);
                    worksheet.Column(12).Width = GTCW(1.29);
                    worksheet.Column(13).Width = GTCW(1.43);
                    worksheet.Column(14).Width = GTCW(8.57);
                    worksheet.Column(15).Width = GTCW(9.14);
                    worksheet.Column(16).Width = GTCW(3.57);

                    int fila = 4;
                    int columna = 1;
                    int contadorRegistros = 0;
                    int RowCountBackgroundColor = 0;

                    if (folios != null && folios.Count > 0)
                    {

                        foreach (Folio f in folios)
                        {
                            if (contadorRegistros % 100 == 0 || contadorRegistros % 50 == 0 || contadorRegistros == 0)
                            {
                                if (contadorRegistros % 100 == 0 && contadorRegistros != 0)
                                {
                                    columna = 1;
                                    fila = fila + 5;
                                    worksheet.Row(fila + 51).PageBreak = true;

                                    //BorderDraw(worksheet,"A" + Convert.ToString(fila - 1), "G" + Convert.ToString(fila + 49));

                                    RowCountBackgroundColor = 0;

                                }
                                else if (contadorRegistros % 50 == 0 && contadorRegistros != 0 && contadorRegistros % 100 != 0)
                                {
                                    columna = 10;
                                    fila = fila - 50;
                                    worksheet.Row(fila + 51).PageBreak = true;
                                    worksheet.Row(fila + 51 - 3).PageBreak = false;
                                    worksheet.Row(fila + 51 - 2).PageBreak = false;
                                    //BorderDraw(worksheet,"J" + Convert.ToString(fila - 1), "P" + Convert.ToString(fila + 49));
                                    RowCountBackgroundColor = 0;
                                }

                                worksheet.Cells[fila - 1, columna].Value = "NS";
                                worksheet.Cells[fila - 1, columna + 3].Value = "C";
                                worksheet.Cells[fila - 1, columna + 4].Value = "COLOR";
                                worksheet.Cells[fila - 1, columna + 5].Value = "Fecha";
                                worksheet.Cells[fila - 1, columna + 6].Value = "NPE";

                                worksheet.Column(16).PageBreak = true;
                                worksheet.Row(55).PageBreak = true;

                            }

                            worksheet.Cells.Style.Numberformat.Format = "@";

                            worksheet.Cells[fila, columna].Value = f.Lote;               //1
                            worksheet.Cells[fila, columna + 1].Value = f.ContadorLote;   //2
                            worksheet.Cells[fila, columna + 2].Value = f.Homoclave;     //3
                                                                                        //4
                            worksheet.Cells[fila, columna + 4].Value = f.Color_Producto;// 5
                                                                                        // 6                            
                            worksheet.Cells[fila, columna + 6].Value = f.Contador;      // 7

                            BorderCellDraw(worksheet, fila, columna);
                            BorderCellDraw(worksheet, fila, columna + 1);
                            BorderCellDraw(worksheet, fila, columna + 2);
                            BorderCellDraw(worksheet, fila, columna + 3);
                            BorderCellDraw(worksheet, fila, columna + 4);
                            BorderCellDraw(worksheet, fila, columna + 5);
                            BorderCellDraw(worksheet, fila, columna + 6);

                            if (RowCountBackgroundColor < 10)
                            {
                                worksheet.Cells[fila, columna].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[fila, columna].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));
                                worksheet.Cells[fila, columna + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[fila, columna + 1].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));
                                worksheet.Cells[fila, columna + 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[fila, columna + 2].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));
                                worksheet.Cells[fila, columna + 3].Style.Fill.PatternType = ExcelFillStyle.Solid;                                                                                       //4
                                worksheet.Cells[fila, columna + 3].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));                                                                                         //4
                                worksheet.Cells[fila, columna + 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[fila, columna + 4].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));
                                worksheet.Cells[fila, columna + 5].Style.Fill.PatternType = ExcelFillStyle.Solid;                                                                               // 6                            
                                worksheet.Cells[fila, columna + 5].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));                                                                                          // 6                            
                                worksheet.Cells[fila, columna + 6].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[fila, columna + 6].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(231, 230, 230));

                            }
                            else if (RowCountBackgroundColor == 20)
                            {
                                RowCountBackgroundColor = 0;
                            }



                            fila++;
                            contadorRegistros++;
                            RowCountBackgroundColor++;



                        }

                    }


                    worksheet.HeaderFooter.OddFooter.RightAlignedText = "Página " + "&p" + "de " + "&N";



                    FileBytesArray = excelPackage.GetAsByteArray();
                }

            }
            catch (Exception ex)
            {

            }
            return FileBytesArray;
        }


        //GetTrueColumnWidth
        private static double GTCW(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }

        private static void BorderDraw(ExcelWorksheet ws, string incio, string fin)
        {
            ExcelRange excelRange = ws.Cells[incio + ":" + fin];


            excelRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            excelRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;


        }

        private static void BorderCellDraw(ExcelWorksheet ws, int fila, int columna)
        {
            ws.Cells[fila, columna].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[fila, columna].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[fila, columna].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            ws.Cells[fila, columna].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

    }
}