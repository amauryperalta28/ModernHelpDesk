//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/04/26 - 19:49:25
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModernHelpDesk.Common.Models
{
    [DataContract()]
    public partial class Usuarios
    {
        [DataMember()]
        public Int32 id { get; set; }

        [DataMember()]
        public String PrimerNombre { get; set; }

        [DataMember()]
        public String SegundoNombre { get; set; }

        [DataMember()]
        public String PrimerApellido { get; set; }

        [DataMember()]
        public String SegundoApellido { get; set; }

        [DataMember()]
        public DateTime Fecha_creacion { get; set; }

        [DataMember()]
        public List<Int32> TICKETS_Id { get; set; }

        [DataMember()]
        public Int32 USER_FOLLOWED_USER_UserID { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(Int32 id, String primerNombre, String segundoNombre, String primerApellido, String segundoApellido, DateTime fecha_creacion, List<Int32> tICKETS_Id, Int32 uSER_FOLLOWED_USER_UserID)
        {
			this.id = id;
			this.PrimerNombre = primerNombre;
			this.SegundoNombre = segundoNombre;
			this.PrimerApellido = primerApellido;
			this.SegundoApellido = segundoApellido;
			this.Fecha_creacion = fecha_creacion;
			this.TICKETS_Id = tICKETS_Id;
			this.USER_FOLLOWED_USER_UserID = uSER_FOLLOWED_USER_UserID;
        }
    }
}
