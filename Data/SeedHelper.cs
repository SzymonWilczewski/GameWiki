using CsvHelper;
using CsvHelper.Configuration;
using GameWiki.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

public static class SeedHelper
{
    public static void SeedDevelopers(ModelBuilder modelBuilder)
    {
        string filePath = Path.Combine("Data", "SeedData", "developers.csv");
        string fullFilePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";" };
        using var reader = new StreamReader(fullFilePath, Encoding.UTF8);
        using var csvReader = new CsvReader(reader, config);
        var developers = csvReader.GetRecords<Developer>().ToList();

        modelBuilder.Entity<Developer>().HasData(developers);
    }

    public static void SeedGames(ModelBuilder modelBuilder)
    {
        string filePath = Path.Combine("Data", "SeedData", "games.csv");
        string fullFilePath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", HeaderValidated = null, MissingFieldFound = null };
        using var reader = new StreamReader(fullFilePath, Encoding.UTF8);
        using var csvReader = new CsvReader(reader, config);
        var games = csvReader.GetRecords<Game>().ToList();
        foreach (var game in games)
        {
            modelBuilder.Entity<Game>(g => g.HasData(new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                DeveloperId = game.DeveloperId
            }));
        }
    }
}
