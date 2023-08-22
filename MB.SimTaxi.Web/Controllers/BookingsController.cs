using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MB.SimTaxi.Web.Data;
using MB.SimTaxi.Web.Data.Entities;
using AutoMapper;
using MB.SimTaxi.Web.Models.Bookings;

namespace MB.SimTaxi.Web.Controllers
{
    public class BookingsController : Controller
    {
        #region Data and constructor

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookingsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> Index()
        {
            var bookings = await _context
                                    .Bookings
                                    .ToListAsync();

            var bookingVMs = _mapper.Map<List<BookingListViewModel>>(bookings);

            return View(bookingVMs);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        public IActionResult Create()
        {
            var bookingVM = new CreateUpdateBookingViewModel();

            bookingVM.CarSelectList = new SelectList(_context.Cars, "Id", "Title");
            bookingVM.DriverSelectList = new SelectList(_context.Drivers, "Id", "FullName");
            bookingVM.PassengerMultiselectList = new MultiSelectList(_context.Passengers, "Id", "FullName");

            bookingVM.PickupDateTime = DateTime.Now;

            return View(bookingVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUpdateBookingViewModel bookingVM)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Booking>(bookingVM);

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            bookingVM.CarSelectList = new SelectList(_context.Cars, "Id", "Title", bookingVM.CarId);
            bookingVM.DriverSelectList = new SelectList(_context.Drivers, "Id", "FullName", bookingVM.DriverId);
            bookingVM.PassengerMultiselectList = new MultiSelectList(_context.Passengers, "Id", "FullName", bookingVM.PassengerIds);

            return View(bookingVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", booking.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", booking.DriverId);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PickupDateTime,From,To,Price,CarId,DriverId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "Id", "Id", booking.CarId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", booking.DriverId);
            return View(booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Car)
                .Include(b => b.Driver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Private Functions

        private bool BookingExists(int id)
        {
            return (_context.Bookings?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion
    }
}
