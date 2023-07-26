using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tarteel.Service.ModeratorTeacherManager;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,MARKETER,Moderator")]

    public class StudentController : Controller
    {
        private readonly StudentManager _StudentManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FamilyManager _FamilyManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;

        public StudentController(ModeratorSupervisorManager ModeratorSupervisorManager, StudentManager StudentManager, FamilyManager FamilyManager, UserManager<ApplicationUser> userManager, StudentTeacherManager StudentTeacherManager)
        {
            _FamilyManager = FamilyManager;
            _StudentTeacherManager = StudentTeacherManager;

            _StudentManager = StudentManager;
            _userManager = userManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {

            var SList = new List<Student>();
            if (IsSupervisor() || IsModerator())
            {
                SList = _StudentManager.StudentOfSupervisor_GetAll(GitUserId());
            }
            else
            {
                SList = _StudentManager.Student_GetAll();
            }

            return View("Index", SList);
        }
        public IActionResult Teacher(Guid id)
        {
            var LSVRM = _StudentTeacherManager.TeacherOfstudent_GetAll(id);
            return View("Teachers", LSVRM);
        }
        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
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
            return View("Students", new Student());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student model)
        {
            try
            {

                await _StudentManager.Student_Create(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Student");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "Student");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            var Student = _StudentManager.Student_Get(id);
            if (IsSupervisor())
            {
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName", Student.FamilyId);

            }
            else if (IsModerator())
            {
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId(), true), "ID", "FullName", Student.FamilyId);

            }
            else
            {
                ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName", Student.FamilyId);
            }



            return View("Students", Student);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Student model)
        {
            try
            {

                await _StudentManager.Student_Update(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                if (IsModerator())
                    return RedirectToAction("ModeratorStudents", "Supervisor");
                return RedirectToAction("Index", "Student");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                if (IsModerator())
                    return RedirectToAction("ModeratorStudents", "Supervisor");
                return RedirectToAction("Update", "Student", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                //var Student = _StudentTeacherManager.Student_Get(Id);
                //if (Student != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _StudentManager.Student_Delete(Id, GitUserId());
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

        #endregion

    }
}
