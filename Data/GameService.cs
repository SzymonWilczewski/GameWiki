using GameWiki.Data;
using Microsoft.EntityFrameworkCore;

namespace GameWiki.Services
{
    public class GameService : IGameService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public GameService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddGame(Game game)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task<List<Game>> GetGames()
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var games = await context.Games.Include(e => e.Developer).ToListAsync();
            return games;
        }

        public async Task<Game> GetGame(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var game = await context.Games.Include(e => e.Developer).FirstAsync(e => e.Id == id) ?? throw new Exception("Game not found");
            return game;
        }

        public async Task UpdateGame(int id, Game game)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var oldGame = await context.Games.FindAsync(id) ?? throw new Exception("Game not found");

            oldGame.Name = game.Name;
            oldGame.Genre = game.Genre;
            oldGame.ReleaseDate = game.ReleaseDate;
            oldGame.DeveloperId = game.DeveloperId;

            await context.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            using var context = await _dbContextFactory.CreateDbContextAsync();
            var game = await context.Games.FindAsync(id) ?? throw new Exception("Game not found");
            context.Remove(game);
            await context.SaveChangesAsync();
        }
    }
}
