using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required(AllowEmptyStrings = false)]
        [DefaultValue("hhffffffffffffhh")]
        public string Name { get; set; }

        [InverseProperty("Genre")]
        public List<Movie> Movies { get; set; } = new List<Movie>();

        [InverseProperty("GenreSecondary")]
        public List<Movie> MoviesSecondary { get; set; } = new List<Movie>();
    }
}