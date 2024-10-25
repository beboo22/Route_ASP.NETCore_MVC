using LinkDev._1stProj.BLL.Services.DepartmentServ;
using Microsoft.AspNetCore.Mvc;
using LinkDev._1stProj.BLL.Entity.DeptEntity;
using Microsoft.AspNetCore.Authorization;




namespace LinkDev._1stProj.PL.Controllers.DepartmentController
{
	[Authorize]
	public class DepartmentController : Controller
    {
        private readonly IServicesDepartment _ServDep;

        public DepartmentController( IServicesDepartment services)
        { 
            _ServDep = services;
        }

        // GET: /Department
        public IActionResult Index()
        {
            ///var departments = _departmentService.GetAllDepartments();
            ///return View(departments);
            
            var departments = _ServDep.GetAllDepartments();
            return View(departments); 
        }
        // GET: /Department/Details/5
        public IActionResult Details(int id)
        {
            var department = _ServDep.GetDepartmentsById(id);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }


        // GET: /Department/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: /Department/Create
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                _ServDep.CreatedDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: /Department/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id is null) 
                return BadRequest();
            var department = _ServDep.GetDepartmentsById(id.Value);
            if (department is null)
            {
                return NotFound();
            }

            var updateDto = new UpdateDepartmentDto
            {
                ID = department.ID,
                Name = department.Name,
                code = department.code,
                Description = department.Description,
                CreationDate = department.CreationDate,
                LastModifiedOn = DateTime.Now // Set LastModifiedOn as needed
            };

            return View(updateDto);
        }

        // POST: /Department/Edit/5
        [HttpPost]
        public IActionResult Edit(UpdateDepartmentDto department)
        {
            if (ModelState.IsValid)
            {
                _ServDep.UpdateDepartment(department);
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: /Department/Delete/5
        public IActionResult Delete(int id)
        {
            var department = _ServDep.GetDepartmentsById(id);
            if (department is null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_ServDep.DeleteDepartment(id))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound(); // Handle the case where deletion fails
        }

    }
}
