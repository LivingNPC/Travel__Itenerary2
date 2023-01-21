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

    public class CustomersController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public CustomersController(ApplicationDbContext context)
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customers
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetCustomers()
        {
            //return await _context.Customers.ToListAsync();
            var Customers = await _unitOfWork.Customers.GetAll();
            return Ok(Customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetCustomers(int id)
        {
            var Customers = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (Customers == null)
            {
                return NotFound();
            }

            //
            return Ok(Customers);
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers Customers)
        {
            if (id != Customers.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(Customers).State = EntityState.Modified;
            _unitOfWork.Customers.Update(Customers);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!CustomersExists(id))
                if (!await CustomersExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customers>> PostCustomers(Customers Customers)
        {
            //_context.Customers.Add(Customers);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Customers.Insert(Customers);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomers", new { id = Customers.Id }, Customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            var Customers = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (Customers == null)
            {
                return NotFound();
            }

            //
            //_context.Customers.Remove(Customers);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> CustomersExists(int id)
        {
            //
            //return _context.Customers.Any(e => e.Id == id);

            var Customers = await _unitOfWork.Customers.Get(q => q.Id == id);
            return Customers != null;
        }
    }
}
