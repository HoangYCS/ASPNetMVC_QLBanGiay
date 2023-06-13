using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Models;
using Microsoft.AspNetCore.Http;
using ASIGNMENT_FPOLY.Services;
using ASIGNMENT_FPOLY.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ASIGNMENT_FPOLY.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ICartService cartService;
        private readonly ICartDetailService cartDetailService;
        private readonly IBillDetaiService billDetaiService;
        private readonly IBillService billService;
        private readonly IColorService colorService;
        private readonly ISizeService sizeService;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productService = new ProductService();
            userService = new UserService();
            cartService = new CartService();
            cartDetailService = new CartDetailService();
            billDetaiService = new BillDetailService();
            billService = new BillService();
            colorService = new ColorService();
            sizeService = new SizeService();
            brandService = new BrandService();
            categoryService = new CategoryService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexLogin()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Remove("Role");
            return RedirectToAction("ViewProduct");
        }

        public IActionResult DeleteItemCart(Guid Id)
        {
            var userLogin = userService.GetUserByName(HttpContext.Session.GetString("UserName"));
            if (userLogin != null)
            {
                cartDetailService.DeleteCartDetail(Id);
            }
            else
            {
                SessionServices.DeletaCartDetailSession(HttpContext.Session, "CartSession", Id);
            }
            return RedirectToAction("MyCart");
        }

        public IActionResult MyCart()
        {
            var userLogin = userService.GetUserByName(HttpContext.Session.GetString("UserName"));
            List<CartDetail> cartDetails = new List<CartDetail>();
            if (userLogin != null)
            {
                cartDetails = cartDetailService.GetAllCartDetailByUserLogin(userLogin.IdUser);
            }
            else
            {
                cartDetails = SessionServices.GetObjectFromJson<List<CartDetail>>(HttpContext.Session, "CartSession");
                if (cartDetails == null) cartDetails = new List<CartDetail>();
            }
            var message = TempData["Message"]?.ToString();
            var messageType = TempData["MessageType"]?.ToString();
            ViewBag.Message = message;
            ViewBag.MessageType = messageType;
            return PartialView("MyCart", cartDetails);
        }

        public IActionResult Login(LoginViewModel Model)
        {
            if (ModelState.IsValid)
            {
                if (userService.GetOneUser(Model.UserName, Model.PassWord) != null)
                {
                    var userLogin = userService.GetUserByName(Model.UserName);
                    Guid idCartLogin = userLogin.IdUser;
                    if (cartService.GetAllCarts().Find(x => x.UserId == idCartLogin) == null)
                    {
                        var myCart = new Cart();
                        myCart.UserId = idCartLogin;
                        myCart.Descripttion = "";
                        cartService.CreateCart(myCart);
                    }
                    HttpContext.Session.SetString("Role", userService.GetOneUser(Model.UserName, Model.PassWord).Role.RoleName);
                    HttpContext.Session.SetString("UserName", Model.UserName);
                    var getListCart = cartDetailService.GetAllCartDetailByUserLogin(idCartLogin);
                    var getLisrCartSession = SessionServices.GetObjectFromJson<List<CartDetail>>(HttpContext.Session, "CartSession");
                    if (getLisrCartSession != null)
                    {
                        foreach (var item in getLisrCartSession)
                        {
                            var getCartDetail = getListCart.FirstOrDefault(x => x.ProductId == item.ProductId);
                            if (getCartDetail != null)
                            {
                                getCartDetail.Quantity += item.Quantity;
                                cartDetailService.UpdateCartDetail(getCartDetail);
                            }
                            else
                            {
                                item.UserId = idCartLogin;
                                item.Product = null;
                                cartDetailService.CreateCartDetail(item);
                            }
                        }
                    }
                    HttpContext.Session.Remove("CartSession");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin tài khoản mật khẩu không chính xác!");
                }
            }
            return View("IndexLogin");
        }

        public IActionResult Details(Guid id)
        {
            var product = productService.GetProductById(id);
            var listProduct = productService.GetAllProducts().Where(x => x.ProductName == product.ProductName && x.BrandId == product.BrandId && x.CategoryId == product.CategoryId);
            ViewBag.Color = new SelectList(colorService.GetAllColors().Where(x => x.Status == 1).Where(item => listProduct.Any(y => y.ColorId == item.Id)), "Id", "NameColor").ToList();
            var listProductColor = productService.GetAllProducts().Where(x => x.ProductName == product.ProductName && x.BrandId == product.BrandId && x.CategoryId == product.CategoryId && x.ColorId == product.ColorId);
            ViewBag.Size = sizeService.GetAllSizes().Where(x => x.Status == 1).Where(item => listProductColor.Any(y => y.SizeId == item.Id)).Select(x => x.SizeName).ToList();
            var x = productService.GetProductById(id);
            var productModel = new ProductViewModel
            {
                Id = x.Id,
                ProductName = x.ProductName,
                ColorId = x.ColorId,
                SizeId = x.SizeId,
                NameBrand = brandService.GetBrandById(x.BrandId).Name,
                NameCategory = categoryService.GetCategoryById(x.CategoryId).Name,
                Price = x.Price,
                Description = x.Description,
                Image = x.Image,
                AvailableQuality = x.AvailableQuality,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
            };
            return View(productModel);
        }

        public IActionResult UpdateCartDetail(Guid idproduct, int sl)
        {
            var userLogin = userService.GetUserByName(HttpContext.Session.GetString("UserName"));
            if (userLogin != null)
            {
                var getCartDetails = cartDetailService.GetAllCartDetailByUserLogin(userLogin.IdUser);
                var getCartDetail = getCartDetails.FirstOrDefault(item => item.ProductId == idproduct);
                getCartDetail.Quantity = sl;
                cartDetailService.UpdateCartDetail(getCartDetail);
                ViewBag.SumTotal = getCartDetails.Sum(item => item.Quantity * item.Price);
            }
            else
            {
                var getLstCartDetailSession = SessionServices.GetObjectFromJson<List<CartDetail>>(HttpContext.Session, "CartSession");
                var CartDetailSession = getLstCartDetailSession.Find(item => item.ProductId == idproduct);
                CartDetailSession.Quantity = sl;
                ViewBag.SumTotal = getLstCartDetailSession.Sum(item => item.Quantity * item.Price);
                SessionServices.SetObjectAsJson(HttpContext.Session, "CartSession", getLstCartDetailSession);
            }
            return Json(new { ViewBag.SumTotal });
        }

        [HttpPost]
        public IActionResult Details(Guid idColor, Guid idSize, string nameProduct, Guid idBrand, Guid idCategory, string nameSize)
        {
            try
            {
                var listProduct = productService.GetAllProducts().Where(x => x.ProductName == nameProduct && x.BrandId == idBrand && x.CategoryId == idCategory);
                ViewBag.Color = new SelectList(colorService.GetAllColors().Where(x => x.Status == 1).Where(item => listProduct.Any(y => y.ColorId == item.Id)), "Id", "NameColor");
                var listProductColor = productService.GetAllProducts().Where(x => x.ProductName == nameProduct && x.BrandId == idBrand && x.CategoryId == idCategory && x.ColorId == idColor);
                var ListSize = sizeService.GetAllSizes().Where(x => x.Status == 1).Where(item => listProductColor.Any(y => y.SizeId == item.Id)).Select(x => x.SizeName).ToList();
                var newIdSize = nameSize == null ? sizeService.GetAllSizes().Where(x => x.Status == 1).Where(item => listProductColor.Any(y => y.SizeId == item.Id)).ToList()[0].Id : sizeService.GetSizesByName(nameSize).Id;
                var x = productService.GetAllProducts().FirstOrDefault(x => x.ProductName == nameProduct && x.BrandId == idBrand && x.CategoryId == idCategory && x.ColorId == idColor && x.SizeId == newIdSize);
                var productModel = new ProductViewModel
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ColorId = x.ColorId,
                    SizeId = x.SizeId,
                    NameBrand = brandService.GetBrandById(x.BrandId).Name,
                    NameCategory = categoryService.GetCategoryById(x.CategoryId).Name,
                    Price = x.Price,
                    Description = x.Description,
                    Image = x.Image,
                    AvailableQuality = x.AvailableQuality,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    ListSelect = ListSize
                };

                return Json(productModel);

            }
            catch (Exception ex)
            {
                return Json(new { errorMessage = ex.Message });
            }

        }


        public IActionResult AddMyCart(Guid id, int n)
        {
            var userLogin = userService.GetUserByName(HttpContext.Session.GetString("UserName"));
            if (userLogin != null)
            {
                HashSet<CartDetail> setProductInCart = new HashSet<CartDetail>();
                setProductInCart = new HashSet<CartDetail>(cartDetailService.GetAllCartDetailByUserLogin(userLogin.IdUser));
                bool CheckExit = setProductInCart.Any(x => x.ProductId == id);
                if (CheckExit)
                {
                    var cartDetail = setProductInCart.FirstOrDefault(x => x.ProductId == id);
                    cartDetail.Quantity += n;
                    cartDetailService.UpdateCartDetail(cartDetail);
                }
                else
                {
                    var newCartDetail = new CartDetail();
                    newCartDetail.ProductId = id;
                    newCartDetail.Quantity = n;
                    newCartDetail.Price = productService.GetProductById(id).Price;
                    newCartDetail.UserId = userLogin.IdUser;
                    cartDetailService.CreateCartDetail(newCartDetail);
                }
            }
            else
            {
                var cartdetail = new CartDetail()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.Empty,
                    Price = productService.GetProductById(id).Price,
                    ProductId = id,
                    Quantity = n,
                    Product = productService.GetProductById(id)
                };
                SessionServices.AddCartToSession(HttpContext.Session, "CartSession", cartdetail);
            }

            return Ok();
        }
        public IActionResult ViewProduct()
        {
            var products = productService.GetAllProducts().GroupBy(item => new { item.CategoryId, item.BrandId, item.ProductName }).Select(item => item.First()).ToList();
            ViewBag.ListColor = colorService.GetAllColors();
            ViewBag.ListSize = sizeService.GetAllSizes();
            return PartialView("ViewProduct", products);
        }

        public IActionResult ViewProductAction(string lstColor, string lstSize, string searchKeyword, string sortBy)
        {

            var listColor = JsonConvert.DeserializeObject<List<string>>(lstColor);
            var listSize = JsonConvert.DeserializeObject<List<string>>(lstSize);
            var products = productService.GetAllProductByAction(listColor, listSize, searchKeyword, sortBy);

            ViewBag.ListColor = colorService.GetAllColors();
            ViewBag.ListSize = sizeService.GetAllSizes();
            return PartialView("ViewPro", products);
        }
        public IActionResult ThanhToan(string diaChi, string note, int action)
        {
            var userLogin = userService.GetUserByName(HttpContext.Session.GetString("UserName"));
            var idUser = userLogin == null ? Guid.Parse("720f788c-c73b-4d88-eaf9-08db3ce7153a") : userLogin.IdUser;
            var listCartDetail = cartDetailService.GetAllCartDetailByUserLogin(idUser);
            if (userLogin == null) listCartDetail = SessionServices.GetObjectFromJson<List<CartDetail>>(HttpContext.Session, "CartSession");
            var Chuoi = "";
            var outOfStockProducts = listCartDetail
                             .Where(item => item.Quantity > productService.GetProductById(item.ProductId).AvailableQuality)
                             .Select(item => '"' + productService.GetProductById(item.ProductId).ProductName + "-" + productService.GetProductById(item.ProductId).Color.NameColor + "-" + productService.GetProductById(item.ProductId).Size.SizeName + '"');
            Chuoi = string.Join(" ", outOfStockProducts);

            if (listCartDetail.Any())
            {
                if (Chuoi == "")
                {
                    var newBill = new Bill()
                    {
                        Id = Guid.NewGuid(),
                        UserId = idUser,
                        Note = note == null ? "" : note,
                        Creatdate = DateTime.Now,
                        Status = action,
                        shipping_address = diaChi,
                        TotalPrice = listCartDetail.Sum(item => item.Price * item.Quantity),
                    };
                    billService.CreateBill(newBill);
                    foreach (var item in listCartDetail)
                    {
                        billDetaiService.CreateBillDetail(new BillDetail
                        {
                            Id = Guid.NewGuid(),
                            BillId = newBill.Id,
                            ProductId = item.ProductId,
                            Price = item.Price,
                            Quantily = item.Quantity,
                        });
                        cartDetailService.DeleteCartDetail(item.Id);
                        var product = productService.GetProductById(item.ProductId);
                        product.AvailableQuality -= item.Quantity;
                        productService.UpdateProduct(product);
                    }
                    HttpContext.Session.Remove("CartSession");
                    TempData["Message"] = "Thanh toán thành công!";
                    TempData["MessageType"] = "success";
                }
                else
                {
                    TempData["Message"] = "Xin lỗi! Sản phẩm: " + Chuoi + " hiện tại số lượng tồn không đủ! Vui lòng chọn lại số lượng.";
                    TempData["MessageType"] = "success";
                }
                return RedirectToAction("MyCart");
            }
            else return View("MyCart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}