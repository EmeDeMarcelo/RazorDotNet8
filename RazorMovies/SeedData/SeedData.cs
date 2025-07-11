using Microsoft.EntityFrameworkCore;
using RazorMovies.Data;

namespace RazorMovies.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorMovies.Data.RazorMoviesContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorMoviesContext>>()))
            {
                
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorMoviesContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                context.Movie.AddRange(
                    new Models.Movie
                    {
                        Title = "Inception",
                        ReleaseDate = DateTime.Parse("2010-7-16"),
                        Genre = "Science Fiction",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Models.Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-3-24"),
                        Genre = "Crime",
                        Price = 8.99M,
                        Rating = "G"
                    },
                    new Models.Movie
                    {
                        Title = "The Dark Knight",
                        ReleaseDate = DateTime.Parse("2008-7-18"),
                        Genre = "Action",
                        Price = 10.99M,
                        Rating = "F"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
