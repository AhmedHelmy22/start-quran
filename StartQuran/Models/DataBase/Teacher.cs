using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StartQuran.Areas.Identity.Data;

namespace StartQuran.Models.DataBase
{
    public class Teacher : ApplicationUser
    {
        public string SupervisorId { get; set; }
        public virtual Supervisor Supervisor { get; set; }
        public string ZoomLink { get; set; }
        public string EducationalQualification { get; set; }
        public float SallaryBerHour { get; set; }

        public string IDNumber { get; set; }
    }
}
