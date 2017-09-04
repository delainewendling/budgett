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
    public class TransactionsController : Controller
    {
        private BudgettContext _context;

        public TransactionsController(BudgettContext ctx)
        {
            _context = ctx;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<object> transactions = from transaction in _context.Transaction select transaction;

            if (transactions == null)
            {
                return NotFound();
            }

            return Ok(transactions);

        }

        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Transaction transaction = _context.Transaction.Single(m => m.TransactionId == id);

                if (transaction == null)
                {
                    return NotFound();
                }
                
                return Ok(transaction);
            }
            catch (System.InvalidOperationException ex)
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Transaction.Add(transaction);
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TransactionExists(transaction.TransactionId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetTransaction", new { id = transaction.TransactionId }, transaction);
        }

        // PUT /transactions
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Transaction transaction = _context.Transaction.Single(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transaction.Remove(transaction);
            _context.SaveChanges();

            return Ok(transaction);
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Count(e => e.TransactionId == id) > 0;
        }

    }
}