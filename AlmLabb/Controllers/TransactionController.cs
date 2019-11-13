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
        private ITransactionHandler _handler;
        public TransactionController(ITransactionHandler handler)
        {
            _handler = handler;
        }
        public IActionResult Index()
        {
            return View(new TransactionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTransaction(TransactionViewModel transaction)
        {
            if (ModelState.IsValid)
            {
                transaction.Result = _handler.Handle(transaction);
            }
            return View("Index", transaction);
        }
    }   
}