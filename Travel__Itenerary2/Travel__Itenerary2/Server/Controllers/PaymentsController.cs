﻿using System;
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

    public class PaymentsController : ControllerBase
    {
        //Refractored
        //private readonly
        private readonly IUnitOfWork _unitOfWork;

        //public PaymentsController(ApplicationDbContext context)
        public PaymentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Payments
        [HttpGet]
        //refractored
        public async Task<IActionResult> GetPayments()
        {
            //return await _context.Payments.ToListAsync();
            var Payments = await _unitOfWork.Payment.GetAll(includes: q => q.Include(x => x.Bookings).Include(x => x.Staff));
            return Ok(Payments);
        }

        

        // GET: api/Payments/5
        [HttpGet("{id}")]
        //refractored
        //
        public async Task<IActionResult> GetPayments(int id)
        {
            var Payments = await _unitOfWork.Payment.Get(q => q.Id == id);

            if (Payments == null)
            {
                return NotFound();
            }

            //
            return Ok(Payments);
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayments(int id, Payments Payments)
        {
            if (id != Payments.Id)
            {
                return BadRequest();
            }

            //

            //_context.Entry(Payments).State = EntityState.Modified;
            _unitOfWork.Payment.Update(Payments);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //
                //if (!PaymentsExists(id))
                if (!await PaymentsExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Payments>> PostPayments(Payments Payments)
        {
            //_context.Payments.Add(Payments);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Payment.Insert(Payments);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPayments", new { id = Payments.Id }, Payments);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            var Payments = await _unitOfWork.Payment.Get(q => q.Id == id);
            if (Payments == null)
            {
                return NotFound();
            }

            //
            //_context.Payments.Remove(Payments);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Payment.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        //
        //
        private async Task<bool> PaymentsExists(int id)
        {
            //
            //return _context.Payments.Any(e => e.Id == id);

            var Payments = await _unitOfWork.Payment.GetAll();
            return Payments != null;
        }
    }
}
