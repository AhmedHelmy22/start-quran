using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.Enums;
using StartQuran.Service.BaseService;
using StartQuran.Service.BaseService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StartQuran.Controllers
{
    [Authorize(Roles = "ADMIN,SUPERVISOR,TEACHER")]

    public class BaseController : Controller
    {
        private readonly BaseManager _BaseManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public BaseController(BaseManager BaseManager, UserManager<ApplicationUser> userManager)
        {

            _BaseManager = BaseManager;
            _userManager = userManager;


        }
        #region UpdatePassword
        [HttpGet]
        public IActionResult UpdatePassword()
        {
                return View( new ChangePassword());

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(ChangePassword model)
        {
            try
            {
                var _UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var CurrentUser =await _userManager.FindByIdAsync(_UserId);
               var result= await _BaseManager.ChangeUserPassword(model, CurrentUser);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Done";
                    return RedirectToAction("Index", "Home");
                }
                else {
                    TempData["AlertMessage"] = "Error";
                    return RedirectToAction("UpdatePassword", "Base");
                }
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("UpdatePassword", "Base");
            }
        }

        #endregion
        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View(new ForgetPassword());

        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassword model)
        {
            try
            {
                var CurrentUser = _userManager.Users.Where(c => c.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                var result=await _BaseManager.ForgetPassword(model, CurrentUser);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Done";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["AlertMessage"] = "Error";
                    return RedirectToAction("UpdatePassword", "Base");
                }
         
            }
            catch (Exception _)
            {
                TempData["AlertMessage"] = "Error";
                return RedirectToAction("UpdatePassword", "Base");
            }
        }

        #endregion
        #region 


        #endregion
    }
}
