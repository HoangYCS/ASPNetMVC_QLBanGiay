using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASIGNMENT_FPOLY.Models;
using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Services;

namespace ASIGNMENT_FPOLY.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        
        private readonly ILogger<ColorsController> _logger;
        private readonly IColorService colorService;
        private List<Color> _colors;


        public ColorsController(ILogger<ColorsController> logger)
        {
            _logger = logger;
            colorService = new ColorService();
            _colors = colorService.GetAllColors();
        }

        public ActionResult Index()
        {
            List<Color> colors = colorService.GetAllColors();
            return PartialView("Index", colors);
        }

        public ActionResult Details(Guid id)
        {
            return View(colorService.GetColorById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Color p)
        {
            if (colorService.CreateColor(p))
            {
                var colors = colorService.GetAllColors();
                return PartialView("Index", colors);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(colorService.GetColorById(id));
        }

        public async Task<ActionResult> Edit(Color p)
        {
            if (colorService.UpdateColor(p))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public ActionResult Delete()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (colorService.DeleteColor(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
