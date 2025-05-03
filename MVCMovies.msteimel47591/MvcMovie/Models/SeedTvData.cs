using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models;

public static class SeedTvData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new TelevisionSeriesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<TelevisionSeriesContext>>()))
        {
            // Look for any TV shows.
            if (context.TelevisionSeries.Any())
            {
                return;   // DB has been seeded
            }

            context.TelevisionSeries.AddRange(
                new TelevisionSeries
                {
                    Title = "Breaking Bad",
                    ReleaseDate = DateTime.Parse("2008-1-20"),
                    Genre = "Crime",
                    Price = 19.99M,
                    Rating = "TV-MA"
                },
                new TelevisionSeries
                {
                    Title = "Friends",
                    ReleaseDate = DateTime.Parse("1994-9-22"),
                    Genre = "Comedy",
                    Price = 14.99M,
                    Rating = "TV-PG"
                },
                new TelevisionSeries
                {
                    Title = "Game of Thrones",
                    ReleaseDate = DateTime.Parse("2011-4-17"),
                    Genre = "Fantasy",
                    Price = 24.99M,
                    Rating = "TV-MA"
                },
                new TelevisionSeries
                {
                    Title = "The Office",
                    ReleaseDate = DateTime.Parse("2005-3-24"),
                    Genre = "Comedy",
                    Price = 12.99M,
                    Rating = "TV-14"
                },
                new TelevisionSeries
                {
                    Title = "Stranger Things",
                    ReleaseDate = DateTime.Parse("2016-7-15"),
                    Genre = "Sci-Fi",
                    Price = 17.99M,
                    Rating = "TV-14"
                },
                new TelevisionSeries
                {
                    Title = "The Simpsons",
                    ReleaseDate = DateTime.Parse("1989-12-17"),
                    Genre = "Animation",
                    Price = 9.99M,
                    Rating = "TV-PG"
                },
                new TelevisionSeries
                {
                    Title = "The Crown",
                    ReleaseDate = DateTime.Parse("2016-11-4"),
                    Genre = "Drama",
                    Price = 18.99M,
                    Rating = "TV-MA"
                },
                new TelevisionSeries
                {
                    Title = "Sherlock",
                    ReleaseDate = DateTime.Parse("2010-7-25"),
                    Genre = "Mystery",
                    Price = 15.99M,
                    Rating = "TV-14"
                },
                new TelevisionSeries
                {
                    Title = "Parks and Recreation",
                    ReleaseDate = DateTime.Parse("2009-4-9"),
                    Genre = "Comedy",
                    Price = 13.99M,
                    Rating = "TV-PG"
                },
                new TelevisionSeries
                {
                    Title = "The Mandalorian",
                    ReleaseDate = DateTime.Parse("2019-11-12"),
                    Genre = "Sci-Fi",
                    Price = 20.99M,
                    Rating = "TV-14"
                }
            );

            context.SaveChanges();
        }
    }
}
