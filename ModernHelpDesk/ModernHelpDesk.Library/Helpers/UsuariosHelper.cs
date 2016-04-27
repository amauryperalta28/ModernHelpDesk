using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class UsuariosHelper
    {
        public static Usuarios ToModel(this USUARIOS Table)
        {
            if (Table == null) return null;

            return new Usuarios()
            {

                id = Table.id,
                PrimerNombre = Table.PrimerNombre,
                SegundoNombre = Table.SegundoNombre,
                PrimerApellido = Table.PrimerApellido,
                SegundoApellido = Table.SegundoApellido,
                Fecha_creacion = Table.Fecha_creacion

            };
        }

        public static USUARIOS ToTable(this Usuarios Model)
        {
            if (Model == null) return null;

            return new USUARIOS()
            {

                id = Model.id,
                PrimerNombre = Model.PrimerNombre,
                SegundoNombre = Model.SegundoNombre,
                PrimerApellido = Model.PrimerApellido,
                SegundoApellido = Model.SegundoApellido,
                Fecha_creacion = Model.Fecha_creacion

            };
        }

        public static List<Usuarios> ToModels(IEnumerable<USUARIOS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Usuarios> GetAll()
        {
            List<Usuarios> result = new List<Usuarios>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USUARIOS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Usuarios>();

            }

            return result;
        }

        public static Usuarios GetUsuarioByPrimaryKey(int id)
        {
            Usuarios result = new Usuarios();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USUARIOS.SingleOrDefault(x => x.id == id);
                result = queryResult.ToModel();
            }

            return result;
        }

        public static bool UserExist(int id)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var count = context.USUARIOS.Count(x => x.id == id);
                if (count > 0)
                {
                    result = true;
                }

            }

            return result;
        }

        public static bool Save(Usuarios Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.USUARIOS.Add(Model.ToTable());

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

