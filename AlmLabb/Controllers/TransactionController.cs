using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmLabb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AlmLabb.Controllers
{
    public class TransactionController : Controller
    {
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

            }
            return View("Index", model);
        }
    }
}