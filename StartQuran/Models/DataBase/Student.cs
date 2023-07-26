using StartQuran.Models.Enums;
using StartQuran.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.DataBase
{
    public class Student :Base
    {
        [Required]
        [ForeignKey("Family")]
        public Guid FamilyId { get; set; }
        public Family Family { get; set; }
        public string FullName { get; set; }

        public DateTime JoiningDate { get; set; } = DateTime.Now;
        public string Paypal { get; set; } 
        public float PriceOfHour { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; } = Gender.ذكر;

    }
}
