using EmployeeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public interface IEmpInterface
    {
        List<EmpModelApi> Index();
        bool Create(EmpModelApi emp);
        EmpModelApi Edit(int id);
        void Delete(int id);

    }
    public abstract class EmpAbs : IEmpInterface
    {
        public abstract bool Create(EmpModelApi emp);

        public abstract void Delete(int id);

        public abstract EmpModelApi Edit(int id);

        public abstract List<EmpModelApi> Index();
    }

    public class EmpRepository : EmpAbs
    {
        private readonly EmpContext db;
        public EmpRepository(EmpContext db)
        {
            this.db = db;
        }
        public override bool Create(EmpModelApi emp)
        {

            if (emp == null)
            {
                return false;
            }
            else
            {
                if (emp.id == 0)
                {
                    db.tblEmployee.Add(emp);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
        }

        public override void Delete(int id)
        {
            var emp =  db.tblEmployee.Find(id);
            if (emp != null)
            {
                db.tblEmployee.Remove(emp);
                db.SaveChanges();
            }
        }

        public override EmpModelApi Edit(int id)
        {
            var a = db.tblEmployee.Find(id);
            return a;
        }

        public override List<EmpModelApi> Index()
        {
            return db.tblEmployee.ToList();
        }
    }
}
