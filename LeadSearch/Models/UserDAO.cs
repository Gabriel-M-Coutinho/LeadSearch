using LeadSearch.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeadSearch.Models
{
    public class UserDAO
    {
        // UserManager ao invés de Context?

        private readonly UserManager<User> _userManager;
        public UserDAO(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Criar usuário
        public async Task<IdentityResult> CreateAsync(User user, string password)
        {
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        // Buscar usuário por Id
        public async Task<User?> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        // Buscar todos os usuários
        public async Task<List<User>> GetAllAsync()
        {
            var users = await Task.FromResult(_userManager.Users.ToList());
            return users;
        }

        // Atualizar um usuário
        public async Task<IdentityResult> UpdateAsync(User user)
        {
            var userExists = await _userManager.FindByIdAsync(user.Id);
            if (userExists == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Usuário não encontrado."
                });
            }

            userExists.UserName = user.UserName;
            userExists.CpfCnpj = user.CpfCnpj;
            userExists.Email = user.Email;
            userExists.UpdatedAt = DateTime.UtcNow;

            return await _userManager.UpdateAsync(userExists);
        }

        // Deletar usuário
        public async Task<IdentityResult> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError
                {
                    Description = "Usuário não encontrado."
                });
            }

            return await _userManager.DeleteAsync(user);
        }
    }
}