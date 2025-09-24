using System.ComponentModel.DataAnnotations;

public class Libro
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Titulo { get; set; }

    [Required, StringLength(100)]
    public string Autor { get; set; }

    [StringLength(20)]
    public string ISBN { get; set; }

    [Range(0, 1000)]
    public int CopiasDisponibles { get; set; }
}
