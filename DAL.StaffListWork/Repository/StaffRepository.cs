using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.StaffListWork.Repository;
using DAL.StaffListWork.Entity;
using DAL.StaffListWork.EF;
using DAL.StaffListWork.Interface;

namespace DAL.StaffListWork.Repository
{
    public class StaffRepository : IRepository<Employee>
    {
        private StaffContext db ;
        public StaffRepository()
        {
            this.db = new StaffContext();
        }
        public void Create(Employee item)
        {
          db.Staff.Add(item);
          db.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee em = db.Staff.Find(id);
            if (em != null)
            {
                db.Staff.Remove(em);
            }
            db.SaveChanges();
        }

       
        public IEnumerable<Employee> Find(Func<Employee, bool> func)
        {
            return db.Staff.Where(func).ToList();
        }

        public Employee Get(int? id)
        {
            return db.Staff.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Staff;
        }

        public void Update(Employee item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
