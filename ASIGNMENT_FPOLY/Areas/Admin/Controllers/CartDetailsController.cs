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
    public class CartDetailsController : Controller
    {

        private readonly ILogger<CartDetailsController> _logger;
        private readonly ICartDetailService cartdetailService;
        private List<CartDetail> _cartdetails;


        public CartDetailsController(ILogger<CartDetailsController> logger)
        {
            _logger = logger;
            cartdetailService = new CartDetailService();
			_cartdetails = cartdetailService.GetAllCartDetails();

		}

        public ActionResult Index()
        {
            List<CartDetail> cartdetails = cartdetailService.GetAllCartDetails();
            return PartialView("Index", cartdetails);
        }

        public ActionResult Details(Guid id)
        {
            return View(cartdetailService.GetCartDetailById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CartDetail p)
        {
            if (cartdetailService.CreateCartDetail(p))
            {
                var cartdetails = cartdetailService.GetAllCartDetails();
                return PartialView("Index", cartdetails);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(cartdetailService.GetCartDetailById(id));
        }

        public async Task<ActionResult> Edit(CartDetail p)
        {
            if (cartdetailService.UpdateCartDetail(p))
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
            if (cartdetailService.DeleteCartDetail(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
