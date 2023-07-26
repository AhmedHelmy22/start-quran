


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentMarketerService;
using StartQuran.Service.StudentMarketerService.Model;
using StartQuran.Service.MarketerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using StartQuran.Service.SupervisorService;
using tarteel.Service.ModeratorTeacherManager;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,Moderator")]

    public class StudentMarketerController : Controller
    {
        private readonly StudentManager _StudentManager;
        private readonly StudentMarketerManager _StudentMarketeVManager;
        private readonly FamilyManager _FamilyManager;
        private readonly SupervisorManager _SupervisorManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly IRepository<StudentMarketer> _StudentMarketer;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        private readonly MarketerManager _MarketerManager;
        public StudentMarketerController(MarketerManager MarketerManager, SupervisorManager SupervisorManagerr, ModeratorSupervisorManager ModeratorSupervisorManager, IRepository<StudentMarketer> StudentMarketer, StudentManager StudentManager, FamilyManager FamilyManager, IRepository<ApplicationUser> AppUser, StudentMarketerManager StudentMarketeVManager)
        {
            _AppUser = AppUser;
            _StudentMarketer = StudentMarketer;
            _StudentManager = StudentManager;
            _FamilyManager = FamilyManager;
            _StudentMarketeVManager = StudentMarketeVManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
            _SupervisorManager = SupervisorManagerr;
            _MarketerManager = MarketerManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {
            if (IsSupervisor() || IsModerator())
            {
                var SList = _StudentMarketeVManager.StudentMarketer_Supervisor_GetAll(GitUserId());
                return View("Index", SList);
            }

            else
            {
                var SList = _StudentMarketeVManager.StudentMarketer_GetAll();
                return View("Index", SList);
            }

        }

        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.ActionName = nameof(Create);
            ViewBag.Marketer = new SelectList(await _MarketerManager.Get(), "Id", "fullName");

            if (IsSupervisor())
            {
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");

            }
            else if (IsModerator())
            {
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId(), true), "ID", "FullName");

            }
            else
            {
                ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName");
            }

            ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");

            //   ViewBag.Student = new SelectList(_StudentManager.Student_GetAll(), "ID", "FullName");

            return View("StudentMarketers", new StudentMarketerVM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentMarketerVM model)
        {
            if (_StudentMarketer.FirstOrDefault(c => c.StudentId == model.StudentId && c.MarketerId == model.MarketerId).Result != null)
            {
                TempData["AlertMessage"] = "Exist";
                return RedirectToAction("Create", "StudentMarketer");
            }
            try
            {

                await _StudentMarketeVManager.StudentMarketer_Create(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "StudentMarketer");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "StudentMarketer");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            var StudentMarketer = _StudentMarketeVManager.StudentMarketer_Get(id);


            ViewBag.Marketer = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.MARKETER), "Id", "FullName");
            if (IsSupervisor())
            {
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");

            }
            else if (IsModerator())
            {
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId()), "ID", "FullName");

            }


            if (StudentMarketer.Student != null)
            {
                ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(StudentMarketer.Student.FamilyId), "ID", "FullName");
                StudentMarketer.FamilyId = StudentMarketer.Student.FamilyId;
            }
            else
            {
                ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");
                StudentMarketer.FamilyId = new Guid();
            }
            return View("StudentMarketers", StudentMarketer);

        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentMarketerVM model)
        {
            if (_StudentMarketer.FirstOrDefault(c => c.StudentId == model.StudentId && c.MarketerId == model.MarketerId).Result != null)
            {
                TempData["AlertMessage"] = "Exist";
                return RedirectToAction("Update", "StudentMarketer", new { id = model.ID });
            }
            try
            {

                await _StudentMarketeVManager.StudentMarketer_Update(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "StudentMarketer");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "StudentMarketer", new { id = model.ID });
            }
        }

        #endregion



        #region Delete

        public async Task<IActionResult> DeleteDate(DateTime Date)
        {
            try
            {
                await _StudentMarketeVManager.Predecessor_Delete(Date);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "StudentMarketer");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "StudentMarketer");
            }
        }


        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {

                await _StudentMarketeVManager.StudentMarketer_Delete(Id, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "StudentMarketer");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "StudentMarketer");
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

        public bool IsModerator()
        {
            return User.IsInRole(UserType.Moderator.ToString());
        }

        [HttpGet]
        public JsonResult StudentData(Guid id)
        {
            if (id != Guid.Empty)
            {
                var Student = _StudentManager.Studentlist_GetByFamily(id);
                return Json(Student);
            }
            else
            {
                return Json(new { data = "" });
            }
        }

    }






    #endregion

}

