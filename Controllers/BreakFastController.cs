using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BuberBreakfast.Contracts.Service;
using BuberBreakfast.Entities;
using BuberBreakfast.DTO;

namespace BuberBreakfast.Controllers
{
    //[Route("[controller]")]
    public class BreakFastController : Controller
      {
        
        private readonly IBreakFastService _breakFastService;

        public BreakFastController(IBreakFastService breakfastService) => _breakFastService = breakfastService;

        public IActionResult Index()
        {
            var breakfasts = _breakFastService.PrintAllBreakFast();
            return View(breakfasts.Data);
        }
         
         // this also works for index(Viewing all data)
        /*public IActionResult Index()
        {
            var breakfasts = _breakFastService.PrintAllBreakFast().Data;
            return View(breakfasts);
        }*/
 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BreakFastDto request)
        {
            var create = _breakFastService.RegisterBreakFast(request);
            if (create.Status == false)
            {
                ViewBag.Message = create.Message;
                return View();
            }
            return RedirectToAction("Index" , "Home");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateBreakFastDto updateBreakFastDto, int id)
        {
            var breakfast = _breakFastService.UpdateBreakFast(id, updateBreakFastDto);
            if (breakfast.Status == false)
            {
                ViewBag.Message = breakfast.Message;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var breakfast = _breakFastService.GetBreakFast(id);
            return View(breakfast);
        }

        [HttpPost]
        public IActionResult DeleteBreakFast(int id)
        {
            var breakfast = _breakFastService.DeleteBreakFast(id);
            if (breakfast.Status == false)
            {
                ViewBag.Message = breakfast.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int id)
        {
            var breakfast = _breakFastService.GetBreakFast(id);
            if (breakfast.Status == false)
            {
                ViewBag.Message = breakfast.Message;
                return View();
            }
            return View(breakfast.Data);
        }
    }
} 