using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesodevBackendC.Order.Application.Interfaces;
using TesodevBackendC.Order.Domain.Entities;
using TesodevBackendC.Order.Persistence.Context;

namespace TesodevBackendC.Order.Persistence.Repositories
{
    public class OrderLogRepository : IRepository<OrderLog>
    {
        private readonly OrderDbContext _context;

        public OrderLogRepository(OrderDbContext context)
        {
            _context = context;
        }

        public Task<bool> ChangeOrderStatusToFalseAsync(Guid orderId, string status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeOrderStatusToTrueAsync(Guid orderId, string status)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(OrderLog entity)
        {
            _context.OrderLogs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderLog entity)
        {
            _context.OrderLogs.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OrderLog>> GetAllAsync()
        {
            return await _context.OrderLogs.ToListAsync();
        }

        public async Task<OrderLog> GetByIdAsync(Guid id)
        {
            return await _context.OrderLogs.FindAsync(id);
        }

        public Task<List<string>> GetProductListByOrderDetailIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(OrderLog entity)
        {
            _context.OrderLogs.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
