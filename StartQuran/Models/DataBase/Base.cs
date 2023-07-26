using StartQuran.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StartQuran.Models.Helper
{
    public class Base
    {
        [Key]
        public Guid ID { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string UserCreate { get; set; } 

        public DateTime EditDate { get; set; }
        public string UserEdit { get; set; }

        public DateTime DeleteDate { get; set; }
        public string UserDelete { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
