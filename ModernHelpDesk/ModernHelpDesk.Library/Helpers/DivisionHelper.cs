using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class DivisionHelper
    {
        public static Division ToModel(this DIVISION Table)
        {
            if (Table == null) return null;

            return new Division()
            {
                Id = Table.Id,
                Descripcion = Table.Descripcion,
                departamentoId = Table.departamentoId,
                Fecha_Creacion = Table.Fecha_Creacion
            };
        }

        public static DIVISION ToTable(this Division Model)
        {
            if (Model == null) return null;

            return new DIVISION()
            {
                Id = Model.Id,
                Descripcion = Model.Descripcion,
                departamentoId = Model.departamentoId,
                Fecha_Creacion = Model.Fecha_Creacion
            };
        }

        public static List<Division> ToModels(IEnumerable<DIVISION> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Division> GetAll()
        {
            List<Division> result = new List<Division>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.DIVISION.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Division>();

            }

            return result;
        }

        public static Division GetDivisionByPrimaryKey(int id)
        {
            Division result = new Division();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.DIVISION.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Division Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.DIVISION.Add(Model.ToTable());

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
