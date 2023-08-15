using AutoMapper;
using MB.SimTaxi.Web.Data;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Cars;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MB.SimTaxi.Web.Controllers
{
    //[Authorize]
    public class CarsController : Controller
    {
        #region Data and Constructors 

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CarsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            List<Car> cars = _context
                                .Cars
                                .Include(car => car.FuelType)
                                .Include(car => car.Driver)
                                .ToList();

            var carsVM = _mapper.Map<List<Car>, List<CarListViewModel>>(cars);

            return View(carsVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .Include(car => car.Driver)
                                .Include(car => car.FuelType)
                                .FirstOrDefaultAsync(m => m.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car, CarDetailsViewModel>(car);

            return View(carVM);
        }

        public IActionResult Create()
        {
            var carVM = new CreateUpdateCarViewModel();
            carVM.DriversSelectList = new SelectList(_context.Drivers, "Id", "FullName");
            carVM.FuelTypesSelectList = new SelectList(_context.FuelTypes, "Id", "Name");

            return View(carVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUpdateCarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                var car = _mapper.Map<Car>(carVM);

                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            carVM.DriversSelectList = new SelectList(_context.Drivers, "Id", "FullName", carVM.DriverId);
            carVM.FuelTypesSelectList = new SelectList(_context.FuelTypes, "Id", "Name", carVM.FuelTypeId);

            return View(carVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context
                                .Cars
                                .FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var carVM = _mapper.Map<Car, CreateUpdateCarViewModel>(car);
            carVM.DriversSelectList = new SelectList(_context.Drivers, "Id", "FullName", car.DriverId);
            carVM.FuelTypesSelectList = new SelectList(_context.FuelTypes, "Id", "Name", car.FuelTypeId);

            return View(carVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateUpdateCarViewModel carVM)
        {
            if (id != carVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var car = _mapper.Map<CreateUpdateCarViewModel, Car>(carVM);

                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(carVM.Id))
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

            carVM.DriversSelectList = new SelectList(_context.Drivers, "Id", "FullName", carVM.DriverId);
            carVM.FuelTypesSelectList = new SelectList(_context.FuelTypes, "Id", "Name", carVM.FuelTypeId);

            return View(carVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cars == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cars == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cars'  is null.");
            }
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool CarExists(int id)
        {
            return (_context.Cars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}
