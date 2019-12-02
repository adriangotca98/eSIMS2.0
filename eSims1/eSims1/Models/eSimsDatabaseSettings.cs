namespace eSims1.Models
{
    public class eSimsDatabaseSettings : IeSimsDatabaseSettings
    {
        public string SubjectsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IeSimsDatabaseSettings
    {
        string SubjectsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
