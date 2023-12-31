﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Web.Data;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Drivers;
using AutoMapper;

namespace MB.SimTaxi.Web.Controllers
{
    public class DriversController : Controller
    {
        #region Data and Const

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DriversController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var drivers = await _context
                                    .Drivers
                                    .Include(driver => driver.Country)
                                    .ToListAsync();

            var driverVMs = _mapper.Map<List<Driver>, List<DriverListViewModel>>(drivers);

            var driverPageVM = new DriverPageViewModel();
            driverPageVM.Drivers = driverVMs;

            // TODO get list of unassigned cars FOMR THE DATABASE and put them into driverPageVM.CarsLookUp
            driverPageVM.CarSelectList = await GetCarsLookupAsync();

            return View(driverPageVM);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context
                                    .Drivers
                                    .Include(driver => driver.Country)
                                    .Include(driver => driver.Cars)
                                    .FirstOrDefaultAsync(m => m.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, DriverDetailsViewModel>(driver);

            return View(driverVM);
        }

        public async Task<IActionResult> CreateAsync()
        {
            ViewData["countries"] = new SelectList(_context.Countries, "Id", "Name");

            List<Car> cars = await _context
                                .Cars
                                .Where(car => car.DriverId == null)
                                .ToListAsync();

            ViewData["cars"] = new SelectList(cars, "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUpdateDriverViewModel driverVM)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<CreateUpdateDriverViewModel, Driver>(driverVM);

                await AddCarToDriver(driverVM, driver);

                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", driverVM.CountryId);

            return View(driverVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Drivers == null)
            {
                return NotFound();
            }

            var driver = await _context
                                .Drivers
                                .Include(driver => driver.Cars)
                                .SingleAsync(driver => driver.Id == id);

            if (driver == null)
            {
                return NotFound();
            }

            var driverVM = _mapper.Map<Driver, CreateUpdateDriverViewModel>(driver);
            
            
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", driver.CountryId);

            driverVM.CarId = driver.Cars[0].Id;
            ViewData["cars"] = new SelectList(_context.Cars, "Id", "Title", driverVM.CarId);

            return View(driverVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateUpdateDriverViewModel driverVM)
        {
            if (id != driverVM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var driver = _mapper.Map<CreateUpdateDriverViewModel, Driver>(driverVM);

                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driverVM.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", driverVM.CountryId);
            return View(driverVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context
                                    .Drivers
                                    .FindAsync(id);

            if (driver != null)
            {
                _context.Drivers.Remove(driver);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> UnassignCar(int driverId, int carId)
        {
            var driver = await _context
                                .Drivers
                                .FindAsync(driverId);
            
            var car = await _context
                                .Cars
                                .FindAsync(carId);

            driver.Cars.Remove(car);

            _context.Update(driver);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = driverId });
        }

        [HttpPost]
        public async Task<IActionResult> AssignCarToDriver(int driverId, List<int> carIds)
        {
            var driver = await _context
                                .Drivers
                                .FindAsync(driverId);

            var cars = await _context
                                .Cars
                                .Where(car => carIds.Contains(car.Id)) // 9, 10
                                .ToListAsync();

            driver.Cars.AddRange(cars);

            _context.Update(driver);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool DriverExists(int id)
        {
            return (_context.Drivers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task AddCarToDriver(CreateUpdateDriverViewModel driverVM, Driver driver)
        {
            var car = await _context.Cars.FindAsync(driverVM.CarId);
            driver.Cars.Add(car);
        }

        private async Task<MultiSelectList> GetCarsLookupAsync()
        {
            var carsLookup = await _context
                                    .Cars
                                    .Where(car => car.DriverId == null)
                                    .ToListAsync();

            var carSelectList = new MultiSelectList(carsLookup, "Id", "Title");

            return carSelectList;
        }

        #endregion
    }
}
