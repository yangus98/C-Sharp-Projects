﻿using BibliotecaIdentityUltima.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaIdentityUltima.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Autore> Autori { get; set; }
        public DbSet<Editore> Editori { get; set; }
        public DbSet<Libro> Libri { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}