using System.Collections.Generic;

namespace MyWebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Controlado por EFCore
        public List<Book> Books { get; set; }
    }
}