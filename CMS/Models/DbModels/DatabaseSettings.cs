namespace CMS.Models.DbModels
{
    public class DatabaseSettings 
    {
        public string CSRCollection { get; set; } = null!;
        public string ECUCollection { get; set; } = null!;
        public string CertificateCollection { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string UDatabaseName { get; set; } = null!;
    }
}
