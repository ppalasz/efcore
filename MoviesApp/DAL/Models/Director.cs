using System.ComponentModel.DataAnnotations;

namespace MoviesApp.DAL.Models
{
    public class Director : Person
    {
        

        public bool AppearedAsActor { get; set; }
    }
}