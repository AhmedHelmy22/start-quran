using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Areas.Identity.Data;
using StartQuran.Service.SectionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using StartQuran.Models.DataBase;
using Microsoft.AspNetCore.Mvc.Rendering;
using StartQuran.Models.Enums;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.FamilyService;
using StartQuran.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using tarteel.Service.ModeratorTeacherManager;
using StartQuran.Service.TeacherService;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,TEACHER,Moderator")]

    public class SectionController : Controller
    {
        private readonly SectionManager _SectionManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StudentManager _StudentManager;
        private readonly StudentTeacherManager _StudentTeacherManager;
        private readonly FamilyManager _FamilyManager;
        private readonly IRepository<ApplicationUser> _AppUser;
        private readonly ModeratorSupervisorManager _ModeratorSupervisorManager;
        private readonly TeacherManager _TeacherManager;

        public SectionController(TeacherManager TeacherManager, ModeratorSupervisorManager ModeratorSupervisorManager,StudentManager StudentManager, IRepository<ApplicationUser> AppUser, FamilyManager FamilyManager, SectionManager SectionManager, UserManager<ApplicationUser> userManager, StudentTeacherManager StudentTeacherManager)
        {

            _AppUser = AppUser;

            _StudentManager = StudentManager;
            _FamilyManager = FamilyManager;
            _StudentTeacherManager = StudentTeacherManager;
            _SectionManager = SectionManager;
            _userManager = userManager;
            _ModeratorSupervisorManager = ModeratorSupervisorManager;
            _TeacherManager = TeacherManager;
        }

        #region Get

        public async Task<IActionResult> Index()
        {

            var SList = new List<Section>();
            if (IsSupervisor())
            {
                SList = _SectionManager.SectionSupervisor_GetAll(GitUserId());
            }
            else if (IsModerator())
            {
                var Supervisors = _ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(GitUserId());
                foreach (var su in Supervisors)
                {
                    SList.AddRange(_SectionManager.SectionSupervisor_GetAll(su.Id));
                }
                SList.AddRange(_SectionManager.SectionSupervisor_GetAll(GitUserId()));
            }
            else if (IsTeacher())
            {
                SList = _SectionManager.SectionTeacher_GetAll(GitUserId());
            }
            else
            {
                SList = _SectionManager.Section_GetAll();
            }
            ViewBag.DateShow = DateTime.Now;
            return View("Index", SList);
        }

        public async Task<IActionResult> IndexDate(DateTime Date)
        {

            var SList = new List<Section>();
            if (IsSupervisor())
            {
                SList = _SectionManager.SectionSupervisor_GetAll(GitUserId(),Date);
            }
            else if (IsModerator())
            {
                var Supervisors = _ModeratorSupervisorManager.SuperVisor_Moderator_GetAll(GitUserId());
                foreach (var sp in Supervisors)
                {
                    SList.AddRange(_SectionManager.SectionSupervisor_GetAll(sp.Id, Date));
                }
                SList.AddRange(_SectionManager.SectionSupervisor_GetAll(GitUserId(), Date));
            }
            else if (IsTeacher())
            {
                SList = _SectionManager.SectionTeacher_GetAll(GitUserId(),Date);
            }
            else
            {
                SList = _SectionManager.Section_GetAll(Date);
            }
            ViewBag.DateShow = Date;
            return View("Index", SList);
        }

        #endregion

        #region Get Teacher

        public async Task<IActionResult> Teacher(string ID)
        {

            var SList = new List<Section>();
                       
            SList = _SectionManager.SectionTeacher_GetAll(ID);
          
                       ViewBag.DateShow = DateTime.Now;
            return View("Teacher", SList);
        }

        public async Task<IActionResult> TeacherDate(string ID, DateTime Date)
        {

            var SList = new List<Section>();
           
           
                SList = _SectionManager.SectionTeacher_GetAll(ID, Date);
            
          
            ViewBag.DateShow = Date;
            return View("Teacher", SList);
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewBag.ActionName = nameof(Create);

            if (IsTeacher())
            {
                ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.Id == GitUserId()), "Id", "FullName", GitUserId());
                ViewBag.Family = new SelectList(_FamilyManager.GetFamilyOfStudent(GitUserId()), "ID", "FullName");

            }
            else if (IsSupervisor())
            {
                ViewBag.Teacher = new SelectList(new List<Teacher>(), "ID", "FullName");

                //ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfSuperVisor_GetAll(GitUserId()), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");

            }
            else if (IsModerator())
            {
                ViewBag.Teacher = new SelectList(new List<Teacher>(), "ID", "FullName");

                //ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfSuperVisor_GetAll(GitUserId()), "Id", "FullName");
                ViewBag.Family = new SelectList(_ModeratorSupervisorManager.FamilyOfModerator_GetAll(GitUserId(), true), "ID", "FullName");

            }
            else
            {
                ViewBag.Teacher = new SelectList(new List<Teacher>(), "ID", "FullName");

                //ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.IsDeleted == false && c.usertype == UserType.TEACHER), "Id", "FullName");
                ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName");

            }
            //ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");
            ViewBag.Student = new SelectList(new List<Student>(), "ID", "FullName");

            return View("Sections", new Section());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Section model)
        {
            try
            {

                await _SectionManager.Section_Create(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Create", "Section");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Create", "Section");
            }
        }

        #endregion


        #region Update
        public async Task<IActionResult> Update(Guid id)
        {
            ViewBag.ActionName = nameof(Update);
            var Section = _SectionManager.Section_Get(id);
            if (Section.Student != null)
            {
                ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(Section.Student.FamilyId), "ID", "FullName");
            }
            else
            {
                ViewBag.Student = new SelectList(new List<Student>(), "ID", "FullName");

                //  ViewBag.Student = new SelectList(_StudentManager.Studentlist_GetByFamily(new Guid()), "ID", "FullName");
            }
            if (IsTeacher())
            {
                ViewBag.Teacher = new SelectList(_AppUser.Get(c => c.Id == GitUserId()), "Id", "FullName");
                if (Section.Student != null)
                {
                    ViewBag.Family = new SelectList(_FamilyManager.GetFamilyOfStudent(GitUserId()), "ID", "FullName", Section.Student.FamilyId);
                }
                else
                {
                    ViewBag.Family = new SelectList(_FamilyManager.GetFamilyOfStudent(GitUserId()), "ID", "FullName");

                }
            }
            else if (IsSupervisor())
            {
                ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfstudent_GetAll(Section.StudentId), "Id", "FullName");
                if (Section.Student != null)
                {
                    ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName", Section.Student.FamilyId);

                }
                else
                {
                    ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");
                }
            }
            else if (IsSupervisor())
            {
                ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfstudent_GetAll(Section.StudentId), "Id", "FullName");
                if (Section.Student != null)
                {
                    ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName", Section.Student.FamilyId);

                }
                else
                {
                    ViewBag.Family = new SelectList(_FamilyManager.FamilyOfSuperVisor_GetAll(GitUserId()), "ID", "FullName");
                }
            }
            else
            {
                ViewBag.Teacher = new SelectList(_StudentTeacherManager.TeacherOfstudent_GetAll(Section.StudentId), "Id", "FullName");
                if (Section.Student != null)
                {
                    ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName", Section.Student.FamilyId);

                }
                else
                {
                    ViewBag.Family = new SelectList(_FamilyManager.GetAll(), "ID", "FullName");
                }

            }



            return View("Sections", Section);

        }

        [HttpPost]
        public async Task<IActionResult> Update(Section model)
        {
            try
            {

                await _SectionManager.Section_Update(model, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Section");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                ViewBag.ActionName = nameof(Update);
                return RedirectToAction("Update", "Section", new { id = model.ID });
            }
        }

        #endregion



        #region Delete
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                //var Section = _SectionTeacherManager.Section_Get(Id);
                //if (Section != null)
                //{
                //    TempData["AlertMessage"] = "CanotDelete";
                //    return RedirectToAction("Index", "Family");
                //}
                await _SectionManager.Section_Delete(Id, GitUserId());
                TempData["AlertMessage"] = "Done";
                return RedirectToAction("Index", "Section");
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("Index", "Section");
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
        public bool IsTeacher()
        {
            return User.IsInRole(UserType.TEACHER.ToString());
        }
        [HttpGet]
        public IActionResult StudentData(Guid id)
        {
            if (id != Guid.Empty)
            {
                List<Student> Student = new List<Student>();
                if (IsTeacher())
                {
                    Student = _StudentManager.StudentGetByFamilyOfTeacher(id, GitUserId());
                }
                else
                {
                    Student = _StudentManager.Studentlist_GetByFamily(id);

                }


                return Json(Student);
            }

            else
            {
                return Json(new { data = "" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> TeacherData(Guid id)
        {
            if (id != Guid.Empty)
            {
                List<Teacher> Teacher = new List<Teacher>();

                if (IsTeacher())
                {
                    var te = await _TeacherManager.Get(GitUserId());
                    Teacher.Add(new Teacher() { FullName=te.fullName,Id=te.Id});
                }
                else
                Teacher = _StudentTeacherManager.TeacherOfstudent_GetAll(id);


                return Json(Teacher);
            }

            else
            {
                return Json(new { data = "" });
            }
        }

       
        #endregion
    }
}
