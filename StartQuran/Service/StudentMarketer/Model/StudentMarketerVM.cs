
using StartQuran.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.StudentMarketerService.Model
{
    public class StudentMarketerVM
    {
        public Guid ID { get; set; }
        public Guid StudentId { get; set; }
        public string MarketerId { get; set; }
        public Guid FamilyId { get; set; }
        public Student Student { get; set; }
        public Marketer Marketer { get; set; }

        public StudentMarketerVM() { }

        public StudentMarketerVM(StudentMarketer model)
        {
            this.ID = model.ID;

            this.StudentId = model.StudentId;

            this.MarketerId = model.MarketerId;
            this.Marketer = model.Marketer;
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

