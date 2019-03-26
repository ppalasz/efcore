using Microsoft.EntityFrameworkCore;
using MoviesApp.DAL;
using System;
using System.Linq;
using MoviesApp.DAL.Models;

namespace MoviesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var moviesDbContextFactory = new MoviesDbContextFactory();
            var dbcts = moviesDbContextFactory.CreateDbContext(new string[0]);

            Director dir = new Director();
            dir.AppearedAsActor = true;
            dir.FirstName = "Ziutek";
            dir.LastName = "Maliniak";
            dir.Sex = Sex.Female;
            dir.Address = new Address() {City = "Warszawa", Street = "Zamieniecka"};
            dbcts.Directors.Add(dir);


            Actor act = new Actor();
            dir.FirstName = "Adam";
            dir.LastName = "Kowalski";
            dir.Sex = Sex.Female;
            act.Address = new Address() { City = "Kraków", Street = "ffff" };
            dbcts.Actors.Add(act);

            dbcts.SaveChanges();
            //var movie = new Movie("Wejście Smoka","Too");

            // var t = dbcts.Genre.Select(x => new {x.Name, count= MoviesDbContext.NumberOfMovies(x.Id) }).ToList();

            //var rs = dbcts.Actors
            //    .Include(x => x.MoviesActors)
            //    .ThenInclude(y => y.Movie)
            //    .Select(x => new { x.FirstName, x.LastName, Movies = x.MoviesActors.Select(y => y.Movie).ToList() });

            //foreach (var r in rs)
            //{
            //    Console.WriteLine("item=" + r.FirstName + " " + r.LastName);

            //    foreach (var f in r.Movies)
            //    {
            //        Console.WriteLine("    m =" + f.Title + " " + f.Year);
            //    }
            //}
            //Console.WriteLine("item=" + r.Title+ " " + r.FirstName+ " " + r.LastName);

            //dbcts.Movies.Add(movie);

            //dbcts.Attach(movie); //dodany do śledzenia
            //dbcts.Entry(movie).State = EntityState.Added; //! stan na dodany
            //dbcts.Entry(movie).Property("LastUpdate").CurrentValue = DateTime.Now; //zmieniona właściwość

            //dbcts.Actors.Add(new Actor() {FirstName = "mimi", LastName = "bumba", Sex = Sex.Female});

            //dbcts.Genre.Add(new Genre() {Name = ""});
            // Console.WriteLine("count 1=" + MoviesDbContext.NumberOfMovies());
            //dbcts.SaveChanges();
            //Console.WriteLine("count 2=" + MoviesDbContext.NumberOfMovies());

            var count = dbcts.Movies.Count();

            Console.WriteLine("count=" + count);

            Console.WriteLine("press any key");
            Console.ReadKey();
        }
    }
}