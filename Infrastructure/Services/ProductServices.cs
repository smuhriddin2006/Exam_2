using Domain;
using Npgsql;
namespace Infrastructure.Services;

public class ProductServices
{
    const string connectionString = @"Host=localhost;
                                      Database=CommerenceDB;
                                      Username=postgres;
                                      Password=umed008;";
    public List<Products> GetProductByCategory(string Category)
    {
        List<Products> products = [];
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select * from products 
                            where category = @Category";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                cgt.Parameters.AddWithValue("Category", Category);
                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    products.Add(new Products
                    {
                        Id = get.GetInt32(0),
                        Name = get.GetString(1),
                        Description = get.GetString(2),
                        Price = get.GetDecimal(3),
                        Category = get.GetString(4),
                        StockQunatity = get.GetInt32(5),
                        Manufacturer = get.GetString(6)
                    });
               
             }}
             return products;
             }  


    public List<Products> GetUniqueManufactures()
    {
                 List<Products> products = [];
    
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string ctg = @"select distinct manufacturer from products";
                NpgsqlCommand cgt = new NpgsqlCommand(ctg, connection);

                
                var get = cgt.ExecuteReader();

                while (get.Read())
                {
                    products.Add(new Products
                    {
                    Manufacturer = get.GetString(0)
                    });
               
             }}
             return products;
             }
             
             
             
    }    
                
        
            
            
    
