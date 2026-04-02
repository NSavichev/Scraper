using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts.ReportProduct
{
    public class ReportProductDto
    {

        public string IdProduct { get; set; }
        public string UrlProduct { get; set; }
        public int ViewAll { get; set; }
        public decimal AvgDay { get; set; }
        public decimal Price { get; set; }
        public DateTime ScrapDate { get; set; }
        public bool IsFakeScrap { get; set; }
        public int IdShop { get; set; }
        public bool Deleted { get; set; }
    }
}
