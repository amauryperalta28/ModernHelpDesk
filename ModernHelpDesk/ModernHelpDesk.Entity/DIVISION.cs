//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModernHelpDesk.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class DIVISION
    {
        public DIVISION()
        {
            this.TICKETS = new HashSet<TICKETS>();
        }
    
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int departamentoId { get; set; }
        public System.DateTime Fecha_Creacion { get; set; }
    
        public virtual DEPARTAMENTOS DEPARTAMENTOS { get; set; }
        public virtual ICollection<TICKETS> TICKETS { get; set; }
    }
}
