using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StaffListWork.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public  string LastName { get; set; }
        public double Salary { get; set; }
        public string Position { get; set; }
        public int? IdHead { get; set; }

    }
}
