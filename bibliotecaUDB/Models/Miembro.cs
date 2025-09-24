using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Miembro
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string NombreCompleto { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public ICollection<Prestamo> Prestamos { get; set; }
}
