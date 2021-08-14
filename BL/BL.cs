using Models;
using DataLogic;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BL : IBL
    {
        private readonly IDL _repo;

        public BL(IDL p_repo)
        {
            _repo = p_repo;
        }

        public async Task<LineItem> AddALineItem(LineItem p_lineItem)
        {
            LineItem found = await _repo.AddALineItem(p_lineItem);
            if (found == null)
            {
                throw new Exception("LineItem Was Null");
            }
            return found;
        }

        public async Task<Order> AddAnOrder(Order p_order)
        {
            Order found = await _repo.AddAnOrder(p_order);
            if(found == null)
            {
                throw new Exception("Order Was Null");
            }
            return found;
        }

        public async Task<Customer> AddCustomer(Customer p_customer)
        {
            Customer found = await _repo.AddCustomer(p_customer);
            if (found == null)
            {
                throw new Exception("Customer Was Null");
            }
            return found;
        }

        public async Task<Inventory> AddNewProductInventory(Inventory p_invt)
        {
            Inventory found = await _repo.AddNewProductInventory(p_invt);
            if (found == null)
            {
                throw new Exception("Customer Was Null");
            }
            return found;
        }

        public async Task<Customer> GetACustomer(int p_customerID)
        {
            Customer found = await _repo.GetACustomer(p_customerID);
            if (found == null)
            {
                throw new Exception("Customer Was Null");
            }

            return found;
        }

        public async Task<List<Order>> GetACustomerOrders(int p_customerId)
        {
            return await _repo.GetACustomerOrders(p_customerId);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _repo.GetAllCustomers();
        }

        public async Task<List<Inventory>> GetAllInventories()
        {
            return await _repo.GetAllInventories();
        }

        public async Task<List<LineItem>> GetAllLineItems()
        {
            return await _repo.GetAllLineItems();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _repo.GetAllOrders();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repo.GetAllProducts();
        }

        public async Task<List<StoreFront>> GetAllStoreFronts()
        {
            return await _repo.GetAllStoreFronts();
        }

        public async Task<List<LineItem>> GetAnOrderLineItems(Order p_order)
        {
            List<LineItem> listOfAllLineItems = await this.GetAllLineItems();
            List<LineItem> listOfAnOrderLineItems = new List<LineItem>();
            foreach (LineItem li in listOfAllLineItems)
            {
                if(li.OrderId == p_order.Id)
                {
                    listOfAnOrderLineItems.Add(li);
                }
            }
            return listOfAnOrderLineItems;
        }

        public async Task<List<LineItem>> GetAnOrderLineItems(int p_orderID)
        {
            List<LineItem> listOfAllLineItems = await this.GetAllLineItems();
            List<LineItem> listOfAnOrderLineItems = new List<LineItem>();
            foreach (LineItem li in listOfAllLineItems)
            {
                if(li.OrderId == p_orderID)
                {
                    listOfAnOrderLineItems.Add(li);
                }
            }
            return listOfAnOrderLineItems;
        }

        //public StoreFront GetAStore(int p_id)
        //{
        //    List<StoreFront> listOfStoreFronts = this.GetAllStoreFronts();
        //    StoreFront theStore = new StoreFront();
        //    foreach (StoreFront sf in listOfStoreFronts)
        //    {
        //        if (sf.Id == p_id)
        //        {
        //            theStore = sf;
        //        }
        //    }
        //    return theStore;
        //}

        public async Task<List<Order>> GetAStoreFrontOrders(int p_storeFrontId)
        {
            return await _repo.GetAStoreFrontOrders(p_storeFrontId);
        }

        public async Task<List<Inventory>> GetAStoreInventory(StoreFront p_storeFront)
        {
            return await _repo.GetAStoreInventory(p_storeFront);
        }

        public async Task<List<Inventory>> GetAStoreInventory(int p_storeFrontId)
        {
            return await _repo.GetAStoreInventory(p_storeFrontId);
        }
        

        public async Task<Inventory> ReplenishInventory(int p_invId, int p_replenishedQuantity)
        {
            return await _repo.ReplenishInventory(p_invId, p_replenishedQuantity);
        }
                       

        //public List<Customer> SearchCustomers(string p_criteria, string p_value)
        //{
        //    List<Customer> listOfCustomers = this.GetAllCustomers();
        //    List<Customer> listOfSearchedCustomers = new List<Customer>();
        //    switch(p_criteria)
        //    {
        //        case "phone":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.Phone == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "email":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.Email == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "state":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.State == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "city":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.City == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "address":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.Address == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "lname":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.Lname == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        case "fname":
        //            try
        //            {
        //                foreach(Customer c in listOfCustomers)
        //                {
        //                    if (c.Fname == p_value)
        //                    {
        //                        listOfSearchedCustomers.Add(c);
        //                    }
        //                }
        //                return listOfSearchedCustomers;
        //            }
        //            catch(System.Exception e)
        //            {
        //                System.Console.WriteLine("Something Wrong");
        //                System.Console.WriteLine(e);
        //                return listOfSearchedCustomers;
        //            }
        //        default:
        //            //this would return empty list / count = 0
        //            return listOfSearchedCustomers;
        //    }
        //}

        public async Task<List<Order>> SearchOrders(string p_criteria, string p_value)
        {
            List<Order> listOfOrders = await this.GetAllOrders();
            List<Order> listOfSearchedOrders = new List<Order>();
            int value = int.Parse(p_value);
            switch(p_criteria)
            {
                case "id":
                foreach (Order o in listOfOrders)
                {
                    if(o.Id == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                case "customerID":
                foreach (Order o in listOfOrders)
                {
                    if(o.CustomerId == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                case "storeFrontID":
                foreach (Order o in listOfOrders)
                {
                    if(o.StoreFrontId == value)
                    {
                        listOfSearchedOrders.Add(o);
                    }
                }
                return listOfSearchedOrders;
                default:
                return listOfSearchedOrders;
            }
        }

        //public List<StoreFront> SearchStoreFronts(string p_criteria, string p_value)
        //{
        //    List<StoreFront> listOfStoreFronts = this.GetAllStoreFronts();
        //    List<StoreFront> listOfSearchedStoreFronts = new List<StoreFront>();
        //    switch(p_criteria)
        //    {
        //        case "id":
        //            //loop through the listOfStoreFront, 
        //            //if the storefront in the list match the p_value
        //            //add that storefront to the listOfSearchedStoreFronts
        //            foreach(StoreFront s in listOfStoreFronts)
        //            {
        //                if (s.Id == int.Parse(p_value))
        //                {
        //                    listOfSearchedStoreFronts.Add(s);
        //                }
        //            }
        //            return listOfSearchedStoreFronts;
        //        case "name":
        //            for(int i = 0; i < listOfStoreFronts.Count; i++)
        //            {
        //                if (listOfStoreFronts[i].Name == p_value)
        //                {
        //                    listOfSearchedStoreFronts.Add(listOfStoreFronts[i]);
        //                }
        //            }
        //            return listOfSearchedStoreFronts;
        //        case "address":
        //            foreach(StoreFront s in listOfStoreFronts)
        //            {
        //                if (s.Address == p_value)
        //                {
        //                    listOfSearchedStoreFronts.Add(s);
        //                }
        //            }
        //            return listOfSearchedStoreFronts;
        //        case "city":
        //            foreach(StoreFront s in listOfStoreFronts)
        //            {
        //                if (s.City == p_value)
        //                {
        //                    listOfSearchedStoreFronts.Add(s);
        //                }
        //            }
        //            return listOfSearchedStoreFronts;
        //        case "state":
        //            foreach(StoreFront s in listOfStoreFronts)
        //            {
        //                if (s.State == p_value)
        //                {
        //                    listOfSearchedStoreFronts.Add(s);
        //                }
        //            }
        //            return listOfSearchedStoreFronts;
        //        default:
        //            return listOfSearchedStoreFronts;
        //    }
        //}

        public async Task<Inventory> UpdateInventoryQuantity(Inventory p_inv)
        {
            //Need null exception handler
            return await _repo.UpdateInventoryQuantity(p_inv);
        }

        public async Task<Inventory> UpdateInventoryQuantity(int p_invId, int p_purchasedQuantity)
        {
            return await _repo.UpdateInventoryQuantity(p_invId, p_purchasedQuantity);
        }

    }
}