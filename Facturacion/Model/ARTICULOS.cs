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
    
    public partial class ARTICULOS
    {
        public ARTICULOS()
        {
            this.FACTURAS_DETALLE = new HashSet<FACTURAS_DETALLE>();
        }
    
        public int id_articulo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> existencia { get; set; }
    
        public virtual ICollection<FACTURAS_DETALLE> FACTURAS_DETALLE { get; set; }
    }
}
