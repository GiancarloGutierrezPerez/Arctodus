using System.Collections.Generic;
using System.Web.Mvc;
using Arctodus.Models.Viewmodel;
using Arctodus.Utilidades;
using Arctodus.Utilidades.Documentos;

namespace Arctodus.Controllers
{
    public class FolioController : Controller
    {
        // GET: Folio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Modificar()
        {
            return View();
        }
        public ActionResult Consultar()
        {

            List<eFile> Files = new List<eFile>();

            #region Excel

            eFile f_excel = new eFile();
            List<Folio> folios = new List<Folio>();

            for (int i = 0; i < 274; i++)
            {
                Folio folio = new Folio();

                folio.Lote = 114;
                folio.ContadorLote = 683;
                folio.Color_Producto = "GRISP";
                folio.Contador = i + 1;

                folios.Add(folio);
            }

            f_excel.FileStream = Excel.CrearExcelFolios(folios);
            f_excel.FileName = "folios.xlsx";
            Files.Add(f_excel);
            //return File(FileBytesArray, "application/xlsx", "Folios" + ".xlsx");
            #endregion


            eFile f_pdf = new eFile();
            f_pdf.FileStream = Pdf.CreatePdf(folios);
            f_pdf.FileName = "folios.pdf";
            Files.Add(f_pdf);



            byte[] FileBytesArray;
            FileBytesArray = Zip.CreateZip(Files);

            //return File(FileBytesArray, "pdf/application", "Folios" + ".pdf");

            return File(FileBytesArray, "application/octet-stream", "Folios.zip");

        }

        [HttpPost]
        public ActionResult GenerarFolios()
        {



            return Json("");
        }



    }
}