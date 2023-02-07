using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BuberBreakfast.Contracts.Service;
using BuberBreakfast.Entities;

namespace BuberBreakfast.Controllers
{
    //[Route("[controller]")]
    public class BreakFastController : Controller
      {
        // List<BreakFast> breakfast = new()
        // {
        //    new BreakFast(){Id = 1, Name ="Amala", Description = "Black amala", EndDateTime = DateTime.Now, StartDateTime = DateTime.Now},
        //    new BreakFast(){Id = 1, Name ="Rice", Description = "white rice", EndDateTime = DateTime.Now, StartDateTime = DateTime.Now},
        // };
        private readonly IBreakFastService _breakFastService;

        public BreakFastController(IBreakFastService breakfastService) => _breakFastService = breakfastService;

        public IActionResult Index()
        {
            var breakfasts = _breakFastService.PrintAllBreakFast();
            return View(breakfasts.Data);
        }
 
        // public IActionResult Create(BreakFastDto request)
        // {
        //     var isMessage = _breakFastService.RegisterBreakFast(request);
        // }

    }
}