namespace GameWiki.Data
{
    public interface IGameService
    {
        Task AddGame(Game game);
        Task<List<Game>> GetGames();
        Task<Game> GetGame(int id);
        Task UpdateGame(int id,  Game game);
        Task DeleteGame(int id);
    }
}
