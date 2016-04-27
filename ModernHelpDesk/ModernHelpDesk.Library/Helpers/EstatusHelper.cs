using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class EstatusHelper
    {
        public static Estatus ToModel(this ESTATUS Table)
        {
            if (Table == null) return null;

            return new Estatus()
            {
                Id = Table.Id,
                Descripcion = Table.Descripcion
            };
        }

        public static ESTATUS ToTable(this Estatus Model)
        {
            if (Model == null) return null;

            return new ESTATUS()
            {
                Id = Model.Id,
                Descripcion = Model.Descripcion
            };
        }

        public static List<Estatus> ToModels(IEnumerable<ESTATUS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Estatus> GetAll()
        {
            List<Estatus> result = new List<Estatus>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ESTATUS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Estatus>();

            }

            return result;
        }

        public static Estatus GetEstatusByPrimaryKey(int id)
        {
            Estatus result = new Estatus();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ESTATUS.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Estatus Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.ESTATUS.Add(Model.ToTable());

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
