using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.StudentMarketerService.Model;
using StartQuran.Service.StudentTeacherService;
using StartQuran.Service.StudentTeacherService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.StudentMarketerService
{
    public class StudentMarketerManager
    {
        private readonly IRepository<StudentMarketer> _StudentMarketer;
        private readonly IRepository<Marketer> _Marketer;
        private readonly IRepository<Family> _Family;
        private readonly IRepository<Student> _Student;
        private readonly StudentTeacherManager _StudentTeacherManager;

        public StudentMarketerManager(StudentTeacherManager StudentTeacherManager,IRepository<Student> Student,IRepository<StudentMarketer> StudentMarketer, IRepository<Marketer> Marketer, IRepository<Family> Family)
        {
            _StudentMarketer = StudentMarketer;
            _Marketer = Marketer;
            _Family = Family;
            _Student = Student;
            _StudentTeacherManager = StudentTeacherManager;
        }

        #region StudentMarketer
        //---------StudentMarketer--------------
        #region Get
        public List<StudentMarketerVM> StudentMarketer_GetAll()
        {
            List<StudentMarketer> model = _StudentMarketer.GetAll(c => c.IsDeleted == false, "Student,Marketer").ToList();
            return ConvVM(model);
        }
       
      
        public List<Marketer> MarketerOfstudent_GetAll(Guid id)
        {
            var Marketers = new List<Marketer>();
            var SMarketer = _StudentMarketer.GetAll(c => c.IsDeleted == false && c.StudentId == id, "Student,Marketer").ToList();
            foreach (var item in SMarketer)
            {
                var model = _Marketer.FirstOrDefault(c => c.IsDeleted == false && c.Id == item.MarketerId).Result;
                Marketers.Add(model);
            }
            return Marketers;
        }


        public List<Student> StudentOfMarketer_GetAll(string id)
        {
            var Students = new List<Student>();
            var SMarketer = _StudentMarketer.GetAll(c => c.IsDeleted == false && c.MarketerId == id, "Student,Marketer").ToList();
            foreach (var item in SMarketer)
            {
                var model = item.Student;
                Students.Add(model);
            }
            return Students;
        }


        public StudentMarketerVM StudentMarketer_Get(Guid Id)
        {
            var model = _StudentMarketer.FirstOrDefault(c => c.ID == Id, "Student,Marketer").Result;
            return new StudentMarketerVM(model);
        }
        public StudentMarketer Student_Get(Guid Id)
        {
            return _StudentMarketer.FirstOrDefault(c => c.StudentId == Id).Result;
        }
        public StudentMarketer Marketer_Get(string Id)
        {
            return _StudentMarketer.FirstOrDefault(c => c.MarketerId == Id).Result;
        }



        public List<StudentMarketerVM> StudentMarketer_Supervisor_GetAll(string id)
        {
            var studentTeacher =_StudentTeacherManager.SuperVisor_StudentTeacher_GetAll(id);
            List<StudentTeacherRM> STN = new List<StudentTeacherRM>();
            foreach (var st in studentTeacher)
            {
                if (STN.Where(c => c.StudentId == st.StudentId).Count() == 0) 
                    STN.Add(st);


            }
            studentTeacher = STN;
            List<StudentMarketer> studentMar = new List<StudentMarketer>();
            foreach (var st in studentTeacher)
            {
                studentMar.AddRange(_StudentMarketer.GetAll(c => c.StudentId == st.StudentId && c.IsDeleted == false, "Student,Marketer"));
            }
            return ConvVM(studentMar);
        }

        #endregion


        public async Task<StudentMarketer> StudentMarketer_Create(StudentMarketerVM model, string UserId)
        {
            StudentMarketer modelCreate = new StudentMarketer();
            modelCreate.StudentId = model.StudentId;
            modelCreate.MarketerId = model.MarketerId;
            modelCreate.ID = Guid.NewGuid();
            modelCreate.UserCreate = UserId;
            try
            {
                await _StudentMarketer.Add(modelCreate);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
            }
            return modelCreate;
        }

        public async Task<StudentMarketer> StudentMarketer_Update(StudentMarketerVM model, string UserId)
        {
            var StudentMarketer = _StudentMarketer.FirstOrDefault(c => c.ID == model.ID).Result;
            StudentMarketer.EditDate = DateTime.Now;
            StudentMarketer.UserEdit = UserId;
            StudentMarketer.MarketerId = model.MarketerId;
            StudentMarketer.StudentId = model.StudentId;


            await _StudentMarketer.Update(StudentMarketer);
            return StudentMarketer;
        }

        public async Task<StudentMarketer> StudentMarketer_Delete(Guid id, string UserId)
        {
            var StudentMarketer = _StudentMarketer.FirstOrDefault(c => c.ID == id).Result;
            StudentMarketer.DeleteDate = DateTime.Now;
            StudentMarketer.UserDelete = UserId;
            StudentMarketer.IsDeleted = true;


            await _StudentMarketer.Remove(StudentMarketer);
            return StudentMarketer;
        }


        public async Task Predecessor_Delete(DateTime Date)
        {
            var Predecessor = _StudentMarketer.GetAll(c => c.CreateDate.Year == Date.Year && c.CreateDate.Month == Date.Month, "Student,Marketer").Distinct();
            if (Predecessor != null)
                await _StudentMarketer.RemoveList(Predecessor);

        }


        #endregion


        #region
        public List<StudentMarketerVM> ConvVM(List<StudentMarketer> model)
        {
            List<StudentMarketerVM> m = new List<StudentMarketerVM>();

            foreach (var st in model)
            {
                if (!st.IsDeleted)
                {
                    m.Add(new StudentMarketerVM
                    {
                        ID = st.ID,

                        StudentId = st.StudentId,

                        MarketerId = st.MarketerId,
                        Marketer = st.Marketer,
                        Student = st.Student,

                    });
                }
            }
            return m;
        }
        #endregion

    }
}
