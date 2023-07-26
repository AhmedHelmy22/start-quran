using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using StartQuran.Models.Repository;
using StartQuran.Service.Roles;
using StartQuran.Service.MarketerService.Model;
using StartQuran.Service.StudentMarketerService;

namespace StartQuran.Service.MarketerService
{
    public class MarketerManager : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager _Role;
        private readonly IRepository<Marketer> _Marketer;
        private readonly StudentMarketerManager _StudentMarketerManager;
        public MarketerManager(StudentMarketerManager StudentMarketer, RoleManager Role, IRepository<Marketer> Marketer, UserManager<ApplicationUser> userManager)
        {
            _Role = Role;
            _Marketer = Marketer;
            _userManager = userManager;
            _StudentMarketerManager = StudentMarketer;
        }

        #region Create
        public async Task<ApplicationUser> Registeration(MarketerRM model)
        {
            IdentityResult result = new IdentityResult();

            var user = new Marketer
            {
                FullName = model.fullName,
                UserName = model.phone,
                Gender = model.Gender,
                Age = model.Age,
                PhoneNumber = model.phone,
                Governorate = model.Governorate,
                Email = model.phone + "@StartQuran.com",
                EmailConfirmed = true,         
                usertype = UserType.MARKETER,
                PhoneNumberConfirmed = true,
                Salary = model.Salary, 
                Ratio = model.Ratio
            };
            result = await _userManager.CreateAsync(user, model.password);
            await _Role.Role_Create(user, UserType.MARKETER);
            return user;
        }
        #endregion

        #region Update
        public async Task<ApplicationUser> Update(MarketerRM model)
        {
            IdentityResult result = new IdentityResult();
            Marketer user = (Marketer)await _userManager.FindByIdAsync(model.Id);

            user.FullName = model.fullName;
            user.UserName = model.phone;
            user.Email = model.phone + "@StartQuran.com";
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.PhoneNumber = model.phone;
            user.Governorate = model.Governorate;
           
            user.Salary=model.Salary;
            user.Ratio = model.Ratio;
            result = await _userManager.UpdateAsync(user);
            return user;
        }

        public async Task<ApplicationUser> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.IsDeleted = true;
            await _userManager.UpdateAsync(user);
            return user;
        }

        //public async Task<IdentityResult> ChangePassword(string Id, string OldPassword, string NewPassword)
        //{
        //    IdentityResult result = new IdentityResult();
        //    result = await _userManager.ChangePasswordAsync(await _userManager.FindByIdAsync(Id), OldPassword, NewPassword);

        //    return result;
        //}
        #endregion

        #region Get

        public async Task<List<MarketerRM>> Get()
        {
            var users = _userManager.GetUsersInRoleAsync(UserType.MARKETER.ToString()).Result.Where(c => c.IsDeleted == false).ToList();
            return ConVMarketerRM(users);
        }
      

        public async Task<MarketerRM> Get(string Id)
        {
            var user = (Marketer)await _userManager.FindByIdAsync(Id);

            return new MarketerRM(user);
        }

        public async Task<List<Student>> StudentMarketet_Get(string MId)
        {
            var SM = _StudentMarketerManager.StudentOfMarketer_GetAll(MId);

            return SM;
        }

        #endregion

        #region Helper
        public List<MarketerRM> ConVMarketerRM(IEnumerable<ApplicationUser> users)
        {
            List<MarketerRM> LTERM = new List<MarketerRM>();

            foreach (Marketer T in users)
            {
                if (!T.IsDeleted)
                {
                    LTERM.Add(new MarketerRM
                    {
                        Id = T.Id,
                        fullName = T.FullName,
                        phone = T.PhoneNumber,
                        Governorate = T.Governorate,                    
                        Gender = T.Gender,
                        Age = T.Age,
                       Salary = T.Salary,
                       Ratio = T.Ratio
                    });
                }
            }
            return LTERM;
        }

        #endregion

    }
}