using System;
using System.ComponentModel.DataAnnotations;
namespace StartQuran.Models.DataBase
{
    public class RegistrationFamily
    {
        [Key]
        public Guid ID { get; set; }
        public string FullName { get; set; }

        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string state { get; set; }
        public string Message { get; set; }

        public string WhatsApp { get; set; }

        public DateTime CreateDate { get; set; } = new DateTime();

        public bool Read { get; set; }
    }
}
