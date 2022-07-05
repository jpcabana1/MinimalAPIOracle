using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Models;
using System.Xml.Linq;

namespace MinimalAPIOracle.Services
{
    public class ProductDetailsService
    {
        private readonly ModelContext _context;

        public ProductDetailsService(ModelContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDetailsDAO> getProductDetails(long customerId)
        { 
            return from customer in _context.Customers
                   join orders in _context.Orders
                      on customer.CustomerId equals orders.CustomerId 
                   join ordersItems in _context.OrderItems
                      on orders.OrderId equals ordersItems.OrderId
                   join products in _context.Products
                      on ordersItems.ProductId equals products.ProductId
                   where customer.CustomerId == customerId
                   orderby ordersItems.Quantity
                   select new ProductDetailsDAO
                   {
                       CustomerId = customer.CustomerId,
                       OrderId = orders.OrderId,
                       Status = orders.Status,
                       UnitPrice = ordersItems.UnitPrice,
                       Quantity = ordersItems.Quantity,
                       Description = products.Description
                   };
        }
    }
}
