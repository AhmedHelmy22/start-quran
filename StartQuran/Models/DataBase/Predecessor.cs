using StartQuran.Models.Helper;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StartQuran.Models.DataBase
{
    public class Predecessor : Base
    {
        [Required]
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public double Cash { get; set; }
        public string Note { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
