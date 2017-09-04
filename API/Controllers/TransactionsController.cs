using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budgett.Models;
using Budgett.Data;

namespace budgett.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {

        private BudgettContext _context;

        public TransactionsController() { }

        public TransactionsController(BudgettContext ctx)
        {
            _context = ctx;
        }

        public async Task<IActionResult> Index()
        {
            return View(_context.Transaction.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaction);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(transaction);
        }

    }
}



       