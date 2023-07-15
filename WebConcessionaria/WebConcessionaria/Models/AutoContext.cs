using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebConcessionaria.Models;

namespace WebConcessionaria.Models
{
    public class AutoContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public AutoContext(DbContextOptions<AutoContext> options) : base(options)
        {
        }
    }
}
