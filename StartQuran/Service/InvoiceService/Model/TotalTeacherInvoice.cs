using System;
using System.Collections.Generic;

namespace StartQuran.Service.InvoiceService.Model
{
    public class TotalTeacherInvoice
    {
        public List<InvoiceTeacher> InvoiceTeacher { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        public double NumOfHour { get; set; } = 0;

        public int NumOfSection { get; set; } = 0;

        public double TotalPredecessor { get; set; } = 0;

        public double TotalMarketer { get; set; } = 0;
        public double TotalPayMent { get; set; } = 0;

        public double Total { get; set; } = 0;
    }
}
