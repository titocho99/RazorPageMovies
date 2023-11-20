using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Data;
using RazorPageMovies.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPageMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageMovies.Data.RazorPageMoviesContext _context;

        public IndexModel(RazorPageMovies.Data.RazorPageMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = default!;
        [BindProperty(SupportsGet = true)]

        public string? SearchString { get; set; }

        public SelectList? Generos { get; set; }
        [BindProperty(SupportsGet = true)]

        public string? MovieGenero { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> generoQuery = from m in _context.Movie
                                             orderby m.Genero
                                             select m.Genero;
            var movies = from m in _context.Movie
                         select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));

            }

            if(!string.IsNullOrEmpty(MovieGenero))
            {
                movies = movies.Where(x => x.Genero == MovieGenero);
            }

            if (_context.Movie != null)
            {
                Generos= new SelectList(await generoQuery.Distinct().ToListAsync());
                Movie = await movies.ToListAsync();
            }
        }
    }
}
