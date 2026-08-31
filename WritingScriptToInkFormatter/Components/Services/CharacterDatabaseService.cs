using System;
using System.Text.Json;


namespace WritingScriptToInkFormatter.Components.Services
{
    public class CharacterDatabaseService
    {
        private readonly string _dataPath;

        public CharacterDatabaseService(IWebHostEnvironment env)
        {
            _dataPath = Path.Combine(env.ContentRootPath, "Data", "testCharacters.json");  // replace testCharacters with an input path field later
        }

        public async Task<CharacterDatabase> LoadAsync()
        {
            if (!File.Exists(_dataPath))
                return new CharacterDatabase();

            var json = await File.ReadAllTextAsync(_dataPath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<CharacterDatabase>(json, options) ?? new CharacterDatabase();
        }
    }
}


