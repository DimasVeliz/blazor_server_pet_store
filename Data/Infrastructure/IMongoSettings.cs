namespace BlazorServerDemo.Data.Infrastructure
{
    public interface IMongoSettings
    {
        public string? User {get;set;}
        public string? Password {get;set;}
        public string? Host {get;set;}
        public string? Port {get;set;}
        public string? DataBaseName {get;set;}
        string BuildConnectionString();
    }
}