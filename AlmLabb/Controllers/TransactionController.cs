using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmLabb.Business;
using AlmLabb.Business.Interfaces;
using AlmLabb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlmLabb.Controllers
{
    public class TransactionController : Controller
    {
        private IMockDb _context;
        public TransactionController(IMockDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTransaction(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var handler = new TransactionHandler(_context);
                if (model.TransactionType == "Deposit")
                {
                    handler.Deposit(model);
                }
                else if (model.TransactionType == "Withdraw")
                {

                }
            }
            return View("Index", model);
        }
    }
}