using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StartQuran.Areas.Identity.Data;

namespace StartQuran.Models.DataBase
{
    public class Marketer : ApplicationUser
    {
       
        public double Salary { get; set; }

        public int Ratio { get; set; }
    }
}
