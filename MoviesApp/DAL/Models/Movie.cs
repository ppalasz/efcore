using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
    [Table("Movie", Schema = "Data")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMovie { get; set; }

        [Required]
        [Column("FilmTitle")]
        public string Title { get; set; }

        //[Required]
        [ForeignKey("IdGenre")]
        public Genre Genre { get; set; }

        [ForeignKey("IdSecondaryGenre")]
        public Genre GenreSecondary { get; set; }

        public FinancialData FinancialData { get; set; } = new FinancialData();

        [MaxLength(4)]
        [MinLength(4)]
        public Int16 Year { get; set; }

        public List<MovieXActor> MoviesActors { get; set; }

        [NotMapped]
        public List<int> Ratings { get; set; }

        [MaxLength(100)]
        public string Author { get; set; }

        public Movie(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}