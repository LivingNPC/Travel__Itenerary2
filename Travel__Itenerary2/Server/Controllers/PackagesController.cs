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

    public class PackagesController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public PackagesController(ApplicationDbContext context)
        public PackagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Packages
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetPackages()
        {
            //return await _context.Packages.ToListAsync();
            var Packages = await _unitOfWork.Packages.GetAll();
            return Ok(Packages);
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetPackages(int id)
        {
            var Packages = await _unitOfWork.Packages.Get(q => q.Id == id);

            if (Packages == null)
            {
                return NotFound();
            }

            //
            return Ok(Packages);
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackages(int id, Package Packages)
        {
            if (id != Packages.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(Packages).State = EntityState.Modified;
            _unitOfWork.Packages.Update(Packages);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!PackagesExists(id))
                if (!await PackagesExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackages(Package Packages)
        {
            //_context.Packages.Add(Packages);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Packages.Insert(Packages);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPackages", new { id = Packages.Id }, Packages);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackages(int id)
        {
            var Packages = await _unitOfWork.Packages.Get(q => q.Id == id);
            if (Packages == null)
            {
                return NotFound();
            }

            //
            //_context.Packages.Remove(Packages);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Packages.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> PackagesExists(int id)
        {
            //
            //return _context.Packages.Any(e => e.Id == id);

            var Packages = await _unitOfWork.Packages.Get(q => q.Id == id);
            return Packages != null;
        }
    }
}