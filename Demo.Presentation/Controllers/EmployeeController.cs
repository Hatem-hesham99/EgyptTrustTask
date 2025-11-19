using Demo.BusinessLogic.Dtos;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index(string? EmployeeSearchName ,int PageNo=1)
        {
            var data = _employeeService.GetAll(EmployeeSearchName);
            ViewBag.search = EmployeeSearchName;

            int NoOfRecouredPerPage = 3;

            int totalRecords = data.Count(); 
            int NoOfPages = (int)Math.Ceiling((double)totalRecords / NoOfRecouredPerPage);
            int NoOfReecoresToSkip = (PageNo-1)* NoOfRecouredPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            data = data.Skip(NoOfReecoresToSkip).Take(NoOfRecouredPerPage).ToList();

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _employeeService.CreatEmp(employeeDto);
                    if (result > 0)
                        return RedirectToAction("Index");
                    else
                    {


                        ModelState.AddModelError("", "Employee not added");

                    }
                }
                catch (Exception ex)
                {
                   
                }

            }
            return View("Create", employeeDto);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var data = _employeeService.GetById(id.Value);
            return data is not null ? View(data) : NotFound();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var emp = _employeeService.GetById(id.Value);
            if (emp is null) return NotFound();
            var data = new UpdateEmployeeDto
            {
                Address = emp.Address,
                Age = emp.Age,
                Email = emp.Email,
                HiringDate = emp.HireDate,
                Id = emp.Id,
                IsActive = emp.IsActive,
                Name = emp.Name,
                PhoneNumber = emp.PhoneNumber,
                Salary = emp.Salary,
                EmployeeType = Enum.Parse<EmployeeType>(emp.EmployeeType),
            };

            return View(data);
        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, UpdateEmployeeDto updateEmployeeDto)
        {
            if (!id.HasValue || id.Value != updateEmployeeDto.Id) return BadRequest();
            if (ModelState.IsValid)
            {
                var result = _employeeService.UpdateEmp(updateEmployeeDto);
                if (result > 0) return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "employee not update");
            }
            return View(updateEmployeeDto);

        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int id)
        {
            var re = _employeeService.DeleteEmp(id);
            return RedirectToAction("Index");
        }
    }
}
