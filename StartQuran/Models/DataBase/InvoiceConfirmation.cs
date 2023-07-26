using StartQuran.Models.Helper;
using System;

namespace StartQuran.Models.DataBase
{
    public class InvoiceConfirmation:Base
    {
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
    }
}
