using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Data;

public class TelevisionSeriesContext : DbContext
{
    public TelevisionSeriesContext (DbContextOptions<TelevisionSeriesContext> options)
        : base(options)
    {
    }

    public DbSet<MvcMovie.Models.TelevisionSeries> TelevisionSeries { get; set; } = default!;
}
