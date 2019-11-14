using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Manage(int id)
        {
            var customerRentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .Where(r => r.Customer.Id == id)
                .ToList();

            return View("Manage", customerRentals);
        }
    }
}