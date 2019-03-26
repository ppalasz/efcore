using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using MoviesApp.DAL.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MoviesApp.DAL
{
    internal class MoviesDbContextFactory : IDesignTimeDbContextFactory<MoviesDbContext>
    {
        private static ILoggerFactory loggerFactory = new LoggerFactory(
            new List<ILoggerProvider>() { new DebugLoggerProvider() }
        );

        public MoviesDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("config.json");

            var configuration = configurationBuilder.Build();

            string connectionString = configuration.GetConnectionString("EFCore");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseSqlServer(connectionString);
            dbContextOptionsBuilder.UseLoggerFactory(loggerFactory);
            dbContextOptionsBuilder.ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new MoviesDbContext(dbContextOptionsBuilder.Options);
        }
    }
}