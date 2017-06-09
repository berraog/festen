using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Festen.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Festen.Controllers
{
    public class HomeController : Controller
    {

        FestenContext _context;
        public HomeController(FestenContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Participant p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            await _context.AddParticipant(p);
            return View();
        }

        [HttpGet]
        public IActionResult Result()
        {
            IEnumerable<Participant> participants = _context.GetAllParticipants();
            return View(participants);
        }
    }
}
