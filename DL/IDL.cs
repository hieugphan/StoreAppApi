﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
namespace DataLogic
{
    /// <summary>
    /// Handles all the data access logic for the app
    /// </summary>
    public interface IDL
    {
        /// <summary>
        /// Gets a list of all customers from DB-Customers
        /// </summary>
        /// <returns>list of customers</returns>
        Task<List<Customer>> GetAllCustomers();

        /// <summary>
        /// Gets a customer using custID from DB-Customers
        /// </summary>
        /// <param name="p_customerID"></param>
        /// <returns>a Customer or null</returns>
        Task<Customer> GetACustomer(int p_customerID);

        /// <summary>
        /// Adds obj Customers to DB-Customers
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns>obj customers</returns>
        Task<Customer> AddCustomer(Customer p_customer);

        /// <summary>
        /// Gets all inventories from DB-Inventories
        /// </summary>
        /// <returns>list of all inventories</returns>
        Task<List<Inventory>> GetAllInventories();

        /// <summary>
        /// Gets a specific store's inventory from DB-Inventories
        /// </summary>
        /// <param name="p_storeFront"></param>
        /// <returns>list of inventories</returns>
        Task<List<Inventory>> GetAStoreInventory (StoreFront p_storeFront);

        /// <summary>
        /// Gets a specific store's inventory from DB-Inventories
        /// </summary>
        /// <param name="p_storeFrontID">sf ID</param>
        /// <returns>list of inventories</returns>
        Task<List<Inventory>> GetAStoreInventory(int p_storeFrontId);

        /// <summary>
        /// Updates current quantity of an inventory (a product of a specific inventory) to p_quantity to DB-Inventories
        /// </summary>
        /// <param name="p_inv"></param>
        /// <param name="p_quantity"></param>
        /// <returns>the updated inventories obj</returns>
        Task<Inventory> UpdateInventoryQuantity(Inventory p_inv);
        /// <summary>
        /// Updates an inventory using p_invId and substract its inventory to p_purchasedQuantity --- DB-Inventories
        /// </summary>
        /// <param name="p_invId">inventory Id</param>
        /// <param name="p_purchasedQuantity">line item quantity</param>
        /// <returns></returns>
        Task<Inventory> UpdateInventoryQuantity(int p_invId, int p_purchasedQuantity);

        /// <summary>
        /// Creates a record of a newly added product to DB-Inventories
        /// </summary>
        /// <param name="p_invt"></param>
        /// <returns></returns>
        Task<Inventory> AddNewProductInventory(Inventory p_invt);

        /// <summary>
        /// Replenishes an inventory quantity by adding current quantity by p_replenishedQuantity --- DB-Inventories
        /// </summary>
        /// <param name="p_invId">inventory Id</param>
        /// <param name="p_replenishedQuantity">replenished quantity</param>
        /// <returns></returns>
        Task<Inventory> ReplenishInventory(int p_invId, int p_replenishedQuantity);

        /// <summary>
        /// Gets all line items from DB-LineItems
        /// </summary>
        /// <returns>list of all line items</returns>
        Task<List<LineItem>> GetAllLineItems();

        /// <summary>
        /// Adds a line item to the DB-LineItems
        /// </summary>
        /// <param name="p_lineItem"></param>
        /// <returns></returns>
        Task<LineItem> AddALineItem(LineItem p_lineItem);
        /// <summary>
        /// Gets all orders from DB-Orders
        /// </summary>
        /// <returns>list of all orders</returns>
        Task<List<Order>> GetAllOrders();

        /// <summary>
        /// Adds an order to DB-Orders
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>the added order with its new ID</returns>
        Task<Order> AddAnOrder(Order p_order);
        /// <summary>
        /// Gets all orders of a customer from DB-Orders
        /// </summary>
        /// <param name="p_customerId">customer ID</param>
        /// <returns></returns>
        Task<List<Order>> GetACustomerOrders(int p_customerId);
        /// <summary>
        /// Gets all orders of a store front from DB-Orders
        /// </summary>
        /// <param name="p_storeFrontId">store front ID</param>
        /// <returns></returns>
        Task<List<Order>> GetAStoreFrontOrders(int p_storeFrontId);

        /// <summary>
        /// Gets a list of all products from DB-Products
        /// </summary>
        /// <returns>list of all products</returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// Gets a list of all store fronts from DB-StoreFronts
        /// </summary>
        /// <returns>list of all storefronts</returns>
        Task<List<StoreFront>> GetAllStoreFronts();

    }    
}
