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
    
    public partial class USUARIOS
    {
        public USUARIOS()
        {
            this.TICKETS = new HashSet<TICKETS>();
        }
    
        public int id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public System.DateTime Fecha_creacion { get; set; }
    
        public virtual ICollection<TICKETS> TICKETS { get; set; }
        public virtual USER_FOLLOWED_USER USER_FOLLOWED_USER { get; set; }
    }
}
