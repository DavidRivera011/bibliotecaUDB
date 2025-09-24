namespace bibliotecaUDB.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Libro> Libros { get; set; }
    public DbSet<Miembro> Miembros { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
}

