using AutoMapper;
using MB.SimTaxi.Web.Data;
using MB.SimTaxi.Web.Data.Entities;
using MB.SimTaxi.Web.Models.Countries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MB.SimTaxi.Web.Controllers
{
    //[Authorize]
    public class CountriesController : Controller
    {
        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var countries = await _context
                                    .Countries
                                    .ToListAsync();

            var countriesVM = _mapper.Map<List<Country>, List<CountryViewModel>>(countries);

            return View(countriesVM);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var country = await _context
                                    .Countries
                                    .SingleOrDefaultAsync(country => country.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            var countryVM = _mapper.Map<Country, CountryViewModel>(country);

            return View(countryVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryViewModel countryVM)
        {
            // TODO check if country name already exists in the database
            //ModelState.AddModelError("EXISTS", "Country Name already exists");
            
            if (ModelState.IsValid)
            {
                var country = _mapper.Map<CountryViewModel, Country>(countryVM);

                _context.Add(country);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(countryVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Countries == null)
            {
                return NotFound();
            }

            var country = await _context
                                    .Countries
                                    .FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryVM = _mapper.Map<Country, CountryViewModel>(country);

            return View(countryVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CountryViewModel countryVM)
        {
            if (id != countryVM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var country = _mapper.Map<CountryViewModel, Country>(countryVM);

                    _context.Update(country);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(countryVM.Id))
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

            return View(countryVM);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country != null)
            {
                _context.Countries.Remove(country);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Methods

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }

        #endregion
    }
}
