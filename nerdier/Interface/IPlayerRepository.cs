using nerdier.Model;

namespace nerdier.Interface
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllPlayers();
        Task<Player> GetPlayerById(int id);
        Task<bool> PlayerExists(string name);  
        Task<Player> AddPlayer(Player player);
        Task<Player> UpdatePlayer(Player player);
        Task<bool> DeletePlayer(Player player);
    }
}
