using StartQuran.Areas.Identity.Data;
using StartQuran.Models.DataBase;
using StartQuran.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Service.SupervisorService.Model
{
    public class SupervisorRM
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public string phone { get; set; }

        public string Governorate { get; set; }

        public string password { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        //public string ModeratorId { get; set; }
        //public virtual Supervisor Moderator { get; set; }

        public SupervisorRM() { }

        public SupervisorRM(ApplicationUser user)
        {
            this.Id = user.Id;

            this.FullName = user.FullName;

            this.phone = user.PhoneNumber;

            this.Governorate = user.Governorate;
            this.Gender = user.Gender;
            this.Age = user.Age;
            //this.ModeratorId = user.ModeratorId;
            //this.Moderator = user.Moderator;


        }




        

    }
}
