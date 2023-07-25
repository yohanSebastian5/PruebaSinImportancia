using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaSinImportancia.Models
{
    public class Libro
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string autor{ get; set; }
        public string estado { get; set; }
        public string ubicacionFisica { get; set; }
        public string año { get; set; }
        public int idGenero { get; set; }

 



    }
}