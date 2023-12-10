using GameWiki.Data;
using Microsoft.EntityFrameworkCore;

namespace GameWiki.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public DeveloperService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task AddDeveloper(Developer developer)
        {
            using var context = _dbContextFactory.CreateDbContext();
            context.Developers.Add(developer);
            await context.SaveChangesAsync();
        }

        public async Task<List<Developer>> GetDevelopers()
        {
            using var context = _dbContextFactory.CreateDbContext();
            var developers = await context.Developers.ToListAsync();
            return developers;
        }

        public async Task<Developer> GetDeveloper(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var developer = await context.Developers.FindAsync(id) ?? throw new Exception("Developer not found");
            return developer;
        }

        public async Task UpdateDeveloper(int id, Developer developer)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var oldDeveloper = await context.Developers.FindAsync(id) ?? throw new Exception("Developer not found");

            oldDeveloper.Name = developer.Name;
            oldDeveloper.City = developer.City;
            oldDeveloper.Country = developer.Country;

            await context.SaveChangesAsync();
        }

        public async Task DeleteDeveloper(int id)
        {
            using var context = _dbContextFactory.CreateDbContext();
            var developer = await context.Developers.FindAsync(id) ?? throw new Exception("Developer not found");
            context.Developers.Remove(developer);
            await context.SaveChangesAsync();
        }
    }
}
