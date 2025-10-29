using BugStore.Data;
using BugStore.Interfaces.Handlers;
using BugStore.Models;
using BugStore.Requests.Orders;
using BugStore.Responses;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Handlers.Orders
{
    public class OrderHandler(AppDbContext context) : IOrderHandler
    {
        public async Task<Response<Order>> CreateOrderAsync(CreateOrderRequest request)
        {
            var order = new Order
            {
                CustomerId = request.CustomerId,
                CreatedAt = DateTime.UtcNow,
                Lines = request.Lines
            };
            try
            {
                await context.Orders.AddAsync(order);
                await context.SaveChangesAsync();

                return new Response<Order>(order);
            }

            catch (Exception e)
            {
                return new Response<Order>(null, message: "Ocorreu um erro ao exibir cadastrar pedido.");
            }
            
        }

        public async Task<Response<Order>> GetOrderByIdAsync(GetOrderByIdRequest request)
        {
            
            try
            {
                var order = await context.Orders.AsNoTracking().Include(x => x.Customer).Include(x => x.Lines).FirstOrDefaultAsync(x => x.Id == request.Id);

                return order is not null ? new Response<Order>(order) : new Response<Order>(null, message: "Nenhum pedido encontrado.");
            }

            catch (Exception e)
            {
                return new Response<Order>(null, message: "Ocorreu um erro ao exibir cadastrar pedido.");
            }
        }
    }
}
