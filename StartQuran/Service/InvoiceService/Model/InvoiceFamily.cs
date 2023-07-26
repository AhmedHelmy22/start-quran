using StartQuran.Models.DataBase;
using System;
using System.Collections.Generic;

namespace StartQuran.Service.InvoiceService.Model
{
    public class InvoiceFamily
    {
        public Family Family { get; set; }

        public double PricePerHour { get; set; }
        public List<Section> Sections { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        public double NumOfHour { get; set; } = 0;

        public int NumOfSection { get; set; } = 0;

        public double Cach { get; set; } = 0;

        public double Tax { get; set; } = 0;
        public double TotalTax { get; set; } = 0;
        public double TotalPayMent { get; set; } = 0;

        public string Message { get; set; }
        public string MessageEN { get; set; }

    }
}
