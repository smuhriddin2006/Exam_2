using Domain;
using Npgsql;
namespace Infrastructure.Services;

public class OrderService
{
    const string connectionString = @"Host=localhost;
                                      Database=CommerenceDB;
                                      Username=postgres;
                                      Password=umed008;";
 public void GetOrderCountByCutomer()
    {
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select c.id, c.FirstName , count(o.Id) as count_max from customers c
join orders o on o.CustomerId = c.id
group by c.id, c.FirstName
";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    System.Console.WriteLine(get.GetInt32(0));
                    System.Console.WriteLine(get.GetString(1));
                    System.Console.WriteLine(get.GetInt32(2));
                    };
               
             }}

     public void GetCustomerWithMaxOrders()
    {
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select c.id, c.FirstName, LastName, Email, Phone, Address, count(o.Id) as count_max from customers c
join orders o on o.CustomerId = c.id
group by c.id, c.FirstName
order by count_max  Desc
Limit 1
";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    System.Console.WriteLine(get.GetInt32(0));
                    System.Console.WriteLine(get.GetString(1));
                    System.Console.WriteLine(get.GetString(2));
                    System.Console.WriteLine(get.GetString(3));
                    System.Console.WriteLine(get.GetString(4));
                     System.Console.WriteLine(get.GetString(5));
                     System.Console.WriteLine(get.GetInt32(6));
                    };
               
             }}

             public void GetOrdersAboveAverageTotalPrice()
    {
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select * from orders
                                where totalprice > (
                                select avg(totalprice)
                                from orders)";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    System.Console.WriteLine(get.GetInt32(0));
                    System.Console.WriteLine(get.GetInt32(1));
                    System.Console.WriteLine(get.GetInt32(2));
                    System.Console.WriteLine(get.GetDateTime(3));
                    System.Console.WriteLine(get.GetInt32(4));
                     System.Console.WriteLine(get.GetDecimal(5));
                     System.Console.WriteLine(get.GetString(6));
                    };
               
             }}

             public void GetOrdersByCustomer()
    {
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select  c.id , c.FirstName,o.id , o.orderdate, o.totalprice
from customers c
join orders o ON c.id = o.CustomerId
where c.id = 1
Order by o.orderdate DESC;";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    System.Console.WriteLine(get.GetInt32(0));
                    System.Console.WriteLine(get.GetString(1));
                    System.Console.WriteLine(get.GetInt32(2));
                    System.Console.WriteLine(get.GetDateTime(3));
                     System.Console.WriteLine(get.GetDecimal(5));

                    };
               
             }}
             
             }  


