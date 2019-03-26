using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.DAL.Models
{
   

    public class Actor:Person
    {
       
        

        public List<MovieXActor> MoviesActors { get; set; }

       

       
    }
}