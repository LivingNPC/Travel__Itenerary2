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

    public class StaffsController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public StaffsController(ApplicationDbContext context)
        public StaffsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Staffs
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetStaffs()
        {
            //return await _context.Staffs.ToListAsync();
            var Staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(Staffs);
        }

        // GET: api/Staffs/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetStaffs(int id)
        {
            var Staffs = await _unitOfWork.Staffs.Get(q => q.Id == id);

            if (Staffs == null)
            {
                return NotFound();
            }

            //
            return Ok(Staffs);
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffs(int id, Staff Staffs)
        {
            if (id != Staffs.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(Staffs).State = EntityState.Modified;
            _unitOfWork.Staffs.Update(Staffs);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!StaffsExists(id))
                if (!await StaffsExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaffs(Staff Staffs)
        {
            //_context.Staffs.Add(Staffs);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Staffs.Insert(Staffs);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaffs", new { id = Staffs.Id }, Staffs);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffs(int id)
        {
            var Staffs = await _unitOfWork.Staffs.Get(q => q.Id == id);
            if (Staffs == null)
            {
                return NotFound();
            }

            //
            //_context.Staffs.Remove(Staffs);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> StaffsExists(int id)
        {
            //
            //return _context.Staffs.Any(e => e.Id == id);

            var Staffs = await _unitOfWork.Staffs.Get(q => q.Id == id);
            return Staffs != null;
        }
    }
}