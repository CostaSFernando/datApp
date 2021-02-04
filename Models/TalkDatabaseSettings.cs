namespace datApp.Models
{
    public class TalktelecomDbDatabaseSettings : ITalktelecomDbDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string DataCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITalktelecomDbDatabaseSettings
    {
        string BooksCollectionName { get; set; }
        string DataCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}