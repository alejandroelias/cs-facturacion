//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facturacion.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTES
    {
        public CLIENTES()
        {
            this.FACTURAS = new HashSet<FACTURAS>();
        }
    
        public int id_cliente { get; set; }
        public Nullable<int> fk_id_depart { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string condicion_pago { get; set; }
        public Nullable<int> dias_credito { get; set; }
        public string num_registro { get; set; }
        public string num_nit { get; set; }
        public string giro { get; set; }
    
        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
        public virtual ICollection<FACTURAS> FACTURAS { get; set; }
    }
}
