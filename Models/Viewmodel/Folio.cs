using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arctodus.Models.Viewmodel
{
    public class Folio
    {
        public int Lote { get; set; }
        public int ContadorLote { get; set; }
        public int Homoclave { get; set; }
        public string Color_Producto { get; set; }       
        public int Contador { get; set; }
    }
}