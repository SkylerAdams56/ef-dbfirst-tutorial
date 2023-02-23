using ef_dbfirst_tutorial;
using ef_dbfirst_tutorial.Models;
using Microsoft.EntityFrameworkCore;


var custCtrl = new CustomersController();

var bootcamp = await custCtrl.GetByIdAsync(37);
bootcamp.Sales = 5000;
var success = await custCtrl.UpdateAsync(bootcamp);

Console.WriteLine(success ? "Ok" : "Failed");

//var dbc = new SalesDbContext();

//// customer = await GetById(1);

//var cutsomers = await GetAll();

//foreach (var c in cutsomers)
//{
//    Console.WriteLine(c.Name);
//}
//async Task<Customer> GetById(int id)
//{
//        return await dbc.Customers.FindAsync(id)!;
//}

//async Task<List<Customer>>  GetAll()
//{
//    return await dbc.Customers.ToListAsync();
//}


//var orderWithCustomers = from o in dbc.Orders
//                         join c in dbc.Customers
//                            on o.CustomerId equals c.Id
//                         orderby c.Name
//                         select new
//                         {
//                             Id = o.Id,
//                             Desc = o.Description,
//                             Customer = c.Name
//                         };
//foreach (var oc in orderWithCustomers)
//{
//    Console.WriteLine($"{oc.Id,2} | {oc.Desc, -20} | {oc.Customer}");
//}



//var orders = from o in dbc.Orders
//             select o;
//foreach (var order in orders)
//{
//    Console.WriteLine(order.Description);
//}

//var customers = dbc.Customers.Where(x => x.City == "Cincinnati")
//                             .OrderByDescending(x => x.Sales)
//                             .ToList();

//foreach (var customer in customers)
//{
//    Console.WriteLine(customer.Name);
//}

//var cust = new Customer()
//{
//    Id = 0,
//    Name = "Bootcamp",
//    City = "Mason",
//    State = "OH",
//    Sales = 0,
//    Active = true
//};
//var success = await custCtrl.InsertAsync(cust);
