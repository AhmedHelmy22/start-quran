


using StartQuran.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.DataBase
{
    public class StudentMarketer : Base
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string MarketerId { get; set; }
        public virtual Marketer Marketer { get; set; }
    }
}
