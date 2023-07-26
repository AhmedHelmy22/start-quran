using System;
using System.Collections.Generic;

namespace StartQuran.Service.InvoiceService.Model
{
    public class TotalFamilyInvoice
    {
        public List<InvoiceFamily> InvoiceFamily { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        public double NumOfHour { get; set; } = 0;

        public int NumOfSection { get; set; } = 0;
        public double TotalPayMent { get; set; } = 0;
    }
}
