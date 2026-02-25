using Infrastructure.Services;

ProductServices productServices = new();
CustomerService customerService = new();
OrderService orderService = new();

// task 3 done
// var d = productServices.GetProductByCategory("Category A");
// foreach(var s in d)
// {
//     System.Console.WriteLine(s.Id +  s.Category);
// }

//Task 2 done 

// var d2 = productServices.GetUniqueManufactures();

// foreach(var s in d2)
// {
//     System.Console.WriteLine(s.Id + s.Manufacturer);
// }

// task 3 done 
// var d3 = customerService.GetCustomersRegisteredBetween(new DateTime(2024,2,5), new DateTime(2024,9,5));

// foreach (var d in d3)
// {
//     System.Console.WriteLine(d.Id + d.FirtsName  + d.Address + d.Email + d.Phone + d.LastName + d.RegistrationDate);
// }
//task 4 done
// orderService.GetOrderCountByCutomer();
// task 5done 
// orderService.GetCustomerWithMaxOrders();

// task 6
orderService.GetOrdersAboveAverageTotalPrice();

// task 7
orderService.GetOrdersByCustomer();
