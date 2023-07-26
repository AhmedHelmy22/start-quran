using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.BaseService.Model;
using StartQuran.Service.Roles;
using StartQuran.Service.TeacherService.Model;
//using Microsoft.AspNet.Identity;

namespace StartQuran.Service.BaseService
{
    public class BaseManager : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
      
        public BaseManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;

        }
        #region Hepler
 
        public async Task<IdentityResult> ChangeUserPassword(ChangePassword model,ApplicationUser user)
        {
            IdentityResult result = new IdentityResult();
            
            result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            return result;
        }
        public async Task<IdentityResult> ForgetPassword(ForgetPassword model, ApplicationUser user)
        {
            var result = await _userManager.RemovePasswordAsync(user);
            if (result.Succeeded)
            {
                result = await _userManager.AddPasswordAsync(user, model.NewPassword);
             
            }
     
   
            return result;
        }

        #endregion

    }
}