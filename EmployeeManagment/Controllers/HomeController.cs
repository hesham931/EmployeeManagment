using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Modual;

namespace EmployeeManagment.Controllers
{
    public class HomeController : Controller
    {
        private IRepesetoryEmployee _employee;

        public HomeController(IRepesetoryEmployee employee)
        {
            _employee = employee;
        }
        [Route("~/")]
        public ViewResult Index()
        {
            var model = _employee.GetAllEmployee();
            ViewBag.PageTitle = "Home Page";
            return View(model);
        }
        [Route("getInformation/id={id}")]
        public ViewResult SingleEmployee(int id)
        {
            Employee model = _employee.GetEmployee(id);
            ViewBag.pageTitle = model.Name + " || Information";
            return View("SingleEmployee", model);
        }
        [Route("Employee/Setting/Add_New_Employee")]
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.pageTitle = "Add Employee";
            return View("Create");
        }
        [Route("Build")]
        [Route("HomePage.aspx/Build")]
        [HttpPost]
        public RedirectToActionResult Build(Employee employee)
        {
            Employee newEmployee = _employee.AddNew(employee);
            return RedirectToAction("SingleEmployee", new { id = newEmployee.Id });
        }
        [Route("EditPage.aspx/id={id}")]
        public ViewResult Edit(int id) {
            Employee UpdatedEmployee = _employee.GetEmployee(id);

            ViewBag.pageTitle = UpdatedEmployee.Name + " || Edit inforamtion";
            return View("Edit", UpdatedEmployee);
        }
        [Route("EnableUpdate/id={id}")]
        public RedirectToActionResult EnableUpdate(Employee employee)
        {
            _employee.EditEmployee(employee);
            return RedirectToAction("SingleEmployee", new { id = employee.Id});
        }
        [Route("DeleteEmployee/{id}")]
        public RedirectToActionResult DeleteEmployee(int id)
        {
            Employee employee = _employee.GetEmployee(id);
            _employee.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}