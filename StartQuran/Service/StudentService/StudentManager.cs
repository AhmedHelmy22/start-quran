using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.FamilyService;
using StartQuran.Service.StudentTeacherService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.StudentService
{
    public class StudentManager
    {

        private readonly IRepository<Student> _Student;
        private readonly IRepository<StudentTeacher> _StudentTeacher;
        private readonly FamilyManager _FamilyManager;
        public StudentManager(IRepository<Student> Student, FamilyManager FamilyManager, IRepository<StudentTeacher> StudentTeacher)
        {
            _Student = Student;
            _StudentTeacher = StudentTeacher;
            _FamilyManager = FamilyManager;

        }

        #region Student
        //---------Student--------------
        #region Get
        public List<Student> Student_GetAll(bool isdeleted=false)
        {
           if(isdeleted)
                return _Student.GetAll(null, "Family").ToList();
           else
                return _Student.GetAll(c => c.IsDeleted == false, "Family").ToList();
        }

        public Student Student_Get(Guid Id)
        {
            return _Student.FirstOrDefault(c => c.ID == Id).Result;
        }
        public Student Student_GetByFamily(Guid Id)
        {
            return _Student.FirstOrDefault(c => c.FamilyId == Id && c.IsDeleted==false).Result;
        }
        public List<Student> StudentGetByFamilyOfTeacher(Guid Id,string TeacherId)
        {
            List<Student> Student = new List<Student>();
            var Allstudent=  _Student.GetAll(c => c.FamilyId == Id && c.IsDeleted == false, "Family").ToList();
            foreach (var item in Allstudent)
            {
                var x = _StudentTeacher.FirstOrDefault(i => i.IsDeleted == false && i.StudentId==item.ID &&i.TeacherId==TeacherId, "Student").Result;

                if (x != null)
                {


                        Student.Add(item);

                    
                }

            }
            return Student;
           // return _Student.GetAll(c => c.FamilyId == Id && c.IsDeleted == false, "Family").ToList();

        }
        public List<Student> Studentlist_GetByFamily(Guid Id)
        {
            return _Student.GetAll(c => c.FamilyId == Id && c.IsDeleted == false, "Family").ToList();
        }
        public List<Student> StudentDeletelist_GetByFamily(Guid Id)
        {
            return _Student.GetAll(c => c.FamilyId == Id && c.IsDeleted == true, "Family").ToList();
        }
        public List<Student> StudentOfSupervisor_GetAll(string id)
        {
            var students = new List<Student>();
            var family = _FamilyManager.FamilyOfSuperVisor_GetAll(id);
            foreach (var item in family)
            {
              var elements=  _Student.GetAll(c => c.IsDeleted == false && c.FamilyId==item.ID, "Family").ToList();
                foreach (var x in elements)
                {
                    students.Add(x);
                }
            }
            _Student.GetAll(c => c.IsDeleted == false, "Family").ToList();

            return students;
        }

        #endregion


        public async Task<Student> Student_Create(Student model, string UserId)
        {
            model.ID = Guid.NewGuid();
            model.UserCreate = UserId;
            await _Student.Add(model);
            return model;
        }

        public async Task<Student> Student_Update(Student model, string UserId)
        {
            var Student = _Student.FirstOrDefault(c => c.ID == model.ID).Result;
            Student.EditDate = DateTime.Now;
            Student.UserEdit = UserId;
            Student.FullName = model.FullName;
            Student.Age = model.Age;
            Student.Paypal = model.Paypal;
            Student.FamilyId = model.FamilyId;
            Student.Gender = model.Gender;
            Student.PriceOfHour = model.PriceOfHour;
           // Student.JoiningDate = model.JoiningDate;

            await _Student.Update(Student);
            return Student;
        }

        public async Task<Student> Student_Delete(Guid id, string UserId)
        {
            var Student = _Student.FirstOrDefault(c => c.ID == id).Result;
            Student.DeleteDate = DateTime.Now;
            Student.UserDelete = UserId;
            Student.IsDeleted = true;


            await _Student.Update(Student);
            return Student;
        }

        public async Task<Student> Student_UnDelete(Guid id, string UserId)
        {
            var Student = _Student.FirstOrDefault(c => c.ID == id).Result;
            Student.DeleteDate = DateTime.Now;
            Student.UserDelete = UserId;
            Student.IsDeleted = false;


            await _Student.Update(Student);
            return Student;
        }
        #endregion
    }
}
