using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLogic
{
    public class DL : IDL
    {
        private readonly DBContext _context;
        public DL(DBContext p_context)
        { 
            _context = p_context;
        }

        /// First make the method into an async method using the keyword
        /// Next make the return type of the method into a task
        /// You have to import the namespace System.Threading.Task
        /// Next use the await keyword so it knows what it needs to do in parallel in that method
        /// Finally use System.Linq already made Async methods version of what you used

        public async Task<LineItem> AddALineItem(LineItem p_lineItem)
        {
            await _context.LineItems.AddAsync(p_lineItem);
            _context.SaveChanges();
            return _context.LineItems.FirstOrDefault(li => li.OrderId == p_lineItem.OrderId
                                                                        && li.ProductId == p_lineItem.ProductId
                                                                        && li.Quantity == p_lineItem.Quantity);

        }

        public async Task<Order> AddAnOrder(Order p_order)
        {
            await _context.Orders.AddAsync(p_order);
            _context.SaveChanges();
            return _context.Orders.FirstOrDefault(order => order.CustomerId == p_order.CustomerId
                                                                        && order.StoreFrontId == p_order.StoreFrontId
                                                                        && order.TotalPrice == p_order.TotalPrice);
        }

        public async Task<Customer> AddCustomer(Customer p_customer)
        {
            await _context.Customers.AddAsync(p_customer);
            _context.SaveChanges();
            return _context.Customers.FirstOrDefault(cust => cust.Fname == p_customer.Fname
                                                                            && cust.Lname == p_customer.Lname
                                                                            && cust.Phone == p_customer.Phone
                                                                            && cust.Email == p_customer.Email);
        }

        public async Task<Inventory> AddNewProductInventory(Inventory p_invt)
        {
            await _context.Inventories.AddAsync(p_invt);
            _context.SaveChanges();
            return _context.Inventories.FirstOrDefault(invt => invt.ProductId == p_invt.ProductId
                                                                                && invt.StoreFrontId == p_invt.StoreFrontId
                                                                                && invt.Quantity == p_invt.Quantity);
        }

        public async Task<Customer> GetACustomer(int p_customerId)
        {
            //return await _context.Customers.FirstOrDefaultAsync(cust => cust.Id == p_customerId);
            //return await _context.Customers.FindAsync(p_customerId);

            Customer c = await _context.Customers.FindAsync(p_customerId);
            List<Order> orders = await _context.Orders.Where(o => o.CustomerId == p_customerId).ToListAsync();
            c.Orders = orders;
            for(int i = 0; i < c.Orders.Count; i++)
            {
                List<LineItem> li = await _context.LineItems.Where(l => l.OrderId == c.Orders[i].Id).ToListAsync();
                c.Orders[i].LineItems = li;
            }
            return c;
        }

        public async Task<List<Order>> GetACustomerOrders(int p_customerId)
        {
            //return await _context.Orders.Where(order => order.CustomerId == p_customerId).Select(order => order).ToListAsync();
            return await _context.Orders.Where(order => order.CustomerId == p_customerId).ToListAsync();
        }


        

        public async Task<List<Customer>> GetAllCustomers()
        {
            //return await _context.Customers.Select(cust => cust).ToListAsync();
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Inventory>> GetAllInventories()
        {
            //return await _context.Inventories.Select(inv => inv).ToListAsync();
            return await _context.Inventories.ToListAsync();
        }

        public async Task<List<LineItem>> GetAllLineItems()
        {
            //return await _context.LineItems.Select(li => li).ToListAsync();
            return await _context.LineItems.ToListAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            //return await _context.Orders.Select(order => order).ToListAsync();
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            //return await _context.Products.Select(prod => prod).ToListAsync();
            return await _context.Products.ToListAsync();
        }

        public async Task<List<StoreFront>> GetAllStoreFronts()
        {
            //return await _context.StoreFronts.Select(sf => sf).ToListAsync();
            return await _context.StoreFronts.ToListAsync();
        }

        public async Task<List<Order>> GetAStoreFrontOrders(int p_storeFrontId)
        {
            //return await _context.Orders.Where(order => order.StoreFrontId == p_storeFrontId).Select(order => order).ToListAsync();
            return await _context.Orders.Where(order => order.StoreFrontId == p_storeFrontId).ToListAsync();
        }

        public async Task<List<Inventory>> GetAStoreInventory(StoreFront p_storeFront)
        {
            //return await _context.Inventories.Where(inv => inv.StoreFrontId == p_storeFront.Id).Select(inv => inv).ToListAsync();
            return await _context.Inventories.Where(inv => inv.StoreFrontId == p_storeFront.Id).ToListAsync();
        }

        public async Task<List<Inventory>> GetAStoreInventory(int p_storeFrontId)
        {
            //return await _context.Inventories.Where(inv => inv.StoreFrontId == p_storeFrontId).Select(inv => inv).ToListAsync();
            return await _context.Inventories.Where(inv => inv.StoreFrontId == p_storeFrontId).ToListAsync();
        }

        public async Task<Inventory> ReplenishInventory(int p_invId, int p_replenishedQuantity)
        {
            Inventory theInventory = await _context.Inventories.FirstOrDefaultAsync(inv => inv.Id == p_invId);
            theInventory.Quantity += p_replenishedQuantity;
            _context.SaveChanges();
            return _context.Inventories.FirstOrDefault(inv => inv.Id == p_invId);
        }

        public async Task<Inventory> UpdateInventoryQuantity(Inventory p_inv)
        {
            Inventory i = await _context.Inventories.FirstOrDefaultAsync(inv => inv.Id == p_inv.Id);
            i.Quantity = p_inv.Quantity;
            _context.SaveChanges();
            return _context.Inventories.FirstOrDefault(inv => inv.Id == p_inv.Id);
        }

        public async Task<Inventory> UpdateInventoryQuantity(int p_invId, int p_purchasedQuantity)
        {
            Inventory theInventory = await _context.Inventories.FirstOrDefaultAsync(inv => inv.Id == p_invId);
            theInventory.Quantity -= p_purchasedQuantity;
            _context.SaveChanges();
            return _context.Inventories.FirstOrDefault(inv => inv.Id == p_invId);
        }

    }
}