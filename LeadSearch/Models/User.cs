using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeadSearch.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "O nome é obrigatório"), Display(Name = "Nome")]
        public string? CpfCnpj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
