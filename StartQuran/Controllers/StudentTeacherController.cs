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
using StartQuran.Service.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tarteel.Service.ModeratorTeacherManager;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,Moderator")]

    public class StudentTeacherController : Controller
    {
        private readonly StudentManager _StudentManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly FamilyManager _FamilyManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly IRepository<StudentTeacher> _StudentTeacher;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        public StudentTeacherController(ModeratorSupervisorManager ModeratorSupervisorManager, IRepository<StudentTeacher> StudentTeacher, StudentManager StudentManager, FamilyManager FamilyManager, IRepository<ApplicationUser> AppUser, StudentTeacherManager StudentTeacherManager)
        {
            _AppUser = AppUser;
            _StudentTeacher = StudentTeacher;
            _StudentManager = StudentManager;
            _FamilyManager = FamilyManager;
            _StudentTeacherManager = StudentTeacherManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {

            var SList = new List<StudentTeacherRM>();
            if (IsSupervisor() || IsModerator())
            {
                SList = _StudentTeacherManager.SuperVisor_StudentTeacher_GetAll(GitUserId());
            }
            else
            {
                SList = _StudentTeacherManager.StudentTeacher_GetAll();
            }
            return View("Index", SList);
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            if (IsModerator())
            {
                ViewBag.Teacher = new SelectList(_ModeratorSupervisorManager.TeacherOfModerator_GetAll(GitUserId(), true), "Id", "FullName");
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId(), true), "ID", "FullName");

            }
            else if (!IsSupervisor())
            {
                ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.TEACHER), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName");

            }

            else
            {
                ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfSuperVisor_GetAll(GitUserId()), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");

            }
            ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");

            //   ViewBag.Student = new SelectList(_StudentManager.Student_GetAll(), "ID", "FullName");

            return View("StudentTeachers", new StudentTeacherRM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentTeacherRM model)
        {
            if (_StudentTeacher.FirstOrDefault(c => c.StudentId == model.StudentId && c.TeacherId == model.TeacherId).Result != null)
            {
                TempData["AlertMessage"] = "Exist";
                return RedirectToAction("Create", "StudentTeacher");
            }
            try
            {

                await _StudentTeacherManager.StudentTeacher_Create(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "StudentTeacher");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "StudentTeacher");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            var StudentTeacher = _StudentTeacherManager.StudentTeacher_Get(id);
            if (IsModerator())
            {
                ViewBag.Teacher = new SelectList(_ModeratorSupervisorManager.TeacherOfModerator_GetAll(GitUserId(), true), "Id", "FullName");
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId(), true), "ID", "FullName");

            }
            if (!IsSupervisor())
            {
                ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.TEACHER), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName");

            }
            else
            {
                ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfSuperVisor_GetAll(GitUserId()), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");

            }
            if (StudentTeacher.Student != null)
            {
                ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(StudentTeacher.Student.FamilyId), "ID", "FullName");
                StudentTeacher.FamilyId = StudentTeacher.Student.FamilyId;
            }
            else
            {
                ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");
                StudentTeacher.FamilyId = new Guid();
            }
            return View("StudentTeachers", StudentTeacher);

        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentTeacherRM model)
        {
            try
            {

                await _StudentTeacherManager.StudentTeacher_Update(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "StudentTeacher");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "StudentTeacher", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {

                await _StudentTeacherManager.StudentTeacher_Delete(Id, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Home");
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

