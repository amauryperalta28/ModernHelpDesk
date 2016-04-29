using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModernHelpDesk.Web.Models
{
    public class DropDownListModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public DropDownListModel(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public DropDownListModel(string description)
        {
            this.Id = -1;
            this.Description = description;
        }

        public DropDownListModel(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}