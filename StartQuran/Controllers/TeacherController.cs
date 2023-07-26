using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.SupervisorService;
using StartQuran.Service.TeacherService;
using StartQuran.Service.TeacherService.Model;
using tarteel.Service.ModeratorTeacherManager;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,TEACHER,Moderator")]

    public class TeacherController : Controller
    {
        private readonly SupervisorManager _SupervisorManager;
        private readonly TeacherManager _TeacherManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StudentManager _StudentManager;
        private readonly FamilyManager _FamilyManager;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        public TeacherController(ModeratorSupervisorManager ModeratorSupervisorManager, UserManager<ApplicationUser> userManager, FamilyManager FamilyManager, StudentManager StudentManager, TeacherManager TeacherManager, SupervisorManager SupervisorManager, IRepository<ApplicationUser> AppUser, StudentTeacherManager StudentTeacherManager)
        {
            _StudentManager = StudentManager;
            _StudentTeacherManager = StudentTeacherManager;
            _userManager = userManager;
            _TeacherManager = TeacherManager;
            _FamilyManager = FamilyManager;
            _SupervisorManager = SupervisorManager;
            _AppUser = AppUser;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {
            ViewBag.ActionName = nameof(Create);

            var LTERM = new List<TeacherRM>();
            if (IsSupervisor() || IsModerator())
            {
                LTERM = _TeacherManager.TeacherOfSuperVisor_GetAll(GitUserId());
            }
            else
            {
                LTERM = await _TeacherManager.Get();
            }
            return View("Index", LTERM);
        }

        public async Task<IActionResult> TeacherDeleted()
        {
            ViewBag.ActionName = nameof(Create);

            var LTERM = new List<TeacherRM>();
            if (IsSupervisor())
            {
                LTERM = _TeacherManager.TeacherOfSuperVisor_GetAllDeleted(GitUserId());
            }
            else
            {
                LTERM = await _TeacherManager.GetDeleted();
            }
            return View("Deleted", LTERM);
        }

        public IActionResult Family(string id)
        {

            var FList = _FamilyManager.GetFamilyOfStudent(id);


            return View(FList);
        }
        public IActionResult Students(Guid id)
        {

            var sList = _StudentManager.Studentlist_GetByFamily(id);


            return View(sList);
        }
        public async Task<IActionResult> Home()
        {
            ViewBag.ActionName = nameof(Create);
            Teacher user = (Teacher)_userManager.FindByIdAsync(GitUserId()).Result;

            return View("Home", user);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            if (IsSupervisor())
            {
                ViewBag.Supervisors = new SelectList(_AppUser.Get(c => c.Id == GitUserId()), "Id", "FullName", GitUserId());

            }
            else if (IsModerator())
            {
                ViewBag.Supervisors = new SelectList(_ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(GitUserId(), true), "Id", "FullName", GitUserId());

            }
            else
            {
                var users = _userManager.GetUsersInRoleAsync(UserType.SUPERVISOR.ToString()).Result.Where(c => c.IsDeleted == false).ToList();
                users.AddRange(_userManager.GetUsersInRoleAsync(UserType.Moderator.ToString()).Result.Where(c => c.IsDeleted == false).ToList());
                ViewBag.Supervisors = new SelectList(users, "Id", "FullName");
            }
            return View("Teacher", new TeacherRM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherRM model)
        {
            if (_userManager.Users.Where(c => c.PhoneNumber == model.phone).Count() != 0)
            {
                TempData["AlertMessage"] = "phoneExist";
                return RedirectToAction("Create", "Teacher");
            }
            try
            {
                await _TeacherManager.Registeration(model);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Teacher");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "Teacher");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(string id)
        {
            ViewBag.ActionName = nameof(Update);
            var teacher = await _TeacherManager.Get(id);
            if (IsSupervisor())
                ViewBag.Supervisors = new SelectList(_AppUser.Get(c => c.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)), "Id", "FullName", teacher.SupervisorId);
            else if (IsModerator())
                ViewBag.Supervisors = new SelectList(_ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(GitUserId(), true), "Id", "FullName", teacher.SupervisorId);
            else
            {
                var users = _userManager.GetUsersInRoleAsync(UserType.SUPERVISOR.ToString()).Result.Where(c => c.IsDeleted == false).ToList();
                users.AddRange(_userManager.GetUsersInRoleAsync(UserType.Moderator.ToString()).Result.Where(c => c.IsDeleted == false).ToList());
                ViewBag.Supervisors = new SelectList(users, "Id", "FullName", teacher.SupervisorId);
            }
            return View("Teacher", teacher);

        }

        [HttpPost]
        public async Task<IActionResult> Update(TeacherRM model)
        {
            if (_userManager.Users.Where(c => c.Id != model.Id && c.PhoneNumber == model.phone).Count() != 0)
            {
                TempData["AlertMessage"] = "phoneExist";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "Teacher", new { id = model.Id });
            }
            try
            {

                await _TeacherManager.Update(model);
                TempData["AlertMessage"] = "Done";
                if (IsModerator())
                    return RedirectToAction("ModeratorTeacher", "Supervisor");
                return RedirectToAction("Index", "Teacher");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                if (IsModerator())
                    return RedirectToAction("ModeratorTeacher", "Supervisor");
                return RedirectToAction("Update", "Teacher", new { id = model.Id });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                //var Student = _StudentTeacherManager.teacher_Get(Id);
                //if (Student != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _TeacherManager.Delete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> UnDelete(string Id)
        {
            try
            {
                //var Student = _StudentTeacherManager.teacher_Get(Id);
                //if (Student != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _TeacherManager.UnDelete(Id);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Teacher");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Teacher");
            }
        }
        #endregion


        #region Helper
        public bool IsSupervisor()
        {
            return User.IsInRole(UserType.SUPERVISOR.ToString());
        }
        public bool IsModerator()
        {
            return User.IsInRole(UserType.Moderator.ToString());
        }
        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }
        [HttpGet]
        public JsonResult TeacherLink()
        {

            return Json(_TeacherManager.Get(GitUserId()).Result.ZoomLink);

        }
        #endregion
    }
}