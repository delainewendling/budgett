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
    public class ActionController : Controller
    {
        private BudgettContext _context;

        public ActionController(BudgettContext ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> accounts = from account in _context.Account select account;

            if (accounts == null)
            {
                return NotFound();
            }

            return Ok(accounts);
        }

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Account account = _context.Account.Single(m => m.AccountId == id);

                if (account == null)
                {
                    return NotFound();
                }
                
                return Ok(account);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Account.Add(account);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AccountExists(account.AccountId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetAccount", new { id = account.AccountId }, account);
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

        private bool AccountExists(int id)
        {
            return _context.Account.Count(e => e.AccountId == id) > 0;
        }

    }
}