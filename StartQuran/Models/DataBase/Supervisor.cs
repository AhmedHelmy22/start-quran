using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StartQuran.Areas.Identity.Data;

namespace StartQuran.Models.DataBase
{
    public class Supervisor: ApplicationUser
    {
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
