using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace StartQuran.Service.Roles
{
    public class RoleManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RoleManager(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task Role_Create (ApplicationUser User ,UserType UType)
        {
            await _userManager.AddToRoleAsync(User, UType.ToString());
        }

        public async Task Role_Remove(ApplicationUser User, UserType OldRole)
        {
            await _userManager.RemoveFromRoleAsync(User, OldRole.ToString());
        }


        public async Task Role_Change(ApplicationUser supervisor, UserType OldRole, UserType NewRole)
        {
           await Role_Remove(supervisor, OldRole);
            await Role_Create(supervisor, NewRole);

        }


    }
}
