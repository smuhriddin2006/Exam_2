using Domain;
using Npgsql;
namespace Infrastructure.Services;

public class CustomerService
{
            const string connectionString = @"Host=localhost;
                                      Database=CommerenceDB;
                                      Username=postgres;
                                      Password=umed008;";
    public List<Customers> GetCustomersRegisteredBetween(DateTime startDate, DateTime endDate)
    {

    {
                 List<Customers> customers = [];
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select *  from customers
                                where registration_date between @startDate and @endDate";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);
                cgt.Parameters.AddWithValue("startDate", startDate);
                cgt.Parameters.AddWithValue("endDate", endDate);
                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                customers.Add(new Customers
                    {

                        Id = get.GetInt32(0),
                        FirtsName = get.GetString(1),
                        LastName = get.GetString(2),
                        Email = get.GetString(3),
                        Phone = get.GetString(4),
                        Address = get.GetString(5),
                        RegistrationDate = get.GetDateTime(6)                   
                    });
               
             }}
             return customers;
             }
             
             
             
    }    
}
