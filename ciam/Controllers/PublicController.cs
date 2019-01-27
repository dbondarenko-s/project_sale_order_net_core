using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ciam.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ciam.Controllers
{
    public class PublicController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}