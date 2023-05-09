namespace Canteen.Models
{
    public class CanteenDatabaseSettings
    {

        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CanteenCollectionName { get; set; } = null!;
    }
}
