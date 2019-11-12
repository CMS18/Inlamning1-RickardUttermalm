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
    public class HomeController : Controller
    {
        private IMockDb _context;
        public HomeController(IMockDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new StartPageVievModel();
            model.Data = _context.Customers;
            return View(model);
        }

    }
}