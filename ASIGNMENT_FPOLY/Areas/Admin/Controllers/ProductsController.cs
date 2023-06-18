using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using ASIGNMENT_FPOLY.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AutoMapper;

namespace ASIGNMENT_FPOLY.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService productService;
        private readonly IBrandService brandService;
        private readonly IColorService colorService;
        private readonly ISizeService sizeService;
        private readonly ICategoryService categoryService;
        private List<Product> _products;


        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
            productService = new ProductService();
            brandService = new BrandService();
            colorService = new ColorService();
            sizeService = new SizeService();
            categoryService = new CategoryService();
            _products = productService.GetAllProducts();
        }

        public ActionResult Index(string giaMin, string giaMax)
        {
            ViewBag.Category = new SelectList(categoryService.GetAllCategorys(), "Id", "Name");
            List<Product> products = productService.GetAllProducts();
            if (!string.IsNullOrEmpty(giaMin) && !string.IsNullOrEmpty(giaMax))
                products = products.Where(item => item.Price >= double.Parse(giaMin) && item.Price <= double.Parse(giaMax)).ToList();
            //return View(products);
            return View(products);
        }


        public IActionResult SelectedStatus(string searchValue)
        {
            if (searchValue == "In Stock")
            {
                _products = _products.Where(x => x.Status == 1).ToList();
            }
            else
            if (searchValue == "Out Stock")
            {
                _products = _products.Where(x => x.Status == 0).ToList();
            }
            else
            {
                _products = productService.GetAllProducts();
            }

            return PartialView("View", _products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(productService.GetProductById(id));
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(brandService.GetAllBrands().Where(x => x.Status == 1), "Id", "Name");
            ViewBag.Color = new SelectList(colorService.GetAllColors().Where(x => x.Status == 1), "Id", "NameColor");
            ViewBag.Size = new SelectList(sizeService.GetAllSizes().Where(x => x.Status == 1), "Id", "SizeName");
            ViewBag.Category = new SelectList(categoryService.GetAllCategorys().Where(x => x.Status == 1), "Id", "Name");

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product p)
        {
            var file = Request.Form.Files["image"];
            string sourcePath = file.FileName;
            p.Image = sourcePath;
           
            if (productService.CreateProduct(p))
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string rootPath = Directory.GetParent(currentDirectory).FullName;
                string destinationPath = Path.Combine(rootPath, "ASIGNMENT_FPOLY", "wwwroot", "assets", "images", "others");
                string fileName = Path.GetFileName(sourcePath);
                string destinationFilePath = Path.Combine(destinationPath, fileName);
                using (var stream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var products = productService.GetAllProducts();
                return RedirectToAction("Index", products);
            }
            else return Content("Sản phẩm này đã tồn tại!");
        }

        // GET: ProductsController/Edit/5
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ViewBag.Brand = new SelectList(brandService.GetAllBrands().Where(x=>x.Status==1), "Id", "Name");
            ViewBag.Color = new SelectList(colorService.GetAllColors().Where(x => x.Status == 1), "Id", "NameColor");
            ViewBag.Size = new SelectList(sizeService.GetAllSizes().Where(x => x.Status == 1), "Id", "SizeName");
            ViewBag.Category = new SelectList(categoryService.GetAllCategorys().Where(x => x.Status == 1), "Id", "Name");

            return View(productService.GetProductById(id));
        }

        // POST: ProductsController/Edit/5

        public async Task<ActionResult> Edit(Product p)
        {
            var file = Request.Form.Files["image"];
            if(file != null)
            {
                string sourcePath = file.FileName;
                p.Image = sourcePath;
                if (productService.UpdateProduct(p))
                {
                    string destinationPath = @"D:\ASM\ASIGNMENT_FPOLY\ASIGNMENT_FPOLY\wwwroot\assets\images\others\";
                    string fileName = Path.GetFileName(sourcePath);
                    string destinationFilePath = Path.Combine(destinationPath, fileName);
                    using (var stream = new FileStream(destinationFilePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (productService.UpdateProduct(p))
                {
                    return RedirectToAction("Index");
                }
            }

            
            return Content("Sản Phẩm này đã tồn tại");
        }
        // GET: ProductsController/Delete/5
        //public ActionResult Delete()
        //{
        //    return View();
        //}

        // POST: ProductsController/Delete/5
        //[HttpPost]
        public ActionResult Delete(Guid id)
        {
            if (productService.DeleteProduct(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
