using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel__Itenerary2.Server.Data;
using Travel__Itenerary2.Server.IRepository;
using Travel__Itenerary2.Shared.Domain;

namespace Travel__Itenerary2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FlightsController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public FlightsController(ApplicationDbContext context)
        public FlightsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Flights
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetFlights()
        {
            //return await _context.Flights.ToListAsync();
            var flights = await _unitOfWork.Flight.GetAll();
            return Ok(flights);
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetFlights(int id)
        {
            var flights = await _unitOfWork.Flight.Get(q => q.Id == id);

            if (flights == null)
            {
                return NotFound();
            }

            //
            return Ok(flights);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlights(int id, Flights flights)
        {
            if (id != flights.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(flights).State = EntityState.Modified;
            _unitOfWork.Flight.Update(flights);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!FlightsExists(id))
                if (!await FlightsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flights>> PostFlights(Flights flights)
        {
            //_context.Flights.Add(flights);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Flight.Insert(flights);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetFlights", new { id = flights.Id }, flights);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlights(int id)
        {
            var flights = await _unitOfWork.Flight.Get(q => q.Id == id);
            if (flights == null)
            {
                return NotFound();
            }

            //
            //_context.Flights.Remove(flights);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Flight.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> FlightsExists(int id)
        {
            //
            //return _context.Flights.Any(e => e.Id == id);

            var flights = await _unitOfWork.Flight.Get(q => q.Id == id);
            return flights != null;
        }
    }
}
