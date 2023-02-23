using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ef_dbfirst_tutorial
{
    public class OrderLinesController
    {
        private readonly SalesDbContext _context;

        public OrderLinesController()
        {
            _context = new SalesDbContext();
        }
        public async Task<List<OrderLine>> GetAllAsync()
        {
            return await _context.OrderLines.ToListAsync();
        }
        public async Task<OrderLine?> GetByIdAsync(int id)
        {
            return await _context.OrderLines.FindAsync(id);
        }
        public async Task<bool> InsertAsync(OrderLine orderline)
        {
            _context.OrderLines.Add(orderline);
            return await SaveDbAsync();
        }
        public async Task<bool> UpdateAsync(OrderLine orderline)
        {
            var ordLine = await GetByIdAsync(orderline.Id);
            if (ordLine is null)
            {
                return false;
            }
            _context.Entry(orderline).State = EntityState.Modified;
            return await SaveDbAsync();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var ordline = await GetByIdAsync(id);
            if (ordline is null)
            {
                return false; 
            }
            _context.OrderLines.Remove(ordline);
            return await SaveDbAsync();
        }
        public async Task<bool> SaveDbAsync()
        {
            var changes = await _context.SaveChangesAsync();
            return(changes == 1) ? true : false;
        }
    }
}
