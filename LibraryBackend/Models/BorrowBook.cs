namespace LibraryBackend.Models
{

    public class BorrowBook
    {
        public long Id { get; set; }
        
        public long IdUser { get; set; }
        
        public long IdBook { get; set; }
        
        public bool Flag { get; set; }

        public DateTime Date { get; set; }

    }


}
