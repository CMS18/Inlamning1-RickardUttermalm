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
    public class TransferController : Controller
    {
        private ITransferHandler _handler;
        private readonly IMockDb db;

        public TransferController(ITransferHandler handler, IMockDb _db)
        {
            _handler = handler;
            this.db = _db;
        }

        public IActionResult Index()
        {
            var model = new TransferViewModel() { FromAccountId = 1, ToAccountId = 2, Amount = 50 };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = _handler.Transfer(model.FromAccountId, model.ToAccountId, model.Amount);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("transfer", ex.Message);
                    return View("Index", model);
                }
            }
            return View("Index", model);
        }
    }
}