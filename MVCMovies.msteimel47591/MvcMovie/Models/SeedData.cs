using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;


namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = DateTime.Parse("1994-9-22"),
                        Genre = "Drama",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-3-24"),
                        Genre = "Crime",
                        Price = 14.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        ReleaseDate = DateTime.Parse("2008-7-18"),
                        Genre = "Action",
                        Price = 12.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "Pulp Fiction",
                        ReleaseDate = DateTime.Parse("1994-10-14"),
                        Genre = "Crime",
                        Price = 11.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Forrest Gump",
                        ReleaseDate = DateTime.Parse("1994-7-6"),
                        Genre = "Drama",
                        Price = 10.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "Inception",
                        ReleaseDate = DateTime.Parse("2010-7-16"),
                        Genre = "Sci-Fi",
                        Price = 13.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "The Matrix",
                        ReleaseDate = DateTime.Parse("1999-3-31"),
                        Genre = "Sci-Fi",
                        Price = 9.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "The Lion King",
                        ReleaseDate = DateTime.Parse("1994-6-24"),
                        Genre = "Animation",
                        Price = 8.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Gladiator",
                        ReleaseDate = DateTime.Parse("2000-5-5"),
                        Genre = "Action",
                        Price = 10.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Titanic",
                        ReleaseDate = DateTime.Parse("1997-12-19"),
                        Genre = "Romance",
                        Price = 11.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "The Avengers",
                        ReleaseDate = DateTime.Parse("2012-5-4"),
                        Genre = "Action",
                        Price = 14.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "Schindler's List",
                        ReleaseDate = DateTime.Parse("1993-12-15"),
                        Genre = "Drama",
                        Price = 12.99M,
                        Rating = "R"
                    }
                );
            context.SaveChanges();
        }
    }
}
