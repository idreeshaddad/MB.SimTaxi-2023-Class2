using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Web.Data;
using MB.SimTaxi.Web.Data.Entities;
using AutoMapper;
using MB.SimTaxi.Web.Models.FuelTypes;

namespace MB.SimTaxi.Web.Controllers
{
    public class FuelTypesController : Controller
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FuelTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions
        public async Task<IActionResult> Index()
        {
            // 1- Get the list of fuel types
            var fuelTypes = await _context
                                        .FuelTypes
                                        .ToListAsync();

            // 2- Transform into a List<ViewModel>
            var ftVMs = _mapper.Map<List<FuelType>, List<FuelTypeViewModel>>(fuelTypes);

            // 3- Return to the view
            return View(ftVMs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context
                                    .FuelTypes
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (fuelType == null)
            {
                return NotFound();
            }

            var ftVM = _mapper.Map<FuelType, FuelTypeViewModel>(fuelType);

            return View(ftVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FuelTypeViewModel fuelTypeVM)
        {
            if (ModelState.IsValid)
            {
                var fuelType = _mapper.Map<FuelTypeViewModel, FuelType>(fuelTypeVM); 

                _context.Add(fuelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(fuelTypeVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context
                                    .FuelTypes
                                    .FindAsync(id);

            if (fuelType == null)
            {
                return NotFound();
            }

            var ftVM = _mapper.Map<FuelType, FuelTypeViewModel>(fuelType);

            return View(ftVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FuelTypeViewModel fuelTypeVM)
        {
            if (id != fuelTypeVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuelType = _mapper.Map<FuelTypeViewModel, FuelType>(fuelTypeVM);

                    _context.Update(fuelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelTypeExists(fuelTypeVM.Id))
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

            return View(fuelTypeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelType = await _context
                                    .FuelTypes
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (fuelType == null)
            {
                return NotFound();
            }

            var ftVM = _mapper.Map<FuelType, FuelTypeViewModel>(fuelType);

            return View(ftVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuelType = await _context.FuelTypes.FindAsync(id);

            if (fuelType != null)
            {
                _context.FuelTypes.Remove(fuelType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool FuelTypeExists(int id)
        {
            return (_context.FuelTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        } 

        #endregion
    }
}
