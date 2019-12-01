namespace eSims.Models
{
    public class eSimsDatabaseSettings : IeSimsDatabaseSettings
    {
        public string PrezentaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IeSimsDatabaseSettings
    {
        string PrezentaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
