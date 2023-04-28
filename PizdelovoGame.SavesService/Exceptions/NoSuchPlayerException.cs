namespace PizdelovoGame.SavesService.Exceptions
{
    public class NoSuchPlayerException : Exception
    {
        public NoSuchPlayerException(string name) : base($"Игрок с именем {name} не был найден. Попробуйте еще раз и убедитесь что такой игрок существует, " +
            $"либо создайте нового, используя  PUT запрос на /{nameof(SavesService.Controllers.SaveController.Player)}") { }
    }
}
