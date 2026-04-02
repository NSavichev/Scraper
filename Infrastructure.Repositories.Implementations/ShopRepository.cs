using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Services.Repositories.Abstractions;
using Domain.EF;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Services.Contracts.Shop;

namespace Infrastructure.Repositories.Implementations
{
    /// <summary>
    /// Репозиторий работы с магазинами.
    /// </summary>
    public class ShopRepository: Repository<Shop, int>, IShopRepository
    {
        public ShopRepository(DatabaseContext context): base(context)
        {
        }

        /// <summary>
        /// Получить сущность по ID.
        /// </summary>
        /// <param name="id"> Id сущности. </param>
        /// <param name="cancellationToken"></param>
        /// <returns> магазин. </returns>
        public override async Task<Shop> GetAsync(int id, CancellationToken cancellationToken)
        {
            var query = Context.Set<Shop>().AsQueryable();
            return await query.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Shop>> GetShopsInfosAsync(string fieldsToSelect)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список магазинов. </returns>
        public async Task<List<Shop>> GetPagedAsync(int page, int pageSize)
        {
            var query = GetAll().Where(l => !l.Deleted == true);
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

        }

        //public async Task<List<ShopInfo>> GetCourseInfosAsync(string fieldsToSelect)
        //{
        //    var listOfFieldsToSelect = fieldsToSelect.Split(",");
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.AppendJoin(",", listOfFieldsToSelect.Select(s => $"\"{s}\""));
        //    PropertyInfo[] properties = typeof(CourseInfo).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (var property in properties)
        //    {
        //        if(!listOfFieldsToSelect.Contains(property.Name))
        //        {
        //            stringBuilder.Append($", NULL as \"{property.Name}\"");
        //        }
        //    }
        //    var courseInfos = await Context.Database.SqlQueryRaw<CourseInfo>($"select {stringBuilder.ToString()} from \"Courses\"").ToListAsync();
            
        //    return courseInfos;
        //}
    }
}
