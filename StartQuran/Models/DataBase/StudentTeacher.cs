using StartQuran.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.DataBase
{
    public class StudentTeacher:Base
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
