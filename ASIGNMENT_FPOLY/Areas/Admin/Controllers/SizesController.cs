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
    public class SizesController : Controller
    {
        private readonly ILogger<SizesController> _logger;
        private readonly ISizeService sizeService;
        private List<Size> _sizes;


        public SizesController(ILogger<SizesController> logger)
        {
            _logger = logger;
            sizeService = new SizeService();
            _sizes = sizeService.GetAllSizes();
        }

        public ActionResult Index()
        {
            List<Size> sizes = sizeService.GetAllSizes();
            return PartialView("Index", sizes);
        }

        public ActionResult Details(Guid id)
        {
            return View(sizeService.GetSizeById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Size p)
        {
            if (sizeService.CreateSize(p))
            {
                var sizes = sizeService.GetAllSizes();
                return PartialView("Index", sizes);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(sizeService.GetSizeById(id));
        }

        public async Task<ActionResult> Edit(Size p)
        {
            if (sizeService.UpdateSize(p))
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
            if (sizeService.DeleteSize(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
