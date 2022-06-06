using EmployeeAPI.Model;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    
    public class EmpAPI : Controller
    {
        private readonly EmpRepository repo;
        public EmpAPI(EmpRepository _repo)
        {
            this.repo = _repo;
        }
        [HttpGet]
        public List<EmpModelApi> Index()
        {
            return repo.Index();
        }
        [HttpPost]
        public bool Create(EmpModelApi emp)
        {
            return repo.Create(emp);
        }
        [HttpGet]
        public EmpModelApi Edit(int Id)
        {
            return repo.Edit(Id);            
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
