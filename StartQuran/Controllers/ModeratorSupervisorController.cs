using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.StudentTeacherService.Model;
using StartQuran.Service.SupervisorService;
using StartQuran.Service.SupervisorService.Model;
using StartQuran.Service.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tarteel.Models.DataBase;
using tarteel.Service.ModeratorTeacherManager;
using tarteel.Service.ModeratorTeacherService.Model;

namespace tarteel.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class ModeratorSupervisorController : Controller
    {
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        private readonly SupervisorManager _SupervisorManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly IRepository<ModeratorSupervisor> _ModeratorSupervisor;

        public ModeratorSupervisorController(SupervisorManager SupervisorManager, IRepository<ApplicationUser> AppUser, ModeratorSupervisorManager ModeratorSupervisorManager, IRepository<ModeratorSupervisor> ModeratorSupervisor)
        {
            _AppUser = AppUser;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
            _ModeratorSupervisor = ModeratorSupervisor;
            _SupervisorManager = SupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {

            var SList = _ModeratorSupervisorManager.ModeratorSupervisor_GetAll();
            return View("Index", SList);
        }

        #endregion
        #region Create
        public async Task<IActionResult> Create(string id)
        {
            ViewBag.ActionName = nameof(Create);


            ViewBag.moderators =  _SupervisorManager.Get(id).Result;

            ViewBag.supervisors = new SelectList(_ModeratorSupervisorManager.SupervisorNotInModerator_GetAll(id), "Id", "FullName");

            return View("Moderator", new ModeratorSupervisorRM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ModeratorSupervisorRM model)
        {
           
            try
            {

                await _ModeratorSupervisorManager.ModeratorTeacher_Create(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "ModeratorSupervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "ModeratorSupervisor");
            }
        }

        #endregion


        #region Delete


        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                
                await _ModeratorSupervisorManager.ModeratorTeacher_Delete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "ModeratorSupervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "ModeratorSupervisor");
            }
        }

        #endregion

        #region Helper

        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }
        public bool IsSupervisor()
        {
            return User.IsInRole(UserType.SUPERVISOR.ToString());
        }


   

    }


    #endregion

}

