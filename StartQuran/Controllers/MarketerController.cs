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
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentService;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.MarketerService;
using StartQuran.Service.MarketerService.Model;
using StartQuran.Service.StudentMarketerService;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,MARKETER")]
    public class MarketerController : Controller
    {
        private readonly IRepository<Teacher> _AppUser;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly MarketerManager _MarketerManager;
        private readonly StudentMarketerManager _StudentMarketerManager;
        private readonly StudentManager _StudentManager;
    //private readonly StudentMarketerManager _StudentTeacherManager;

    public MarketerController(StudentMarketerManager StudentMarketerManager,UserManager<ApplicationUser> _userManager, StudentManager StudentManager, MarketerManager MarketerManager, FamilyManager FamilyManager, StudentTeacherManager StudentTeacherManager, IRepository<Teacher> AppUser)
    {
        _StudentManager = StudentManager;

        this._userManager = _userManager;
        _MarketerManager = MarketerManager;
        _AppUser = AppUser;
        _StudentMarketerManager = StudentMarketerManager;
        //_StudentTeacherManager = StudentTeacherManager;
    }

    #region Get

    public async Task<IActionResult> Index()
    {
        var LSVRM = await _MarketerManager.Get();
        return View("Index", LSVRM);
    }

    public async Task<IActionResult> Students(string id=null)
    {
        if (id == null)
        {
            var LSRM = _StudentMarketerManager.StudentOfMarketer_GetAll(GitUserId());
            return View("Students", LSRM);
        }
        else
        {
            var LSRM = _StudentMarketerManager.StudentOfMarketer_GetAll(id);
            return View("Students", LSRM);
        }
        
    }

        #endregion

        #region Create
        public IActionResult Create()
    {
        ViewBag.ActionName = nameof(Create);
        return View("Marketer", new MarketerRM());
    }

    [HttpPost]
    public async Task<IActionResult> Create(MarketerRM model)
    {
        if (_userManager.Users.Where(c => c.PhoneNumber == model.phone).Count() != 0)
        {
            TempData["AlertMessage"] = "phoneExist";
            return RedirectToAction("Create", "Marketer");
        }
        try
        {
            await _MarketerManager.Registeration(model);
            TempData["AlertMessage"] = "Done";
            return RedirectToAction("Create", "Marketer");
        }
        catch (Exception _)
        {
            TempData["AlertMessage"] = "Error";
            ViewBag.ActionName = nameof(Create);
            return View("Marketer", model);
        }
    }

    #endregion


    #region Update
    public IActionResult Update(string id)
    {
        ViewBag.ActionName = nameof(Update);
        MarketerRM SRM = _MarketerManager.Get(id).Result;
        return View("Marketer", SRM);

    }

    [HttpPost]
    public async Task<IActionResult> Update(MarketerRM model)
    {
        if (_userManager.Users.Where(c => c.Id != model.Id && c.PhoneNumber == model.phone).Count() != 0)
        {

            TempData["AlertMessage"] = "phoneExist";
            ViewBag.ActionName = nameof(Update);
            return View("Marketer", model);
        }
        try
        {
            await _MarketerManager.Update(model);
            TempData["AlertMessage"] = "Done";
            return RedirectToAction("Index", "Marketer");
        }
        catch (Exception _)
        {
            TempData["AlertMessage"] = "Error";
            ViewBag.ActionName = nameof(Update);
            return View("Marketer", model);
        }
    }

    #endregion



    #region Delete
    [HttpPost]

    public async Task<IActionResult> Delete(string Id)
    {
        try
        {
            
            await _MarketerManager.Delete(Id);
            TempData["AlertMessage"] = "Done";
            return RedirectToAction("Index", "Marketer");
        }
        catch (Exception _)
        {
            TempData["AlertMessage"] = "Error";
            return RedirectToAction("Index", "Marketer");
        }
    }
        //[HttpPost]
        //public async Task<JsonResult> Delete(string Id)
        //{
        //    ActionExcution result = new ActionExcution();

        //    try
        //    {
        //        var teacher = _AppUser.FirstOrDefault(t => t.MarketerId == Id && t.IsDeleted == false).Result;
        //        if (teacher != null)
        //        {
        //            result.Message = "لا يمكن حذف هذا المشرف لانه مرتبط بمدرسين";
        //            result.Success = false;
        //        }
        //        await _MarketerManager.Delete(Id);
        //        result.Message = "تم الحذف بنجاح";
        //        result.Success = true;
        //    }
        //    catch (Exception _)
        //    {
        //        result.Message = "حدث خطا";
        //        result.Success = false;
        //    }



        //    return Json(result);
        //}
        #endregion


        public string GitUserId()
        {
            var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return _UserId;

        }
    }
}
