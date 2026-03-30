using Services.Contracts.Product;
using System.Collections.Generic;

namespace WebApi.Models.Shop;

public class ShopFilterModel
{
    public string Name { get; set; }
    
    public decimal? Price { get; set; }
    
    public int ItemsPerPage { get; set; }
    public List<ProductDto> Products { get; set; }
    public int Page { get; set; }
}