namespace LibraryBackend.TDO
{
    public class BorrowBookTDO
    {
        public long Id { get; set; }

        public long IdUser { get; set; }

        public long IdBook { get; set; }

        public string NameBook { get; set; }
        public string Estado { get; set; }

        public DateTime Date { get; set; }

    }
}
