using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.StudentTeacherService.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.StudentTeacherService
{
    public class StudentTeacherManager
    {
        private readonly IRepository<StudentTeacher> _StudentTeacher;
        private readonly IRepository<Teacher> _Teacher;
        private readonly IRepository<Family> _Family;
       

        public StudentTeacherManager(IRepository<StudentTeacher> StudentTeacher, IRepository<Teacher> Teacher,IRepository<Family> Family)
        {
            

            _StudentTeacher = StudentTeacher;
            _Teacher = Teacher;
            _Family = Family;
        }

        #region StudentTeacher
        //---------StudentTeacher--------------
        #region Get
        public List<StudentTeacherRM> StudentTeacher_GetAll()
        {
           
            List<StudentTeacher> model= _StudentTeacher.GetAll(c => c.IsDeleted == false && c.Teacher.IsDeleted==false && c.Student.IsDeleted == false, "Student,Teacher").ToList();
            return ConvRM(model);
        }
        public List<Teacher> TeacherOfSuperVisor_GetAll(string id)
        {

            List<Teacher> model = _Teacher.GetAll(c => c.IsDeleted == false && c.SupervisorId==id, "Supervisor").ToList();
            return model;
        }
        public List<StudentTeacherRM> SuperVisor_StudentTeacher_GetAll(string id)
        {

            List<StudentTeacher> model = _StudentTeacher.GetAll(c => c.IsDeleted == false && c.Teacher.SupervisorId == id, "Student,Teacher").ToList();
            return ConvRM(model);
        }
        public List<Teacher> TeacherOfstudent_GetAll(Guid id)
        {
            var Teachers = new List<Teacher>();
            var Steacher = _StudentTeacher.GetAll(c => c.IsDeleted == false && c.StudentId==id, "Student,Teacher").ToList();
            foreach (var item in Steacher)
            {
                var model = _Teacher.FirstOrDefault(c => c.IsDeleted == false && c.Id == item.TeacherId).Result;
                Teachers.Add(model);
            }
            return Teachers;
        }
        //public List<Teacher> TeacherOfstudentSupervisor_GetAll(Guid id,string supervisorid)
        //{
        //    var Teachers = new List<Teacher>();
        //    var Steacher = _StudentTeacher.GetAll(c => c.IsDeleted == false && c.StudentId == id, "Student,Teacher").ToList();
        //    var T = TeacherOfSuperVisor_GetAll(supervisorid);
        //    foreach (var item in Steacher)
        //    {
        //        var model = _Teacher.FirstOrDefault(c => c.IsDeleted == false && c.Id == item.TeacherId).Result;
        //        if (T.Contains(model))
        //        {
        //            Teachers.Add(model);
        //        }
        //    }
        //    return Teachers;
        //}
        public List<StudentTeacherRM> StudentTeacherofsupervisor_GetAll(string id)
        {
            var studentTeacher = new List<StudentTeacher>();
            var teacher = TeacherOfSuperVisor_GetAll(id);
            foreach(var item in teacher)
            {
                var model = _StudentTeacher.FirstOrDefault(c => c.IsDeleted == false && c.TeacherId==item.Id, "Student,Teacher").Result;
                studentTeacher.Add(model);
            }
            return ConvRM(studentTeacher);
        }
        //public List<Family> FamilyOfSuperVisor_GetAll(string id)
        //{

        //    List<Family> model = _Family.GetAll(c => c.IsDeleted == false && c.SupervisorId == id, "Supervisor").ToList();
        //    return model;
        //}
        //public List<Student> Student_GetAll()
        //{
        //   var All= _Student.Get(c => c.IsDeleted == false).ToList();
        //    List<Student> Students = new List<Student>();
        //    foreach (var item in All)
        //    {
        //        if (_StudentTeacher.FirstOrDefault(c => c.StudentId == item.ID).Result == null)
        //        {
        //            Students.Add(item);
        //        }
        //    }
        //    return Students;

        //}
        //public List<Student> Student_GetAllUpdate(Guid id)
        //{
        //    var All = _Student.Get(c => c.IsDeleted == false).ToList();
        //    List<Student> Students = new List<Student>();
        //    foreach (var item in All)
        //    {
        //        if (item.ID != id)
        //        {
        //            if (_StudentTeacher.FirstOrDefault(c => c.StudentId == item.ID).Result == null)
        //            {
        //                Students.Add(item);
        //            }
        //        }
        //        else
        //        {
        //            Students.Add(item);

        //        }
        //    }
        //    return Students;

        //}
        public StudentTeacherRM StudentTeacher_Get(Guid Id)
        {
            var model= _StudentTeacher.FirstOrDefault(c => c.ID == Id, "Student,Teacher").Result;
            return new StudentTeacherRM(model);
        }
        public StudentTeacher Student_Get(Guid Id)
        {
            return _StudentTeacher.FirstOrDefault(c => c.StudentId == Id).Result;
        }
        public StudentTeacher teacher_Get(string Id)
        {
            return _StudentTeacher.FirstOrDefault(c => c.TeacherId == Id).Result;
        }
        #endregion


        public async Task<StudentTeacher> StudentTeacher_Create(StudentTeacherRM model, string UserId)
        {
            StudentTeacher modelCreate = new StudentTeacher();
            modelCreate.StudentId = model.StudentId;
            modelCreate.TeacherId = model.TeacherId;
            modelCreate.ID = Guid.NewGuid();
            modelCreate.UserCreate = UserId;
            try
            {
                await _StudentTeacher.Add(modelCreate);
            }
            catch(Exception ex)
            {
               var x = ex.Message;
            }
            return modelCreate;
        }

        public async Task<StudentTeacher> StudentTeacher_Update(StudentTeacherRM model, string UserId)
        {
            var StudentTeacher = _StudentTeacher.FirstOrDefault(c => c.ID == model.ID).Result;
            StudentTeacher.EditDate = DateTime.Now;
            StudentTeacher.UserEdit = UserId;
            StudentTeacher.TeacherId = model.TeacherId;
            StudentTeacher.StudentId = model.StudentId;


          await _StudentTeacher.Update(StudentTeacher);
            return StudentTeacher;
        }

        public async Task<StudentTeacher> StudentTeacher_Delete(Guid id, string UserId)
        {
            var StudentTeacher = _StudentTeacher.FirstOrDefault(c => c.ID == id).Result;
            StudentTeacher.DeleteDate = DateTime.Now;
            StudentTeacher.UserDelete = UserId;
            StudentTeacher.IsDeleted = true;


            await _StudentTeacher.Remove(StudentTeacher);
            return StudentTeacher;
        }
        #endregion
        #region
        public List<StudentTeacherRM> ConvRM(List<StudentTeacher> model)
        {
            List<StudentTeacherRM> m = new List<StudentTeacherRM>();

            foreach (var st in model)
            {
                if (!st.IsDeleted)
                {
                    m.Add(new StudentTeacherRM
                    {
                        ID = st.ID,

                        StudentId = st.StudentId,

                        TeacherId = st.TeacherId,
                        Teacher = st.Teacher,
                        Student = st.Student,
                
                    });
                }
            }
            return m;
        }
        #endregion

    }
}
