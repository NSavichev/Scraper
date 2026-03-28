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
    private DatabaseContext _context;

    public IShopRepository ShopRepository => _shopRepository;
    public IProductRepository ProductRepository => _productRepository;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
        _productRepository = new ProductRepository(context);
        _shopRepository = new ShopRepository(context);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}