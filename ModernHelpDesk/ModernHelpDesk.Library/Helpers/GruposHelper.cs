using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class GruposHelper
    {
        public static Grupos ToModel(this GRUPOS Table)
        {
            if (Table == null) return null;

            return new Grupos()
            {
                Id = Table.Id,
                Descripcion = Table.Descripcion,
                Fecha_Creacion = Table.Fecha_Creacion
            };
        }

        public static GRUPOS ToTable(this Grupos Model)
        {
            if (Model == null) return null;

            return new GRUPOS()
            {
                Id = Model.Id,
                Descripcion = Model.Descripcion,
                Fecha_Creacion = Model.Fecha_Creacion
            };
        }

        public static List<Grupos> ToModels(IEnumerable<GRUPOS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Grupos> GetAll()
        {
            List<Grupos> result = new List<Grupos>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.GRUPOS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Grupos>();

            }

            return result;
        }

        public static Grupos GetGruposByPrimaryKey(int id)
        {
            Grupos result = new Grupos();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.GRUPOS.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Grupos Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.GRUPOS.Add(Model.ToTable());

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
