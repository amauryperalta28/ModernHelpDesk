//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/04/26 - 19:49:17
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
    public partial class Estatus
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        [DataMember()]
        public List<Int32> TICKETS_Id { get; set; }

        public Estatus()
        {
        }

        public Estatus(Int32 id, String descripcion, List<Int32> tICKETS_Id)
        {
			this.Id = id;
			this.Descripcion = descripcion;
			this.TICKETS_Id = tICKETS_Id;
        }
    }
}
