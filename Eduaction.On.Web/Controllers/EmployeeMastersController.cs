using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eduaction.DataModel;
using Eduaction.DataModel.DataModels;

namespace Eduaction.On.Web.Controllers
{
    public class EmployeeMastersController : Controller
    {
        private readonly EducationDbContext _context;

        public EmployeeMastersController(EducationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeMasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeMasters.ToListAsync());
        }

        // GET: EmployeeMasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,EmpCode,EmailId,MobileNo,Remark,AddedBy,AddedDate,ModifiedBy,ModifiedDate,Ipaddress,IsActive")] EmployeeMaster employeeMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster == null)
            {
                return NotFound();
            }
            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,EmpCode,EmailId,MobileNo,Remark,AddedBy,AddedDate,ModifiedBy,ModifiedDate,Ipaddress,IsActive")] EmployeeMaster employeeMaster)
        {
            if (id != employeeMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMasterExists(employeeMaster.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMaster);
        }

        // GET: EmployeeMasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeMaster = await _context.EmployeeMasters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMaster == null)
            {
                return NotFound();
            }

            return View(employeeMaster);
        }

        // POST: EmployeeMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeMaster = await _context.EmployeeMasters.FindAsync(id);
            if (employeeMaster != null)
            {
                _context.EmployeeMasters.Remove(employeeMaster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMasterExists(int id)
        {
            return _context.EmployeeMasters.Any(e => e.Id == id);
        }
    }
}
