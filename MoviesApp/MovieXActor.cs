using MoviesApp.DAL.Models;

namespace MoviesApp
{
    public class MovieXActor
    {
        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}