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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tarteel.Service.ModeratorTeacherManager;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,MARKETER,Moderator")]

    public class FamilyController : Controller
    {
       
        private readonly FamilyManager _FamilyManager;
        private readonly StudentManager _StudentManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly IRepository<Family> _Family;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;

        public FamilyController(ModeratorSupervisorManager ModeratorSupervisorManager,IRepository<Family> Family,StudentManager StudentManager, FamilyManager FamilyManager, UserManager<ApplicationUser> userManager, StudentTeacherManager StudentTeacherManager, IRepository<ApplicationUser> AppUser)
        {
            _StudentManager = StudentManager;
            _AppUser = AppUser;
            _Family = Family;
            _FamilyManager = FamilyManager;
            _userManager = userManager;
            _StudentTeacherManager = StudentTeacherManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {
           
            var FList = new List<Family>();
            if (IsSupervisor() || IsModerator())
            {
                FList = _FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId());
            }
            else
            {
                FList = _FamilyManager.Family_GetAll();
            }

            return View("Index", FList);
        }

        public async Task<IActionResult> FamilyDelete()
        {

            var FList = new List<Family>();
            if (IsSupervisor())
            {
                FList = _FamilyManager.FamilyOfSuperVisor_GetAllDelete(GitUserId());
            }
            else
            {
                FList = _FamilyManager.Family_GetAllDelete();
            }

            return View("Deleted", FList);
        }
        public IActionResult Students(Guid id)
        {

            var sList = _StudentManager.Studentlist_GetByFamily(id);


            return View(sList);
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
                ViewBag.Supervisors = new SelectList(_AppUser.Get(c => c.Id == GitUserId()), "Id", "FullName", GitUserId());

            }
            else if (IsModerator())
            {

                ViewBag.Supervisors = new SelectList(_ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(GitUserId(), true), "Id", "FullName", GitUserId());

            }
            else
            {
                ViewBag.Supervisors = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.SUPERVISOR), "Id", "FullName");
            }
            return View("Families", new Family());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Family model)
        {
          

            try
            {

                await _FamilyManager.Family_Create(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Family");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "Family");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            if (IsSupervisor())
            {
                ViewBag.Supervisors = new SelectList(_AppUser.Get(c => c.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)), "Id", "FullName");
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
            var Family =  _FamilyManager.Family_Get(id);

              return View("Families", Family);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Family model)
        {
           
            try
            {

                await _FamilyManager.Family_Update(model, GitUserId());
                if (IsModerator())
                    return RedirectToAction("ModeratorFamily", "Supervisor");
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Family");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                if (IsModerator())
                    return RedirectToAction("ModeratorFamily", "Supervisor");
                return RedirectToAction("Update", "Family", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                //var Student = _StudentManager.Student_GetByFamily(Id);
                //if (Student != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _FamilyManager.Family_Delete(Id, GitUserId());
                TempData["AlertMessage"] = "Done";
                await DeleteStudent(Id, GitUserId());
                return RedirectToAction("Index", "Family");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Family");
            }
        }

        public async Task<IActionResult> UnDelete(Guid Id)
        {
            try
            {
                //var Student = _StudentManager.Student_GetByFamily(Id);
                //if (Student != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _FamilyManager.Family_UnDelete(Id, GitUserId());
                TempData["AlertMessage"] = "Done";
                await UnDeleteStudent(Id, GitUserId());
                return RedirectToAction("Index", "Family");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Family");
            }
        }
        #endregion

        #region Helper
        public bool IsModerator()
        {
            return User.IsInRole(UserType.Moderator.ToString());
        }
        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }
        public bool IsSupervisor()
        {
            return User.IsInRole(UserType.SUPERVISOR.ToString());
        }

        public async Task DeleteStudent(Guid FamilyId, string UserId)
        {
            Family fam =_FamilyManager.Family_Get(FamilyId);
            List<Student> stus = _StudentManager.Studentlist_GetByFamily(FamilyId);
            foreach (Student student in stus)
            {
                await _StudentManager.Student_Delete(student.ID, UserId);
            }


        }

        public async Task UnDeleteStudent(Guid FamilyId, string UserId)
        {
            Family fam = _FamilyManager.Family_Get(FamilyId);
            List<Student> stus = _StudentManager.StudentDeletelist_GetByFamily(FamilyId);
            foreach (Student student in stus)
            {
                await _StudentManager.Student_UnDelete(student.ID, UserId);
            }


        }


        #endregion


    }
}
