using StartQuran.Models.Enums;
using StartQuran.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.DataBase
{
    public class Family:Base
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string SupervisorId { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public string state { get; set; }
        public string Governorate { get; set; }
        public string IDNumber { get; set; }
        public string Paypal { get; set; }
        public virtual ICollection<Student> Student { get; set; }



    }
}
