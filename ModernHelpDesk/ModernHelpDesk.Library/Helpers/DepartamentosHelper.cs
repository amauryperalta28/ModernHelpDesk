using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class DepartamentosHelper
    {
        public static Departamentos ToModel(this DEPARTAMENTOS Table)
        {
            if (Table == null) return null;

            return new Departamentos() {
            
                Id = Table.Id,
                Descripcion = Table.Descripcion,
                Fecha_Creacion = Table.Fecha_Creacion
            };
        
        }

        public static DEPARTAMENTOS ToTable(this Departamentos Model)
        {
            if (Model == null) return null;

            return new DEPARTAMENTOS()
            {
            
                Id = Model.Id,
                Descripcion = Model.Descripcion,
                Fecha_Creacion = Model.Fecha_Creacion
            };
        
        }

        public static List<Departamentos> ToModels(IEnumerable<DEPARTAMENTOS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Departamentos> GetAll()
        {
            List<Departamentos> result = new List<Departamentos>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.DEPARTAMENTOS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Departamentos>();
                
            }

            return result;
        }

        public static Departamentos GetDepartamentoByPrimaryKey(int id)
        {
            Departamentos result = new Departamentos();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.DEPARTAMENTOS.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Departamentos Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.DEPARTAMENTOS.Add(Model.ToTable());

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
