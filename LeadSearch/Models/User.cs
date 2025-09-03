using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LeadSearch.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Por favor, insira um CPF/CNPJ"), Display(Name = "Nome")]
        public string? CpfCnpj { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
