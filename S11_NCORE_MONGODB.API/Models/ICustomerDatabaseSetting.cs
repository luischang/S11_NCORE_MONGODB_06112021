namespace S11_NCORE_MONGODB.API.Models
{
    public interface ICustomerDatabaseSetting
    {
        string ConnectionString { get; set; }
        string CustomerCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}