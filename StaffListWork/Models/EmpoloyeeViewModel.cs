using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StaffListWork.Models
{
    public class EmpoloyeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public int? IdHead { get; set; }
        public string NameHeader { get; set; }


    }
}