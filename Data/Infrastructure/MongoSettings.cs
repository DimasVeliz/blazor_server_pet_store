namespace BlazorServerDemo.Data.Infrastructure
{
    public class MongoSettings : IMongoSettings
    {
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public string? Port { get; set; }
        public string? DataBaseName { get; set; }

        public string BuildConnectionString()
        {
            if (String.IsNullOrEmpty(this.User))
            {
                return $@"mongodb://{this.Host}:{this.Port}";
            }
            return $@"mongodb://{this.User}:{this.Password}@{this.Host}:{this.Port}";


        }
    }
}