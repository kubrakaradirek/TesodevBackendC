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
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OrderDbContext _context;
        public Repository(OrderDbContext context)
        {
                _context = context;
        }

        public async Task<bool> ChangeOrderStatusToFalseAsync(Guid orderId, string status)
        {
            var order=await _context.Set<OrderDetail>().FindAsync(orderId);
            if (order == null)
            {
                return false;
            }
            order.Status = status;
            _context.Set<OrderDetail>().Update(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeOrderStatusToTrueAsync(Guid orderId, string status)
        {
            var order = await _context.OrderDetails.FindAsync(orderId);

            if (order == null)
            {
                return false;
            }
            if(order.Status!= "Sipariş İptal")
            {
                return false;
            }

            order.Status = "Sipariş aktif";
            _context.Set<OrderDetail>().Update(order);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);  
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
           _context?.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<string>> GetProductListByOrderDetailIdAsync(Guid orderId)
        {
            var products = await _context.ProductOrderDetails.Where(x => x.OrderDetailId == orderId).Join(_context.Products, x => x.ProductId, y => y.Id, (x, y) => y.Name).ToListAsync();
            return  products;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
