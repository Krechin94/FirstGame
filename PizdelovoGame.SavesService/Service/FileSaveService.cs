using PizdelovoGame.SavesService.Exceptions;
using PizdelovoGame.SavesService.Model;
using System.Text.Json;
using System.Xml.Linq;

namespace PizdelovoGame.SavesService.Service
{
    public class FileSaveService
    {
        private static string _pathToGameData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".pizdelovo-game");
        private static string _pathSave = Path.Combine(_pathToGameData, "saves");

        public FileSaveService() 
        {
            Directory.CreateDirectory(_pathSave);
        }

        public async Task Save(PlayerDto player)
        {
            var saveFileName = $"{_pathSave}/{player.Name}.json";
            try
            {
                using (var serializedPerson = new MemoryStream())
                {
                    await JsonSerializer.SerializeAsync(serializedPerson, player);

                    using (var file = File.Open(saveFileName, FileMode.OpenOrCreate))
                    {
                        await file.WriteAsync(serializedPerson.ToArray());
                    }
                }
            }
            catch (NotSupportedException nse)
            {
                //_logger.LogError(nse, nse.Message);
                throw new PlayerNotCreatedException(player.Name);
            }
        }

        public async Task<PlayerDto> Download(string name)
        {
            var saveFileName = $"{_pathSave}/{name}.json";
            if (File.Exists(saveFileName))
            {
                var savedPlayer = File.OpenRead(saveFileName);
                //_logger.Log(LogLevel.Information, $"Игрок {name} успешно загружен. Сериализую ...");
                return await JsonSerializer.DeserializeAsync<PlayerDto>(savedPlayer) ??
                    throw new PlayerReadException(name);
            }
            else
                throw new NoSuchPlayerException(name);
        }
    }
}
