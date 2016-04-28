using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class UsuariosSeguidosHelper
    {
        public static User_Followed_User ToModel(this USER_FOLLOWED_USER Table)
        {
            if (Table == null) return null;

            return new User_Followed_User()
            {
                UserID = Table.UserID,
                UserIdFollowed = Table.UserIdFollowed,
                Fecha_Creacion = Table.Fecha_Creacion
            };
        }

        public static USER_FOLLOWED_USER ToTable(this User_Followed_User Model)
        {
            if (Model == null) return null;

            return new USER_FOLLOWED_USER()
            {
                UserID = Model.UserID,
                UserIdFollowed = Model.UserIdFollowed,
                Fecha_Creacion = Model.Fecha_Creacion
            };
        }

        public static List<User_Followed_User> ToModels(IEnumerable<USER_FOLLOWED_USER> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<User_Followed_User> GetAll()
        {
            List<User_Followed_User> result = new List<User_Followed_User>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USER_FOLLOWED_USER.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<User_Followed_User>();

            }

            return result;
        }

        public static bool IsFollowingUsers(int UserId)
        {
            bool result = false;

            using (HelpDeskApfEntities context= new HelpDeskApfEntities())
            {
                var count = context.USER_FOLLOWED_USER.Count(x => x.UserID == UserId);

                if (count >0)
                {
                    result = true;
                }
                
            }
            return result;
        }

        public static User_Followed_User GetUserFollowedByPrimaryKey(int UserId)
        {
            User_Followed_User result = new User_Followed_User();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.USER_FOLLOWED_USER.SingleOrDefault(x => x.UserID == UserId );

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(User_Followed_User Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.USER_FOLLOWED_USER.Add(Model.ToTable());

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
