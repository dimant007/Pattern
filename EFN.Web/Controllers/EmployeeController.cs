using EFN.Database;
using EFN.Database.Entity;
using EFN.Services.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EFN.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            //empList = db.Employees.ToList();

            IEmployeeService EmployeeService = new EmployeeService(db);
            var empList = await EmployeeService.GetList();

            return View("Employee", "_Layout", empList);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEmployeeService EmployeeService = new EmployeeService(db);
            var empDet = await EmployeeService.GetItem(id);

            return View(empDet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            try
            {
                IEmployeeService EmployeeService = new EmployeeService(db);
                await EmployeeService.Insert(employee);
                return RedirectToAction("Index");
            }
            catch
            {

                throw;
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            IEmployeeService EmployeeService = new EmployeeService(db);
            var empEdit = await EmployeeService.GetItem(id);
            return View(empEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            try
            {
                IEmployeeService EmployeeService = new EmployeeService(db);
                await EmployeeService.Update(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            IEmployeeService EmployeeService = new EmployeeService(db);
            var empDelete = await EmployeeService.GetItem(id);
            return View(empDelete);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                IEmployeeService EmployeeService = new EmployeeService(db);
                await EmployeeService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {

                throw;
            }
        }        
    }
}