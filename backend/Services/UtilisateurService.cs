using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

namespace backend.Services
{
    public class UtilisateurService
    {
        private readonly ApplicationDbContext _context;

        public UtilisateurService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Utilisateurs>> GetAllAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<Utilisateurs?> GetByIdAsync(int id)
        {
            return await _context.Utilisateurs.FindAsync(id);
        }

        public async Task<Utilisateurs> CreateAsync(Utilisateurs user)
        {
            _context.Utilisateurs.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(int id, Utilisateurs user)
        {
            var existing = await _context.Utilisateurs.FindAsync(id);
            if (existing == null) return false;

            existing.Nom = user.Nom;
            existing.Prenom = user.Prenom;
            existing.Email = user.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Utilisateurs.FindAsync(id);
            if (user == null) return false;

            _context.Utilisateurs.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}