using System;
using System.Collections.Generic;

namespace StartQuran.Service.InvoiceService.Model
{
    public class TotalStudentInvoice
    {

        public List<InvoiceStudent> InvoiceStudent { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        public double NumOfHour { get; set; } = 0;

        public int NumOfSection { get; set; } = 0;
        public double TotalPayMent { get; set; } = 0;

    }
}
