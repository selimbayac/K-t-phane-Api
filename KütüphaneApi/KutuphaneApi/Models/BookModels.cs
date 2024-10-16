namespace KutuphaneApi.Models
{
    public class BookModels
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public int Piece { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
