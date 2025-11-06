using Microsoft.EntityFrameworkCore;
using nerdier.Data;
using nerdier.Interface;
using nerdier.Model;

namespace nerdier.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;
        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }   

        public async Task <List<Player>> GetAllPlayers()
        {
            return await _context.Player.ToListAsync();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Player.Where(p => p.Id == id).FirstOrDefaultAsync();  
        }

        public async Task<bool> PlayerExists(string name)
        {
           return await _context.Player.AnyAsync(p => p.Nome.ToLower().Trim() == name.ToLower().Trim());
        }

        public async Task<Player> AddPlayer(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<bool> DeletePlayer(Player player)
        {
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Player> UpdatePlayer(Player player)
        {
           _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;
        }
    }
}
