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
    public class CategoryController : Controller
    {
        private BudgettContext _context;

        public CategoryController(BudgettContext ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> categories = from category in _context.Category select category;

            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Category category = _context.Category.Single(m => m.CategoryId == id);

                if (category == null)
                {
                    return NotFound();
                }
                
                return Ok(category);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Category.Add(category);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CategoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetCategory", new { id = category.CategoryId }, category);
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

        private bool CategoryExists(int id)
        {
            return _context.Category.Count(e => e.CategoryId == id) > 0;
        }

    }
}