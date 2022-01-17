using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Model.ViewModel
{
    public class ClienteViewModel
    {
        public int ClienteID {get; set;}
        public int ClienteDepartamentoIDFK { get; set; }
        public string ClienteNombre {get; set;}
        public string ClienteDireccion {get; set;}
        public string ClienteDepartamento {get; set;}
        public string ClienteCondicionPago {get; set;}
        public int ClienteDiasCredito {get; set;}
        public string ClienteNumRegistro {get; set;}
        public string ClienteNumNit {get; set;}
        public string ClienteGiro { get; set; }
    }
}
