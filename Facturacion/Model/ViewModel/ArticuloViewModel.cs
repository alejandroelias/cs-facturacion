using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Model.ViewModel
{
    public class ArticuloViewModel
    {
        public int ArticuloID    {get;set;}
        public string ArticuloDescripcion {get;set;}
        public int ArticuloExistencia { get; set; }
    }
}
