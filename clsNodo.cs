using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechStore
{
    internal class clsNodo
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }
        private clsNodo sig;
        private clsNodo ant;
        private clsNodo inic;

        public clsNodo Siguiente
        {
            get { return sig; }
            set { sig = value; }
        }
        public clsNodo Anterior
        {
            get { return ant; }
            set { ant = value; }
        }

        public clsNodo Inicio
        {
            get { return inic; }
            set { inic = value; }
        }
    }
}
