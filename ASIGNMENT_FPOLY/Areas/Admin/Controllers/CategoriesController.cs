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
    public class CategoriesController : Controller
    {

        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryService categoryService;
        private List<Category> _categorys;


        public CategoriesController(ILogger<CategoriesController> logger)
        {
            _logger = logger;
            categoryService = new CategoryService();
            _categorys = categoryService.GetAllCategorys();
        }

        public ActionResult Index()
        {
            List<Category> categorys = categoryService.GetAllCategorys();
            return PartialView("Index", categorys);
        }

        public ActionResult Details(Guid id)
        {
            return View(categoryService.GetCategoryById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category p)
        {
            if (categoryService.CreateCategory(p))
            {
                var categorys = categoryService.GetAllCategorys();
                return PartialView("Index", categorys);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(categoryService.GetCategoryById(id));
        }

        public async Task<ActionResult> Edit(Category p)
        {
            if (categoryService.UpdateCategory(p))
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
            if (categoryService.DeleteCategory(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
