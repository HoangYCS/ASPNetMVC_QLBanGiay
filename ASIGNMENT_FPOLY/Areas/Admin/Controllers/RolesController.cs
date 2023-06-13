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
    public class RolesController : Controller
    {

        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService roleService;
        private List<Role> _roles;


        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;
            roleService = new RoleService();
            _roles = roleService.GetAllRoles();
        }

        public ActionResult Index()
        {
            List<Role> roles = roleService.GetAllRoles();
            return PartialView("Index", roles);
        }

        public ActionResult Details(Guid id)
        {
            return View(roleService.GetRoleById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Role p)
        {
            if (roleService.CreateRole(p))
            {
                var roles = roleService.GetAllRoles();
                return PartialView("Index", roles);
            }
            else return BadRequest();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(roleService.GetRoleById(id));
        }

        public async Task<ActionResult> Edit(Role p)
        {
            if (roleService.UpdateRole(p))
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
            if (roleService.DeleteRole(id))
            {
                return RedirectToAction("Index");
            }
            else return View("Delete");
        }
    }
}
