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
using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;

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
        [HttpPost]
        public async Task<ActionResult> UpdateProduct(ProductViewModel pro, IFormFile file)
        {
            var product = productService.GetProductById(pro.Id);
            if (file != null)
            {
                string sourcePath = file.FileName;
                product.Image = sourcePath;
                string destinationPath = @"D:\ASM\ASIGNMENT_FPOLY\ASIGNMENT_FPOLY\wwwroot\assets\images\others\";
                string fileName = Path.GetFileName(sourcePath);
                string destinationFilePath = Path.Combine(destinationPath, fileName);
                using (var stream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            product.Price = pro.Price;
            product.AvailableQuality= pro.AvailableQuality;
            product.Description = pro.Description;
            productService.UpdateProduct(product);
            return Ok();
        }


        [HttpPost]
        public IActionResult GetProduct(ProductViewModel obj)
        {
            var productExists = productService.GetAllProducts()
    .Any(pro => pro.ProductName == obj.ProductName.Trim() && pro.BrandId == obj.BrandId && pro.ColorId == obj.ColorId && pro.SizeId == obj.SizeId && pro.CategoryId == obj.CategoryId);
            if (productExists)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Product, Product>());
                var mapper = config.CreateMapper();
                var product = productService.GetAllProducts()
    .FirstOrDefault(pro => pro.ProductName == obj.ProductName.Trim() && pro.BrandId == obj.BrandId && pro.ColorId == obj.ColorId && pro.SizeId == obj.SizeId && pro.CategoryId == obj.CategoryId);
                // Sao chép đối tượng product
                var initialProduct = mapper.Map<Product, Product>(product);
                return Json(new { success = productExists, price = initialProduct.Price, soLuong = initialProduct.AvailableQuality, moTa = initialProduct.Description, image = initialProduct.Image, idProduct = initialProduct.Id });
            }
            return Json(new { success = productExists });
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
        public async Task<ActionResult> Create(Product p, IFormFile imageFile)
        {
            string sourcePath = imageFile.FileName;
            p.Image = sourcePath;
            if (productService.CreateProduct(p))
            {
                string destinationPath = @"D:\ASM\ASIGNMENT_FPOLY\ASIGNMENT_FPOLY\wwwroot\assets\images\others\";
                string fileName = Path.GetFileName(sourcePath);
                string destinationFilePath = Path.Combine(destinationPath, fileName);
                using (var stream = new FileStream(destinationFilePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
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
            ViewBag.Brand = new SelectList(brandService.GetAllBrands().Where(x => x.Status == 1), "Id", "Name");
            ViewBag.Color = new SelectList(colorService.GetAllColors().Where(x => x.Status == 1), "Id", "NameColor");
            ViewBag.Size = new SelectList(sizeService.GetAllSizes().Where(x => x.Status == 1), "Id", "SizeName");
            ViewBag.Category = new SelectList(categoryService.GetAllCategorys().Where(x => x.Status == 1), "Id", "Name");

            return View(productService.GetProductById(id));
        }

        // POST: ProductsController/Edit/5

        public async Task<ActionResult> Edit(Product p)
        {
            var file = Request.Form.Files["image"];
            if (file != null)
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
