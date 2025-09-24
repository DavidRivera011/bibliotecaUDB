using System;
using System.ComponentModel.DataAnnotations;

public class Prestamo
{
    public int Id { get; set; }

    [Required]
    public int LibroId { get; set; }

    [Required]
    public int MiembroId { get; set; }

    [Required]
    public DateTime LoanDate { get; set; } = DateTime.UtcNow;

    public DateTime? ReturnDate { get; set; }

    public Libro Libro { get; set; }
    public Miembro Miembro { get; set; }
}
