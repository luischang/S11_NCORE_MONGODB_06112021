using MongoDB.Driver;
using S11_NCORE_MONGODB.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S11_NCORE_MONGODB.API.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _mongoDBContext;


        public CustomerService(ICustomerDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);

            _mongoDBContext = database.GetCollection<Customer>(setting.CustomerCollectionName);
        }


        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _mongoDBContext.Find(c => true).ToListAsync();
        }


        public async Task<Customer> GetCustomersById(string id)
        {
            return await _mongoDBContext.Find<Customer>(c => c.id == id).FirstOrDefaultAsync();
        }



    }
}
