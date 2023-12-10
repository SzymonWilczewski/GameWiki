namespace GameWiki.Data
{
    public interface IDeveloperService
    {
        Task AddDeveloper(Developer developer);
        Task<List<Developer>> GetDevelopers();
        Task<Developer> GetDeveloper(int id);
        Task UpdateDeveloper(int id, Developer developer);
        Task DeleteDeveloper(int id);
    }
}
