using Microsoft.AspNetCore.Mvc;
using LinkDev._1stProj.BLL.Services.EmployeeServ;
using LinkDev._1stProj.BLL.Entity.EmpEntity;
using LinkDev._1stproj.DAL.Enums;
using LinkDev._1stProj.BLL.Services.DepartmentServ;
using Microsoft.AspNetCore.Authorization;

namespace LinkDev._1stProj.PL.Controllers.EmployeeController
{
	[Authorize]

	public class EmployeeController : Controller
    {
        private IServicesEmployee _empSr;

        public EmployeeController(IServicesEmployee empSr)
        {
            _empSr = empSr;
        }

        public IActionResult Index(string? search)
        {
            var model = _empSr.GetAllEmployees(search??""); // Initialize the model

            //if (!string.IsNullOrEmpty(search))
            //    return PartialView("D:\\.net\\MVC\\session03\\session03\\LinkDev.1stProj.PL\\Views\\Employee\\Partial\\_searchingEmp", model);
            return View(model);
        }

        ///public IActionResult ALL()
        ///{
        ///    var model = _empSr.GetAllEmployees(); // Initialize the model
        ///    return View(model);
        ///    //return View();
        ///}

        public IActionResult Details(int id)
        {
            var model = _empSr.GetEmployeesById(id); // Initialize the model
            return View(model);
            //return View();
        }

        public IActionResult Create([FromServices] IServicesDepartment _Deptsr)
        {
            var model = new CreatedEmployeeeDto(); // Initialize the model
            var depts = _Deptsr.GetAllDepartments();
            if (depts is null)
                return BadRequest();
            ViewData["depts"] = depts;
            return View(model);
            //return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeeDto emp)
        {
            if (ModelState.IsValid)
            {
                _empSr.CreatedEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null)
                return BadRequest();
            var item = _empSr.GetEmployeesById(Id.Value);
            if (item is null)
                return NotFound();
            var EmpUpdate = new UpdateEmoloyeeDto()
            {
                Id = item.ID,
                Name = item.Name,
                salary = item.salary,
                HiringDate = item.HiringDate,
                Adress = item.Adress,
                Age = item.Age,
                IsActive = item.IsActive,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Gender = (Gender)Enum.Parse(typeof(Gender), item.Gender),
                EmployeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), item.EmployeeType),
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };
            
                ViewData["EmpUpdateimage"] = item.image;
                //EmpUpdate.image  = new FormFile(item.image);
            
            return View(EmpUpdate);
        }
        [HttpPost]
        public IActionResult Edit(UpdateEmoloyeeDto Updatedemp)
        {
            if (ModelState.IsValid)
            {
                _empSr.UpdateEmployee(Updatedemp);
                return RedirectToAction(nameof(Index));
            }
            return View(Updatedemp);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_empSr.DeleteEmployee(id))
                return RedirectToAction(nameof(Index));

            return View(Index);
        }
        
        public IActionResult Delete(int id)
        {
            //if (_empSr.DeleteEmployee(id))
            //    return RedirectToAction(nameof(Index));

            var model = _empSr.GetEmployeesById(id);
            if(model is null)
            {
                return NotFound();
            }
            return View(model);
        }
    }
}
