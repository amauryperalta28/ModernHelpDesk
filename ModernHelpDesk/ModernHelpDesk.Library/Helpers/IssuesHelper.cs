using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
   public static class IssuesHelper
    {
       public static Issues ToModel(this ISSUES Table)
       {
           if (Table == null) return null;

           return new Issues() { 
            Id = Table.Id,
            Descripcion = Table.Descripcion,
            Fecha_Creacion = Table.Fecha_Creacion
           };
       }

       public static ISSUES ToTable(this Issues Model)
       {
           if (Model == null) return null;

           return new ISSUES()
           {
               Id = Model.Id,
               Descripcion = Model.Descripcion,
               Fecha_Creacion = Model.Fecha_Creacion
           };
       }

       public static List<Issues> ToModels(IEnumerable<ISSUES> Entities)
       {
           if (Entities == null) return null;

           return Entities.Select(x => x.ToModel()).ToList();
       }

       public static List<Issues> GetAll()
       {
           List<Issues> result = new List<Issues>();

           using (HelpDeskApfEntities context = new HelpDeskApfEntities())
           {
               var queryResult = context.ISSUES.ToList();
               result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Issues>();

           }

           return result;
       }

       public static Issues GetIssueByPrimaryKey(int id)
       {
           Issues result = new Issues();

           using (HelpDeskApfEntities context = new HelpDeskApfEntities())
           {
               var queryResult = context.ISSUES.SingleOrDefault(x => x.Id == id);

               if (queryResult != null)
               {
                   result = queryResult.ToModel();
               }
           }

           return result;
       }

       public static bool Save(Issues Model)
       {
           bool result = false;

           using (HelpDeskApfEntities context = new HelpDeskApfEntities())
           {
               context.ISSUES.Add(Model.ToTable());

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
