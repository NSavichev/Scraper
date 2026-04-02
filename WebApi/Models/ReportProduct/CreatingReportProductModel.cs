using System;

namespace WebApi.Models.ReportProduct
{
    public class CreatingReportProductModel
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