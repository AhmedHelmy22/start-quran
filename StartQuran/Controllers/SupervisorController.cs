using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.Common;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.SupervisorService;
using StartQuran.Service.SupervisorService.Model;
using tarteel.Service.ModeratorTeacherManager;
using tarteel.Service.ModeratorTeacherService.Model;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,Moderator")]
    public class SupervisorController : Controller
    {
        private readonly IRepository<Teacher> _AppUser;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SupervisorManager _SupervisorManager;
        private readonly StudentManager _StudentManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly FamilyManager _FamilyManager;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        public SupervisorController(ModeratorSupervisorManager ModeratorSupervisorManager,UserManager<ApplicationUser> _userManager, StudentManager StudentManager,SupervisorManager SupervisorManager, FamilyManager FamilyManager, StudentTeacherManager StudentTeacherManager, IRepository<Teacher> AppUser)
        {
            _StudentManager = StudentManager;

            this._userManager = _userManager;
            _SupervisorManager = SupervisorManager;
            _AppUser = AppUser;
            _FamilyManager = FamilyManager;
            _StudentTeacherManager = StudentTeacherManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {
            var LSVRM = await _SupervisorManager.Get();
            return View("Index",LSVRM);
        }

        

        [HttpGet]
        public IActionResult Teacher(string id)
        {
            var LSVRM = _StudentTeacherManager.TeacherOfSuperVisor_GetAll(id);
            return View("Teachers", LSVRM);
        }
        [HttpGet]

        public IActionResult Family(string id)
        {
            var LSVRM =  _FamilyManager.FamilyOfSuperVisor_GetAll(id);
            return View("Family", LSVRM);
        }
        public IActionResult Students(Guid id)
        {
            var sList = _StudentManager.Studentlist_GetByFamily(id);
            return View(sList);
        }
        #endregion

        #region Moderator

            public async Task<IActionResult> Moderator()
            {
                var LSVRM = await _SupervisorManager.GetModerator();
                return View("Moderator", LSVRM);
            }


            public async Task<IActionResult> Supervisors(string id)
            {
                if (id == null) id = GitUserId();
                var LSVRM =  _ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(id);
                return View("Supervisors", LSVRM);
            }

            [HttpGet]
            public IActionResult ModeratorTeacher(string id)
            {
                if(id == null) id = GitUserId();
                var LSVRM = _ModeratorSupervisorManager.TeacherOfModerator_GetAll(id);
                return View("Teachers", LSVRM);
            }
            [HttpGet]

            public IActionResult ModeratorFamily(string id)
            {
                if (id == null) id = GitUserId();
                var LSVRM = _ModeratorSupervisorManager.FamilyOfModerator_GetAll(id);
                    return View("Family", LSVRM);
            }
            public IActionResult ModeratorStudents(string id)
            {
                if (id == null) id = GitUserId();
                var sList = _ModeratorSupervisorManager.StudentOfModerator_GetAll(id);


                return View("Students", sList);
            }

            public IActionResult ModeratorStudentsTeacher(string id)
            {
                if (id == null) id = GitUserId();
                var sList = _ModeratorSupervisorManager.StudentTeacherOfModerator_GetAll(id);


                return View("StudentsTeacher", sList);
            }

            public IActionResult ModeratorStudentsMarketer(string id)
            {
                if (id == null) id = GitUserId();
                var SList = _ModeratorSupervisorManager.StudentMarketerOfModerator_GetAll(id);

                

                return View("StudentsMarketer", SList);
            }

        #endregion
        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);
            return View("Supervisor", new SupervisorRM());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupervisorRM model)
        {
            if (_userManager.Users.Where(c => c.PhoneNumber == model.phone).Count() != 0)
            {
                TempData["AlertMessage"] = "phoneExist";
                return RedirectToAction("Create", "Supervisor");
            }
            try
            {
                await _SupervisorManager.Registeration(model);
                if (IsModerator())
                {
                    var superv =  _SupervisorManager.Get().Result.SingleOrDefault(x => x.phone == model.phone).Id;
                   await _ModeratorSupervisorManager.ModeratorTeacher_Create(superv, GitUserId());
                }
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Supervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Create);
                return View("Supervisor", model);
            }
        }

        #endregion


        #region Update
        public IActionResult Update(string id )
        {
            ViewBag.ActionName = nameof(Update);
            SupervisorRM SRM =  _SupervisorManager.Get(id).Result;
            return View("Supervisor",SRM);
          
        }

        [HttpPost]
        public async Task<IActionResult> Update(SupervisorRM model)
        {
            if (_userManager.Users.Where(c => c.Id != model.Id && c.PhoneNumber == model.phone  ).Count()!=0)
            {
               
                TempData["AlertMessage"] = "phoneExist";
                ViewBag.ActionName = nameof(Update);
                return View("Supervisor", model);
            }
            try
            {
                await _SupervisorManager.Update(model);
                TempData["AlertMessage"] = "Done";
                if(IsModerator())
                    return RedirectToAction("Supervisors", "Supervisor");
                return RedirectToAction("Index", "Supervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                if (IsModerator())
                    return RedirectToAction("Supervisors", "Supervisor");
                return RedirectToAction("Index", "Supervisor");
            }
        }





        
        public async Task<IActionResult> UpdateRoleToModerator(string id)
        {
           
            try
            { 
                await _SupervisorManager.ChangeRole(id,UserType.SUPERVISOR,UserType.Moderator);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Supervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Index", "Supervisor");
            }
        }

        
        public async Task<IActionResult> UpdateRoleToSupervisor(string id)
        {

            try
            {
                await _SupervisorManager.ChangeRole(id, UserType.Moderator, UserType.SUPERVISOR);
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Supervisor");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Index", "Supervisor");
            }
        }
        #endregion



        #region Delete


        public async Task<IActionResult> Delete(string Id)
        {
            try
            {
                //var teacher =await _AppUser.FirstOrDefault(t => t.SupervisorId == Id && t.IsDeleted == false);
                //if (teacher != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Supervisor");
                //}
                await _SupervisorManager.Delete(Id);
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
        #endregion
    }
}