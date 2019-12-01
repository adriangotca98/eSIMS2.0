namespace Proiect.Models
{
    public class MateriiDatabaseSettings : IMateriiDatabaseSettings
    {
        public string MateriiCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public interface IMateriiDatabaseSettings
    {
        string MateriiCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
