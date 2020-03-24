using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arctodus.Models.Viewmodel
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string usuario1 { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> idRol { get; set; }
        public virtual rol rol { get; set; }
    }
}