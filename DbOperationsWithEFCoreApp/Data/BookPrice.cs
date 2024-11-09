using System.Text.Json.Serialization;

namespace DbOperationsWithEFCoreApp.Data
{
    public class BookPrice
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int BookId { get; set; }
        public int CurrencyId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public Currency Currency { get; set; }
    }
}
