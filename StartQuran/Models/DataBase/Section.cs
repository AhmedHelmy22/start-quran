using StartQuran.Models.Enums;
using StartQuran.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.DataBase
{
    public class Section :Base
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int NumberOfHours { get; set; }
        public string Comment { get; set; }
        public string Note { get; set; }
        public Evaluation Evaluation { get; set; }
        public DateTime SectionDate { get; set; } = DateTime.Now;
    }
}
