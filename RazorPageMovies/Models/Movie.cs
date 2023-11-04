using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPageMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]

        public DateTime? RealeseDate { get; set; }

        public string? Genero { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal Price { get; set; }

        public string? Rating { get; set; }

    }
}
