using Microsoft.AspNetCore.Identity;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.Roles;
using StartQuran.Service.SupervisorService.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.SupervisorService
{
    public class SupervisorManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager _Role;

        public SupervisorManager(RoleManager Role, UserManager<ApplicationUser> userManager)
        {
            _Role = Role;
            _userManager = userManager;

        }

        #region Create
        public async Task<ApplicationUser> Registeration(SupervisorRM model)
        {
            IdentityResult result = new IdentityResult();

            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.phone,
                Gender = model.Gender,
                Age = model.Age,
                PhoneNumber = model.phone,
                Governorate = model.Governorate,
                Email = model.phone + "@StartQuran.com",
                EmailConfirmed = true,
                usertype = UserType.SUPERVISOR,
                PhoneNumberConfirmed=true
            };

           result =  await _userManager.CreateAsync(user, model.password);
            await _Role.Role_Create(user, UserType.SUPERVISOR);
            
            return user;
        }

        #endregion

        #region Update
        public async Task<ApplicationUser> Update(SupervisorRM model)
        {
            IdentityResult result = new IdentityResult();
            var user = await _userManager.FindByIdAsync(model.Id);
            user.UserName = model.phone;
            user.Email = model.phone + "@StartQuran.com";
            user.FullName = model.FullName;
            user.PhoneNumber = model.phone;
            user.Governorate = model.Governorate;
            user.Gender = model.Gender;
            user.Age = model.Age;
            result = await _userManager.UpdateAsync(user);
            return user;
        }


        public async Task<ApplicationUser> ChangeRole(string SupId,UserType Oldrole, UserType Newrole)
        {
            IdentityResult result = new IdentityResult();
            var user = await _userManager.FindByIdAsync(SupId);

            await _Role.Role_Change(user,Oldrole,Newrole);
            return user;
        }

        public async Task<ApplicationUser> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.IsDeleted = true;
            await _userManager.UpdateAsync(user);
            return user;
        }


        #endregion

        #region Get

        public async Task<IList<SupervisorRM>> Get()
        {
            
                var users = _userManager.GetUsersInRoleAsync(UserType.SUPERVISOR.ToString()).Result.Where(c => c.IsDeleted == false).ToList();

                return ConVSupervisorRM(users);
            
            
        }

        public async Task<IList<SupervisorRM>> GetModerator()
        {
            var users = _userManager.GetUsersInRoleAsync(UserType.Moderator.ToString()).Result.Where(c => c.IsDeleted == false);
            return ConVSupervisorRM(users);
        }

        public async Task<SupervisorRM> Get(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            return new SupervisorRM(user);
        }

        public async Task<IdentityResult> ChangePassword(string Id, string OldPassword, string NewPassword)
        {
            IdentityResult result = new IdentityResult();
            result = await _userManager.ChangePasswordAsync(await _userManager.FindByIdAsync(Id), OldPassword, NewPassword);

            return result;
        }
        #endregion

        #region Helper
        public List<SupervisorRM> ConVSupervisorRM(IEnumerable<ApplicationUser> users)
        {
            List<SupervisorRM> LsupRM = new List<SupervisorRM>();

            foreach (var sp in users)
            {
                
                if (!sp.IsDeleted)
                {
                    LsupRM.Add(new SupervisorRM
                    {
                        Id = sp.Id,

                        FullName = sp.FullName,
                        phone = sp.PhoneNumber,
                        Gender = sp.Gender,
                        Age = sp.Age,
                        Governorate = sp.Governorate,
                        //ModeratorId = sp.ModeratorId,
                        //Moderator = sp.Moderator
                });
                }
            }
            return LsupRM;
        }

        #endregion


    }
}
