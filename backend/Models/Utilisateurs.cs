using System.ComponentModel.DataAnnotations;
namespace backend.Models;

public class Utilisateurs
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nom { get; set; }

    [Required]
    [StringLength(100)]
    public string Prenom { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}