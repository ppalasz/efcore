using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace MoviesApp.DAL.Models
{
    internal class MoviesDbContext : DbContext
    {
        private MoviesDbContext() //tylko z factory
        {
        }

        public MoviesDbContext(DbContextOptions options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Genre> Genre { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=DESKTOP-HCUBQMJ;Database=EFCore;Trusted_Connection=True;";
            //ConfigurationManager.ConnectionStrings["EFCore"].ConnectionString;

            optionsBuilder.UseSqlServer(connectionString, options => options.UseRowNumberForPaging());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //modelBuilder.ApplyConfiguration(new Actor());

            builder.Entity<Movie>()
                .OwnsOne<FinancialData>(x => x.FinancialData);

            builder.Entity<Person>()
                .Property(x => x.Sex)
                .HasConversion(
                    x => x.ToString(),
                    x => (Sex)Enum.Parse(typeof(Sex), x));

            var firstLetterToUpper = new ValueConverter<string, string>
            (
                x => !Char.IsUpper(x[0]) ? Char.ToUpper(x[0]) + x.Substring((1)) : x,
                x => x
            );

            builder.Entity<Person>()
                .Property(x => x.FirstName)
                .HasConversion(firstLetterToUpper);

            builder.Entity<Person>()
                .Property(x => x.LastName)
                .HasConversion(firstLetterToUpper);

            builder.Entity<Person>() //1:1
                .HasOne(x => x.Address)
                .WithOne(x => x.Person);



            builder.Entity<Movie>()
                .HasOne(x => x.Genre)
                .WithMany(x => x.Movies)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Movie>()
                .HasOne(x => x.GenreSecondary)
                .WithMany(x => x.MoviesSecondary)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Movie>()
                .Property<DateTime>("LastUpdate");
            // .HasDefaultValue(DateTime.Now);

            


            //dziedziczenie
            builder.Entity<Actor>().HasBaseType<Person>();
            builder.Entity<Director>().HasBaseType<Person>();

            builder.Entity<MovieXActor>().HasKey(x => new { x.ActorId, x.MovieId });

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var entitiesWithLastdatedField = this.ChangeTracker.Entries()
                .Where(x => ((x.State == EntityState.Modified) || (x.State == EntityState.Added))
                && x.Properties.Any(p => p.Metadata.Name == "LastUpdate"));

            foreach (EntityEntry en in entitiesWithLastdatedField)
            {
                en.Property("LastUpdate").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }

        //[DbFunction("NumberOfMovies","dbo")]
        //public static int NumberOfMovies(int idGenre)
        //{
        //    return (-1);

        //}
    }
}