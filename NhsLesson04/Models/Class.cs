namespace NhsLesson04.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Author { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; } 
    }
}
