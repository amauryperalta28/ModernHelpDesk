using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class UserGroupHelper
    {
        public static User_Groups ToModel(this USER_GROUPS Table)
        {
            if (Table == null) return null;

            return new User_Groups()
            {
                UserId = Table.UserId,
                GroupId = Table.GroupId
            };
        }

        public static USER_GROUPS ToTable(this User_Groups Model)
        {
            if (Model == null) return null;

            return new USER_GROUPS()
            {
                UserId = Model.UserId,
                GroupId = Model.GroupId
            };
        }

        public static List<User_Groups> ToModels(IEnumerable<USER_GROUPS> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<User_Groups> GetAll()
        {
            List<User_Groups> result = new List<User_Groups>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USER_GROUPS.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<User_Groups>();

            }

            return result;
        }

        public static User_Groups GetGruposByPrimaryKey(int UserId, int GroupId)
        {
            User_Groups result = new User_Groups();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USER_GROUPS.SingleOrDefault(x => x.UserId == UserId &&
                                                                                 x.GroupId == GroupId);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(User_Groups Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.USER_GROUPS.Add(Model.ToTable());

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
