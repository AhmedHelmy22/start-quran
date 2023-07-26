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
using StartQuran.Service.TeacherService.Model;

namespace StartQuran.Service.TeacherService
{
    public class TeacherManager : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager _Role;
        private readonly IRepository<Teacher> _Teacher;

        public TeacherManager(RoleManager Role, IRepository<Teacher> Teacher, UserManager<ApplicationUser> userManager)
        {
            _Role = Role;
            _Teacher = Teacher;
            _userManager = userManager;

        }

        #region Create
        public async Task<ApplicationUser> Registeration(TeacherRM model)
        {
            IdentityResult result = new IdentityResult();

            var user = new Teacher
            {
                FullName = model.fullName,
                UserName = model.phone,
                Gender = model.Gender,
                Age = model.Age,
                PhoneNumber = model.phone,
                Governorate = model.Governorate,
                SupervisorId = model.SupervisorId,
                Email =   model.phone + "@StartQuran.com",
                EmailConfirmed = true,
                ZoomLink = model.ZoomLink,
                EducationalQualification = model.EducationalQualification,
                SallaryBerHour = model.SallaryBerHour,
                Supervisor = model.Supervisor,
                usertype=UserType.TEACHER,
                PhoneNumberConfirmed=true,
                IDNumber = model.IDNumber
                
            };
            result = await _userManager.CreateAsync(user, model.password);
            await _Role.Role_Create(user, UserType.TEACHER);
            return user;
        }
        #endregion

        #region Update
        public async Task<ApplicationUser> Update(TeacherRM model)
        {
            IdentityResult result = new IdentityResult();
            Teacher user = (Teacher)await _userManager.FindByIdAsync(model.Id);

            user.FullName = model.fullName;
            user.UserName = model.phone;
            user.Email = model.phone + "@StartQuran.com";
            user.Age = model.Age;
            user.Gender = model.Gender;
            user.PhoneNumber = model.phone;
            user.Governorate = model.Governorate;
            user.ZoomLink = model.ZoomLink;
            user.EducationalQualification = model.EducationalQualification;
            user.SallaryBerHour = model.SallaryBerHour;
            user.SupervisorId = model.SupervisorId;
            user.Supervisor = model.Supervisor;
            user.IDNumber = model.IDNumber;
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

        public async Task<ApplicationUser> UnDelete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            user.IsDeleted = false;
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

        public async Task<List<TeacherRM>> Get()
        {
            //var users =  _userManager.GetUsersInRoleAsync(UserType.TEACHER.ToString()).Result.Where(c => c.IsDeleted == false).ToList();
            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == false, "Supervisor").ToList();

            return ConVTeacherRM(model);
        }
        public List<TeacherRM> TeacherOfSuperVisor_GetAll(string id)
        {

            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == false && c.SupervisorId == id, "Supervisor").ToList();
            return ConVTeacherRM(model);
        }


        public async Task<List<TeacherRM>> GetDeleted()
        {
            //var users =  _userManager.GetUsersInRoleAsync(UserType.TEACHER.ToString()).Result.Where(c => c.IsDeleted == true).ToList();
            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == true, "Supervisor").ToList();

            return ConVTeacherRM(model);
        }
        public List<TeacherRM> TeacherOfSuperVisor_GetAllDeleted(string id)
        {

            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == true && c.SupervisorId == id, "Supervisor").ToList();
            return ConVTeacherRM(model);
        }

        public async Task<TeacherRM> Get(string Id)
        {
            var user =(Teacher)await _userManager.FindByIdAsync(Id);

            return new TeacherRM(user);
        }

        #endregion

        #region Helper
        public List<TeacherRM> ConVTeacherRM(IEnumerable<ApplicationUser> users)
        {
            List<TeacherRM> LTERM = new List<TeacherRM>();
            
            foreach (Teacher T in users)
            {
               
                    LTERM.Add(new TeacherRM
                    {
                        Id = T.Id,

                        fullName = T.FullName,

                        phone = T.PhoneNumber,

                        Governorate = T.Governorate,

                        ZoomLink = T.ZoomLink,

                        EducationalQualification = T.EducationalQualification,

                        SallaryBerHour = T.SallaryBerHour,
                        Gender = T.Gender,
                        Age = T.Age,

                        SupervisorId = T.SupervisorId,

                         Supervisor= T.Supervisor,
                         IDNumber = T.IDNumber
                         
                        

                    });
                
            }
            return LTERM;
        }

        #endregion

    }
}