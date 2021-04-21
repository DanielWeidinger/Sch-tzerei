using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schaetzerei.Core.Contracts;

namespace Schaetzerei.MVC.Controllers
{
    public class MainController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
