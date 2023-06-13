using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASIGNMENT_FPOLY.Models;
using ASIGNMENT_FPOLY.Services;
using ASIGNMENT_FPOLY.IServices;

namespace ASIGNMENT_FPOLY.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BillsController : Controller
    { 
        private readonly ILogger<BillsController> _logger;
        private readonly IBillService billService;
        private List<Bill> _bills;
        private readonly IBillDetaiService billDetaiService;


        public BillsController(ILogger<BillsController> logger)
        {
            _logger = logger;
            billService = new BillService();
            _bills = billService.GetAllBills();
            billDetaiService = new BillDetailService();
        }

        public ActionResult Index()
        {
            List<Bill> bills = billService.GetAllBills().OrderByDescending(x=>x.Creatdate).ToList();
            return PartialView("Index", bills);
        }

        public ActionResult Details(Guid id)
        {
            ViewBag.QuanLy = billService.GetBillById(id).Status==1? true : false;
            return View(billDetaiService.GetAllBillDetails().Where(x=>x.BillId==id));
        }

        public ActionResult UpdateBill(Guid id, int action)
        {
            if (action != 10)
            {
                var billUpdate = billService.GetBillById(id);
                billUpdate.Status = action;
                billService.UpdateBill(billUpdate);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Bill p)
        {
            if (billService.CreateBill(p))
            {
                var bills = billService.GetAllBills();
                return PartialView("Index", bills);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(billService.GetBillById(id));
        }

        public async Task<ActionResult> Edit(Bill p)
        {
            if (billService.UpdateBill(p))
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
            if (billService.DeleteBill(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
