using System.Threading.Tasks;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// UOW.
    /// </summary>
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

        IShopRepository ShopRepository { get; }

        IReportProductRepository ReportProductRepository { get; }

        Task SaveChangesAsync();
    }
}
