using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.StaffListWork.Entity;

namespace DAL.StaffListWork.EF
{
    public class StaffContext: DbContext
    {
        public DbSet<Employee> Staff { get; set; }
        public StaffContext()
        {
           Database.SetInitializer<StaffContext>(new StoreDbInitializer());
        }
         public StaffContext(string con)
            :base(con)
        {
        }
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StaffContext>
        {
            protected override void Seed(StaffContext db)
            {
                db.Staff.Add(new Employee { FirstName = "One", LastName = "Two", Position="Pos", Salary=300.0});
                db.Staff.Add(new Employee { FirstName = "One1", LastName = "Two1", Position = "Pos1", Salary = 300.0 });
                db.Staff.Add(new Employee { FirstName = "One2", LastName = "Two2", Position = "Pos0", Salary = 300.0 });
                db.SaveChanges();
            }
        }
    }
}
