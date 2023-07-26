using Microsoft.AspNetCore.Identity;
using StartQuran.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public int Age { get; set; } = 40;
        public Gender Gender { get; set; } = Gender.ذكر;
        public string Status { get; set; }
        public string Governorate { get; set; }

        public UserType usertype { get; set; }
        public bool IsDeleted { get; set; } = false;

    }

}
