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
    public class BrandsController : Controller
    {

        private readonly ILogger<BrandsController> _logger;
        private readonly IBrandService brandService;
        private List<Brand> _brands;


        public BrandsController(ILogger<BrandsController> logger)
        {
            _logger = logger;
            brandService = new BrandService();
            _brands = brandService.GetAllBrands();
        }

        public ActionResult Index()
        {
            List<Brand> brands = brandService.GetAllBrands();
            return PartialView("Index", brands);
        }

        public ActionResult Details(Guid id)
        {
            return View(brandService.GetBrandById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Brand p)
        {
            if (brandService.CreateBrand(p))
            {
                var brands = brandService.GetAllBrands();
                return PartialView("Index", brands);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(brandService.GetBrandById(id));
        }

        public async Task<ActionResult> Edit(Brand p)
        {
            if (brandService.UpdateBrand(p))
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        //public ActionResult Delete()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (brandService.DeleteBrand(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
