using StartQuran.Models.DataBase;
using StartQuran.Models.Repository;
using StartQuran.Service.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.SectionService
{
    public class SectionManager
    {
        private readonly IRepository<Section> _Section;
        private readonly TeacherManager _TeacherManager;

        public SectionManager(IRepository<Section> Section, TeacherManager TeacherManager)
        {
            _Section = Section;
            _TeacherManager = TeacherManager;

        }

        #region Section
        //---------Section--------------
        #region Get
        public List<Section> Section_GetAll()
        {
            return _Section.GetAll(c => c.IsDeleted == false&&c.SectionDate.Year==DateTime.Now.Year&& c.SectionDate.Month == DateTime.Now.Month, "Student.Family,Teacher").OrderByDescending(c=>c.SectionDate).ToList();
        }
        public List<Section> SectionTeacher_GetAll(string id)
        {
            return _Section.GetAll(c => c.IsDeleted == false && c.TeacherId==id && c.SectionDate.Year == DateTime.Now.Year && c.SectionDate.Month == DateTime.Now.Month, "Student.Family,Teacher").OrderByDescending(c => c.SectionDate).ToList();
        }
        public List<Section> SectionSupervisor_GetAll(string id)
        {
            List<Section> list = new List<Section>();
            var teacher = _TeacherManager.TeacherOfSuperVisor_GetAll(id);
            foreach(var item in teacher)
            {
                var s= _Section.GetAll(c => c.IsDeleted == false && c.TeacherId == item.Id && c.SectionDate.Year == DateTime.Now.Year && c.SectionDate.Month == DateTime.Now.Month, "Student.Family,Teacher").OrderByDescending(c => c.SectionDate).ToList();
                list.AddRange(s);
            }
            return list;
        }


        public List<Section> Section_GetAll(DateTime Date)
        {
            return _Section.GetAll(c => c.IsDeleted == false && c.SectionDate.Year == Date.Year && c.SectionDate.Month == Date.Month, "Student.Family,Teacher").OrderByDescending(c => c.SectionDate).ToList();
        }
        public List<Section> SectionTeacher_GetAll(string id, DateTime Date)
        {
            return _Section.GetAll(c => c.IsDeleted == false && c.TeacherId == id && c.SectionDate.Year == Date.Year && c.SectionDate.Month == Date.Month, "Student.Family,Teacher").OrderByDescending(c => c.SectionDate).ToList();
        }
        public List<Section> SectionSupervisor_GetAll(string id, DateTime Date)
        {
            List<Section> list = new List<Section>();
            var teacher = _TeacherManager.TeacherOfSuperVisor_GetAll(id);
            foreach (var item in teacher)
            {
                var s = _Section.GetAll(c => c.IsDeleted == false && c.TeacherId == item.Id && c.SectionDate.Year == Date.Year && c.SectionDate.Month == Date.Month, "Student.Family,Teacher").OrderByDescending(c => c.SectionDate).ToList();
                list.AddRange(s);
            }
            return list;
        }
        public Section Section_Get(Guid Id)
        {
            return _Section.FirstOrDefault(c => c.ID == Id, "Student.Family,Teacher").Result;
        }
 
        #endregion


        public async Task<Section> Section_Create(Section model, string UserId)
        {
            model.ID = Guid.NewGuid();
            model.UserCreate = UserId;
            await _Section.Add(model);
            return model;
        }

        public async Task<Section> Section_Update(Section model, string UserId)
        {
            var Section = _Section.FirstOrDefault(c => c.ID == model.ID).Result;
            Section.EditDate = DateTime.Now;
            Section.UserEdit = UserId;
            Section.Comment = model.Comment;
            Section.Note = model.Note;
            Section.NumberOfHours = model.NumberOfHours;
            Section.TeacherId = model.TeacherId;
            Section.SectionDate = model.SectionDate;
            Section.StudentId = model.StudentId;
            Section.Evaluation = model.Evaluation;


            await _Section.Update(Section);
            return Section;
        }

        public async Task<Section> Section_Delete(Guid id, string UserId)
        {
            var Section = _Section.FirstOrDefault(c => c.ID == id).Result;
            Section.DeleteDate = DateTime.Now;
            Section.UserDelete = UserId;
            Section.IsDeleted = true;


            await _Section.Remove(Section);
            return Section;
        }
        #endregion
    }
}
