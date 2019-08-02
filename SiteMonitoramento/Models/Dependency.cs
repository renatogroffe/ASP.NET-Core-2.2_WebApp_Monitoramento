namespace SiteMonitoramento.Models
{
    public class Dependency
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Url { get; set; }
        public string UriEndpoint { get; set; }
        public string PrimaryKey { get; set; }
        public string QueueName { get; set; }
    }
}