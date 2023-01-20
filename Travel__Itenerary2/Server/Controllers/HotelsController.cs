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

    public class HotelsController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public HotelsController(ApplicationDbContext context)
        public HotelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Hotels
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetHotels()
        {
            //return await _context.Hotels.ToListAsync();
            var Hotels = await _unitOfWork.Hotels.GetAll();
            return Ok(Hotels);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetHotels(int id)
        {
            var Hotels = await _unitOfWork.Hotels.Get(q => q.Id == id);

            if (Hotels == null)
            {
                return NotFound();
            }

            //
            return Ok(Hotels);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotels(int id, Hotels Hotels)
        {
            if (id != Hotels.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(Hotels).State = EntityState.Modified;
            _unitOfWork.Hotels.Update(Hotels);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!HotelsExists(id))
                if (!await HotelsExists(id))
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

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotels>> PostHotels(Hotels Hotels)
        {
            //_context.Hotels.Add(Hotels);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Hotels.Insert(Hotels);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetHotels", new { id = Hotels.Id }, Hotels);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotels(int id)
        {
            var Hotels = await _unitOfWork.Hotels.Get(q => q.Id == id);
            if (Hotels == null)
            {
                return NotFound();
            }

            //
            //_context.Hotels.Remove(Hotels);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Hotels.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> HotelsExists(int id)
        {
            //
            //return _context.Hotels.Any(e => e.Id == id);

            var Hotels = await _unitOfWork.Hotels.Get(q => q.Id == id);
            return Hotels != null;
        }
    }
}
