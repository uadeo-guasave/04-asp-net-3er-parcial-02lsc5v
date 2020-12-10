namespace MyWebApi.Models
{
    public class Book
    {
        public string AmazonId { get; set; }
        public string FileName { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CategoryId { get; set; }

        // Controlado por EFCore
        public Category Category { get; set; }

    }
}