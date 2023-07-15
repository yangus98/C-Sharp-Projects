using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EseFilms.Models
{
    public class FilmContext: DbContext
    {
        public DbSet<Film> Films { get; set; }
        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }
    }
}
