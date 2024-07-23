using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Domain.Entities;


namespace TesodevBackendC.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<List<OrderDetail>> GetOrderListByCustomerIdAsync(Guid customerId);
        Task<bool> ChangeOrderStatusToFalseAsync(Guid orderId, string status);
        Task<bool> ChangeOrderStatusToTrueAsync(Guid orderId, string status);
    }
}
