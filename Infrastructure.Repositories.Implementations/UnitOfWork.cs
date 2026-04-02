using System.Threading.Tasks;
using Infrastructure.EF;
using Services.Repositories.Abstractions;

namespace Infrastructure.Repositories.Implementations;

/// <summary>
/// UOW.
/// </summary>
public class UnitOfWork: IUnitOfWork
{
    private IShopRepository _shopRepository;
    private IProductRepository _productRepository;
    private IReportProductRepository _reportProductRepository;
    private DatabaseContext _context;

    public IShopRepository ShopRepository => _shopRepository;
    public IProductRepository ProductRepository => _productRepository;
    public IReportProductRepository ReportProductRepository => _reportProductRepository;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        _productRepository = new ProductRepository(context);
        _shopRepository = new ShopRepository(context);
        _reportProductRepository = new ReportProductRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}