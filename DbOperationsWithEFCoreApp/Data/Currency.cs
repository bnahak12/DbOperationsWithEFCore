namespace DbOperationsWithEFCoreApp.Data
{
    public class Currency
    {
        public int Id { get; set; }
        public string currency { get; set; }
        public string Description { get; set; }
        public ICollection<BookPrice> BookPrice { get; set; }
    }
}
