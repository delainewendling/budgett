using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budgett.Models;
using Budgett.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace budgett.Controllers
{
    public class LocationController : Controller
    {
        private BudgettContext _context;

        public LocationController(BudgettContext ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> locations = from transaction in _context.Transaction select transaction;

            if (locations == null)
            {
                return NotFound();
            }

            return Ok(locations);
        }

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Location location = _context.Location.Single(m => m.LocationId == id);

                if (location == null)
                {
                    return NotFound();
                }
                
                return Ok(location);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody] Location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Location.Add(location);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LocationExists(location.LocationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetLocation", new { id = location.LocationId }, location);
        }

        // PUT /transactions
    //     [HttpPut("{id}")]
    //     public IActionResult Put(int id, [FromBody] Transaction transaction)
    //     {
    //         if (!ModelState.IsValid)
    //         {
    //             return BadRequest(ModelState);
    //         }

    //         if (id != transaction.TransactionId)
    //         {
    //             return BadRequest();
    //         }

    //         _context.Entry(transaction).State = EntityState.Modified;

    //         try
    //         {
    //             _context.SaveChanges();
    //         }
    //         catch (DbUpdateConcurrencyException)
    //         {
    //             if (!TransactionExists(id))
    //             {
    //                 return NotFound();
    //             }
    //             else
    //             {
    //                 throw;
    //             }
    //         }

    //         return new StatusCodeResult(StatusCodes.Status204NoContent);
    //     }

    //     [HttpDelete("{id}")]
    //     public IActionResult Delete(int id)
    //     {
    //         if (!ModelState.IsValid)
    //         {
    //             return BadRequest(ModelState);
    //         }

    //         Transaction transaction = _context.Transaction.Single(m => m.TransactionId == id);
    //         if (transaction == null)
    //         {
    //             return NotFound();
    //         }

    //         _context.Transaction.Remove(transaction);
    //         _context.SaveChanges();

    //         return Ok(transaction);
    //     }

        private bool LocationExists(int id)
        {
            return _context.Location.Count(e => e.LocationId == id) > 0;
        }

    }
}