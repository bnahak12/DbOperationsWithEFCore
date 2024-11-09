using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DbOperationsWithEFCoreApp.Data
{
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(55)]
        public string Title { get; set; }

        [MaxLength(155)]
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public ICollection<BookPrice> BookPrice { get; set; }
    }

}
