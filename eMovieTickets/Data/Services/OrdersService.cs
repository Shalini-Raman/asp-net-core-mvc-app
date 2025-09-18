using eMovieTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMovieTickets.Data.Services
{
    public class OrdersService : IOrdersService
    {

        public readonly AppDBContext _context;

        public OrdersService(AppDBContext context)
        {
            _context = context;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var OI = new orderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                await _context.OrderItem.AddAsync(OI);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string UserId)
        {
            var orders = _context.Order
                .Include(n => n.orderItems)
                .ThenInclude(n => n.Movie)
                .Where(n => n.UserId == UserId)
                .ToListAsync();

            return await orders;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders =await _context.Order
                 .Include(n => n.orderItems)
                 .ThenInclude(n => n.Movie)
                 .ToListAsync();
            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }
    }
}
