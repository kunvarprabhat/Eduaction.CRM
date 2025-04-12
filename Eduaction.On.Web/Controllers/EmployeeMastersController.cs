using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eduaction.DataModel;
using Eduaction.DataModel.DataModels;
using Eduaction.BusinessLogic.Abstract;
using Eduaction.BusinessLogic.Concrete;

namespace Eduaction.On.Web.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly ILoginInfoRepository _loginRepo;
        public EmployeeMastersController(IEmployeeRepository employeeRepo, ILoginInfoRepository loginRepo)
        {
            _employeeRepo = employeeRepo;
            _loginRepo = loginRepo;
        }

        // GET: EmployeeMasters
        public async Task<IActionResult> Index()
        {
            var result = await this._employeeRepo.GetAllEmployee();
            return View(result);
        }

        //// GET: EmployeeMasters/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeeMaster = await _context.EmployeeMasters
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employeeMaster == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employeeMaster);
        //}

        // GET: EmployeeMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(EmployeeMaster model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var data = _employeeRepo.CreateEmployee(model).Result;
        //        if (data > 0)
        //            return RedirectToAction(nameof(Index));
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "Operation failed! Please try again");
        //            return View(model);
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "Please enter valid data");
        //        return View(model);
        //    }
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeMaster employee)
        {
           
                await _employeeRepo.CreateEmployee(employee);
                TempData["message"] = "Employee Created Successfuly !";
                return RedirectToAction(nameof(Index));
            return View(employee);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var editModel = await _employeeRepo.GetEmployeeById(id);
            //await LoadCustomer();
            return View(editModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeMaster employee)
        {
            if (id != employee.Id)
            {
                ModelState.AddModelError(string.Empty, "Invalid employee ID.");
                return View(employee);
            }
            if (!ModelState.IsValid)
            {
                try
                {
                    employee.ModifiedDate = DateTime.Now;
                    employee.ModifiedBy = 1;
                    var updatedEmployee = await _employeeRepo.UpdateEmployee(id, employee);
                    if (updatedEmployee != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Operation failed! Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please enter valid data.");
            }
            return View(employee);
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var item = await _employeeRepo.GetEmployeeById(id);

        //        var item = _DBContext.Employees.Find(id);
        //        if (item != null)
        //        {
        //            item.IsActive = false;
        //            _DBContext.Employees.Update(item);
        //            _DBContext.SaveChanges();
        //            return Json(new { success = true });
        //        }
        //        return Json(new { success = false, message = "Item not found" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = ex.Message });
        //    }
        //}



        // POST: EmployeeMasters/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
        //    if (employeeMaster != null)
        //    {
        //        _context.EmployeeMasters.Remove(employeeMaster);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeMasterExists(int id)
        //{
        //    return _context.EmployeeMasters.Any(e => e.Id == id);
        //}
    }
}
