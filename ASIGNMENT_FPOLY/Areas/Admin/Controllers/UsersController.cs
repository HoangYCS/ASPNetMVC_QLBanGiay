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
using ASIGNMENT_FPOLY.ViewModels;

namespace ASIGNMENT_FPOLY.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            userService= new UserService();
            roleService = new RoleService();
        }


        public ActionResult Index()
        {
            List<User> users = userService.GetAllUsers();
            return PartialView("Index", users);
        }

        public ActionResult Details(Guid id)
        {
            return View(userService.GetUserById(id));
        }
                              
        public ActionResult Create()
        {
            ViewBag.Role = new SelectList(roleService.GetAllRoles().Where(x => x.Status == 1), "Id", "RoleName");

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User p)
        {
            if (userService.CreateUser(p))
            {
                var users = userService.GetAllUsers();
                return PartialView("Index", users);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(userService.GetUserById(id));
        }

        public async Task<ActionResult> Edit(User p)
        {
            if (userService.UpdateUser(p))
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
            if (userService.DeleteUser(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
