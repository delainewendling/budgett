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
    public class UserController : Controller
    {
        private BudgettContext _context;

        public UserController(BudgettContext ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> users = from user in _context.User select user;

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                User user = _context.User.Single(m => m.UserId == id);

                if (user == null)
                {
                    return NotFound();
                }
                
                return Ok(user);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.User.Add(user);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.UserId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
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

        private bool UserExists(int id)
        {
            return _context.User.Count(e => e.UserId == id) > 0;
        }

    }
}