using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RentalsController(IMapper mapper)
        {
            _context = new ApplicationDbContext();
            _mapper = mapper;
        }

        [HttpGet]
        public IHttpActionResult GetRentals(int id)
        {
            var rentals = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .Where(r => r.Customer.Id == id).ToList();

            if (rentals == null || rentals.Count == 0)
            {
                return BadRequest("No rentals found");
            }

            var rentalDtos = rentals
                .Select(_mapper.Map<Rental, RentalDto>);

            return Ok(rentalDtos);

        }

        //[HttpGet]
        //public IHttpActionResult GetRental(int customerId, int movieId)
        //{
        //    var rentals = _context.Rentals
        //        .Include(r => r.Movie)
        //        .Include(r => r.Customer)
        //        .Where(r => r.Customer.Id == customerId && r.Movie.Id == movieId).ToList();

        //    if (rentals == null || rentals.Count == 0)
        //    {
        //        return BadRequest("No rentals found");
        //    }

        //    var rentalDtos = rentals
        //        .Select(_mapper.Map<Rental, RentalDto>);

        //    return Ok(rentalDtos);

        //}

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto rentalDto)
        {
            if (rentalDto == null || rentalDto.MovieIds.Count == 0)
            {
                return BadRequest("No movies given");
            }

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            if(customer == null)
            {
                return BadRequest("CustomerId is not valid");
            }

            var rentals = _context.Rentals
                .Where(r => r.Customer.Id == rentalDto.CustomerId && r.DateReturned == null).ToList();

            var count = rentals.Count();
            if (count == 5)
            {
                return BadRequest("You have reached the maximum of 5 rentals.");
            }

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if(movies.Count != rentalDto.MovieIds.Count)
            {
                return BadRequest("Not all movies found");
            }

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest(movie.Name + " is not available");
                }

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                if(count < 5)
                    _context.Rentals.Add(rental);
                else
                {
                    _context.SaveChanges();
                    return BadRequest("You have reached the maximum of 5 rentals.");
                }

                count += 1;
                movie.NumberAvailable -= 1;
            }

            _context.SaveChanges();
            return Ok();
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateRental(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var RentalInDb = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .SingleOrDefault(r => r.Id == id);

            if (RentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            if (RentalInDb.DateReturned != null)
                return Ok();

            ++RentalInDb.Movie.NumberAvailable;
            RentalInDb.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Rentals.Remove(rentalInDb);
            _context.SaveChanges();
        }
    }
}
