//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_GO2inkas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reserva()
        {
            this.EncuestaSatisfaccion = new HashSet<EncuestaSatisfaccion>();
        }
    
        public int CODIGO { get; set; }
        public string archivo { get; set; }
        public string tipo_de_tour { get; set; }
        public Nullable<System.DateTime> fecha_de_tour { get; set; }
        public string orden_de_compra { get; set; }
        public string tipo_de_bicicleta { get; set; }
        public string numero_de_operacion { get; set; }
        public Nullable<decimal> costo_de_tour { get; set; }
        public Nullable<int> numero_de_paz { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> detraccion { get; set; }
        public Nullable<System.DateTime> fecha_de_pago { get; set; }
        public string ConfirmacionID { get; set; }
    
        public virtual Confirmacion Confirmacion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EncuestaSatisfaccion> EncuestaSatisfaccion { get; set; }
    }
}
