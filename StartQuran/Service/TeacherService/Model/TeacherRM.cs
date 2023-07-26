using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.TeacherService.Model
{
    public class TeacherRM
    {
        public string Id { get; set; }

        public string SupervisorId { get; set; }
        public virtual Supervisor Supervisor { get; set; }

        public string fullName { get; set; }

        public string phone { get; set; }

        public string Governorate { get; set; }

        public string password { get; set; }

        public string ZoomLink { get; set; }

        public string EducationalQualification { get; set; }

        public float SallaryBerHour { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string IDNumber { get; set; }
        public TeacherRM() { }

        public TeacherRM(Teacher user)
        {
            this.Id = user.Id;

            SupervisorId = user.SupervisorId;

            this.fullName = user.FullName;

            this.phone = user.PhoneNumber;

            this.Governorate = user.Governorate;


            this.ZoomLink = user.ZoomLink;

            this.EducationalQualification = user.EducationalQualification;

            this.SallaryBerHour = user.SallaryBerHour;
            this.Gender = user.Gender;
            this.Age = user.Age;
            this.Supervisor = user.Supervisor;
            this.IDNumber = user.IDNumber;
        }






    }
}
