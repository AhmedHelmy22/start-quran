using StartQuran.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.StudentTeacherService.Model
{
    public class StudentTeacherRM
    {
        public Guid ID { get; set; }
        public Guid StudentId { get; set; }
        public string TeacherId { get; set; }
        public Guid FamilyId { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public StudentTeacherRM() { }

        public StudentTeacherRM(StudentTeacher model)
        {
            this.ID = model.ID;

            this.StudentId = model.StudentId;

            this.TeacherId = model.TeacherId;
            this.Teacher = model.Teacher;
            this.Student = model.Student;


        }
    }

    public class StudentSelectVM
    {
        public Guid ID { get; set; }
       
        public string FullName { get; set; }

        public StudentSelectVM() { }

        public StudentSelectVM(Student model)
        {
            this.ID = model.ID;
            this.FullName = model.FullName;
        }
    }
}
