using StartQuran.Models.DataBase;
using StartQuran.Service.MarketerService.Model;
using System;
using System.Collections.Generic;

namespace StartQuran.Service.InvoiceService.Model
{
    public class InvoiceMarketer
    {
        public MarketerRM Marketer { get; set; }
        public List<InvoiceStudent> InvoiceStudent { get; set; } = new List<InvoiceStudent>();  

        public DateTime date { get; set; } = DateTime.Now;

        public double Cash { get; set; } = 0;

        public double Salary { get; set; } = 0;
        public double totalCash { get; set; } = 0;
    }
}
