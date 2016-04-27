using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class Tickets_RespuestaHelper
    {
        public static Tickets_Respuesta ToModel(this TICKETS_RESPUESTA Table)
        {
            if (Table == null) return null;

            return new Tickets_Respuesta()
            {
                IdPregunta = Table.IdPregunta,
                IdTickets = Table.IdTickets,
                Respuesta = Table.Respuesta
            };
        }

        public static TICKETS_RESPUESTA ToTable(this Tickets_Respuesta Model)
        {
            if (Model == null) return null;

            return new TICKETS_RESPUESTA()
            {
                IdPregunta = Model.IdPregunta,
                IdTickets = Model.IdTickets,
                Respuesta = Model.Respuesta
            };
        }

        public static List<Tickets_Respuesta> ToModels(IEnumerable<TICKETS_RESPUESTA> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Tickets_Respuesta> GetAll()
        {
            List<Tickets_Respuesta> result = new List<Tickets_Respuesta>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.TICKETS_RESPUESTA.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Tickets_Respuesta>();

            }

            return result;
        }

        public static Tickets_Respuesta GetTicket_RespuestaByPrimaryKey(int idPregunta, int idTickets)
        {
            Tickets_Respuesta result = new Tickets_Respuesta();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.TICKETS_RESPUESTA.SingleOrDefault(x => x.IdPregunta == idPregunta && x.IdTickets == idTickets);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Tickets_Respuesta Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.TICKETS_RESPUESTA.Add(Model.ToTable());

                try
                {
                    context.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;

                }

            }

            return result;
        }
    }
}
