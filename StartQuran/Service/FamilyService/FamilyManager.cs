using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.FamilyService
{
    public class FamilyManager
    {
        private readonly IRepository<Family> _Family;
        private readonly IRepository<StudentTeacher> _StudentTeacher;
       
        public FamilyManager(IRepository<Family> Family, IRepository<StudentTeacher> StudentTeacher)
        {
            _Family = Family;
            _StudentTeacher = StudentTeacher;
            
        }

        #region Family
        //---------Family--------------
        #region Get
        public List<Family> Family_GetAll()
        {
            return _Family.GetAll(c => c.IsDeleted == false, "Supervisor").ToList();
        }
        public List<Family> Family_GetAllDelete()
        {
            return _Family.GetAll(c => c.IsDeleted == true, "Supervisor").ToList();
        }
        public IEnumerable<Family> GetAll()
        {
            return _Family.Get(c => c.IsDeleted == false);
        }
        public List<Family> GetFamilyOfStudent(string id)
        {
            List<Family> family = new List<Family>();
           var x= _StudentTeacher.GetAll(i => i.IsDeleted == false && i.TeacherId == id, "Student").ToList();
            foreach(var item in x)
            {
                if (item.Student != null)
                {
                    var f= _Family.FirstOrDefault(c => c.ID == item.Student.FamilyId && c.IsDeleted==false).Result;
                    if (!family.Contains(f) && f != null)
                    {
                        family.Add(f);

                    }
           
                }
            }
            return family;
        }
        public Family Family_Get(Guid Id)
        {
            return _Family.FirstOrDefault(c => c.ID == Id, "Student").Result;
        }
        public List<Family> FamilyOfSuperVisor_GetAll(string id)
        {

            List<Family> model = _Family.GetAll(c => c.IsDeleted == false && c.SupervisorId == id, "Supervisor").ToList();
            return model;
        }

        public List<Family> FamilyOfSuperVisor_GetAllDelete(string id)
        {

            List<Family> model = _Family.GetAll(c => c.IsDeleted == true && c.SupervisorId == id, "Supervisor").ToList();
            return model;
        }
        #endregion


        public async Task<Family> Family_Create(Family model,string UserId)
        {
            model.ID = Guid.NewGuid();
            model.UserCreate = UserId;
            await _Family.Add(model);
            return model;
        }

        public async Task<Family> Family_Update(Family model, string UserId)
        {
            var family = _Family.FirstOrDefault(c => c.ID == model.ID).Result;
            family.EditDate = DateTime.Now;
            family.UserEdit = UserId;
            family.FullName = model.FullName;
            family.Governorate = model.Governorate;
            family.PhoneNumber = model.PhoneNumber;
            family.state = model.state;
            family.SupervisorId = model.SupervisorId;
            family.Paypal = model.Paypal;
            family.IDNumber = model.IDNumber;
            await _Family.Update(family);
            return family;
        }

        public async Task<Family> Family_Delete(Guid id, string UserId)
        {
            var family = _Family.FirstOrDefault(c => c.ID == id).Result;
            family.DeleteDate = DateTime.Now;
            family.UserDelete = UserId;
            family.IsDeleted = true;


            await _Family.Update(family);
           // await DeleteStudent(id, UserId);
            return family;
        }

        public async Task<Family> Family_UnDelete(Guid id, string UserId)
        {
            var family = _Family.FirstOrDefault(c => c.ID == id).Result;
            family.DeleteDate = DateTime.Now;
            family.UserDelete = UserId;
            family.IsDeleted = false;


            await _Family.Update(family);
          //  await UnDeleteStudent(id, UserId);
            return family;
        }



        #endregion


        //#region Helper

        //    public async Task DeleteStudent(Guid FamilyId, string UserId)
        //    {
        //       Family fam =  Family_Get(FamilyId);
        //       List<Student> stus = _StudentManager.Studentlist_GetByFamily(FamilyId);
        //       foreach (Student student in stus)
        //       {
        //           await _StudentManager.Student_Delete(student.ID,UserId);
        //       }


        //    }

        //    public async Task UnDeleteStudent(Guid FamilyId, string UserId)
        //    {
        //        Family fam = Family_Get(FamilyId);
        //        List<Student> stus = _StudentManager.Studentlist_GetByFamily(FamilyId);
        //        foreach (Student student in stus)
        //        {
        //            await _StudentManager.Student_UnDelete(student.ID, UserId);
        //        }


        //    }
        //    #endregion
    }
}
