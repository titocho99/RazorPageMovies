using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;



namespace RazorPageMovies.Models
{
    public class SetData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPageMoviesContext>>()))
            {
                if (context == null || context.Movie == null)
                                                      
                {
                throw new ArgumentNullException("Contexto nulo");
                }

                if (context.Movie.Any() )
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title ="Avenger",
                        RealeseDate= DateTime.Parse("2001-01-09"),
                        Genero="Fiction",
                        Price=20,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Avenger 2",
                        RealeseDate = DateTime.Parse("2004-04-06"),
                        Genero = "Fiction",
                        Price = 40,
                        Rating = "NA"
                    },
                    new Movie
                    {
                        Title = "Avenger 3",
                        RealeseDate = DateTime.Parse("2009-05-11"),
                        Genero = "Fiction",
                        Price = 40,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Avenger 4",
                        RealeseDate = DateTime.Parse("2014-02-10"),
                        Genero = "Fiction",
                        Price = 60,
                        Rating = "R"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
