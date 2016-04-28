using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class TicketsHelper
    {
        public static Tickets ToModel(this TICKETS Table)
        {
            if (Table == null) return null;

            return new Tickets()
            {
                Id = Table.Id,
                DestinationDivisionId = Table.DestinationDivisionId,
                IssueId = Table.IssueId,
                OrganizacionId = Table.OrganizacionId,
                RequestDepartamentId = Table.RequestDepartamentId,
                UserRequestId = Table.UserRequestId,
                Estatus = Table.Estatus,
                Fecha_Correcion = Table.Fecha_Correcion,
                Fecha_Modificacion = Table.Fecha_Modificacion,
                Fecha_Solicitud = Table.Fecha_Solicitud
            };
        }

        public static TICKETS ToTable(this Tickets Model)
        {
            if (Model == null) return null;

            return new TICKETS()
            {
                Id = Model.Id,
                DestinationDivisionId = Model.DestinationDivisionId,
                IssueId = Model.IssueId,
                OrganizacionId = Model.OrganizacionId,
                RequestDepartamentId = Model.RequestDepartamentId,
                UserRequestId = Model.UserRequestId,
                Estatus = Model.Estatus,
                Fecha_Correcion = Model.Fecha_Correcion,
                Fecha_Modificacion = Model.Fecha_Modificacion,
                Fecha_Solicitud = Model.Fecha_Solicitud
            };
        }

        public static List<Tickets> ToModels(IEnumerable<TICKETS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Tickets> GetAll()
        {
            List<Tickets> result = new List<Tickets>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.TICKETS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Tickets>();

            }

            return result;
        }

        public static bool Exists(int id)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var count = context.TICKETS.Count(x => x.Id == id);

                if (count > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public static Tickets GetTicketByPrimaryKey(int id)
        {
            Tickets result = new Tickets();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.TICKETS.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Tickets Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.TICKETS.Add(Model.ToTable());

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
