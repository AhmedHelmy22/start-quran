using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "TEACHER")]

    public class TeacherDataController : Controller
    {
        private readonly StudentManager _StudentManager;
        private readonly FamilyManager _FamilyManager;
        public TeacherDataController(FamilyManager FamilyManager, StudentManager StudentManager)
        {
            _StudentManager = StudentManager;
          
            _FamilyManager = FamilyManager;
      
        }
        public IActionResult Family()
        {

            var FList = _FamilyManager.GetFamilyOfStudent(GitUserId());


            return View(FList);
        }
        public IActionResult Students(Guid id)
        {

            var sList = _StudentManager.Studentlist_GetByFamily(id);

            return View(sList);
        }
        #region Helper

        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }

        #endregion
    }
}
