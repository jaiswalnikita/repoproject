using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Model
{
    public class EmpContext :DbContext
    {
        public EmpContext(DbContextOptions<EmpContext>options):base(options)
        {

        }

        public DbSet<EmpModelApi> tblEmployee { get; set; }
    }
}
