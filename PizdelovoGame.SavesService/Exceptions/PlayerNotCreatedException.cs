namespace PizdelovoGame.SavesService.Exceptions
{
    public class PlayerNotCreatedException : Exception
    {
        public PlayerNotCreatedException(string name) : base($"Игрок {name} не был создан, проверьте правильность отправляемых данных.") { }
    }
}
