using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial
{
    public class OrdersController
    {
        private readonly SalesDbContext _context;
        public OrdersController() 
        {
            _context = new SalesDbContext();
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await _context.Orders
                                    .Include(x => x.OrderLines)
                                    .Include(x => x.Customer)// add this statement to gather all the customers while referencing the ORDER table
                                    .ToListAsync();
        }
        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.Include(x => x.OrderLines)
                                    .Include(x => x.Customer)// add this to include more information that is not included on the table i.e Customers when referencing the ORDER table
                                    .SingleOrDefaultAsync(x => x.Id == id);

        }
        public async Task<bool> InsertAsync(Order order)
        {
            _context.Orders.Add(order);
            return await SaveDb();
        }
        public async Task<bool> UpdateAsync(Order order)
        {
            var ord = await GetByIdAsync(order.Id);
            if (ord is null)
            {
                return false;
            }
            _context.Orders.Entry(order).State = EntityState.Modified;
            return await SaveDb();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var ord = await GetByIdAsync(id);
            if(ord is null)
            {
                return false;
            }
            _context.Orders.Remove(ord);
            return await SaveDb();

        }
        private async Task<bool> SaveDb()
        {
            var changes = await _context.SaveChangesAsync();
            return (changes == 1) ? true : false;
        }
         

    }
}
