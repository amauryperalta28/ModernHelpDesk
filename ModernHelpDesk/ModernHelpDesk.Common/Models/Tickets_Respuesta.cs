//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/04/26 - 19:49:23
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
    public partial class Tickets_Respuesta
    {
        [DataMember()]
        public Int32 IdTickets { get; set; }

        [DataMember()]
        public Int32 IdPregunta { get; set; }

        [DataMember()]
        public Boolean Respuesta { get; set; }

        public Tickets_Respuesta()
        {
        }

        public Tickets_Respuesta(Int32 idTickets, Int32 idPregunta, Boolean respuesta)
        {
			this.IdTickets = idTickets;
			this.IdPregunta = idPregunta;
			this.Respuesta = respuesta;
        }
    }
}