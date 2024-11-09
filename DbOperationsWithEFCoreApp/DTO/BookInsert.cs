namespace DbOperationsWithEFCoreApp.DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public int LanguageId { get; set; }
        public List<BookPriceDto> BookPrices { get; set; }
    }

    public class BookPriceDto
    {
        public float Amount { get; set; }
        public int CurrencyId { get; set; }
    }

}
