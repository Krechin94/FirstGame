namespace PizdelovoGame.SavesService.Exceptions
{
    public class PlayerReadException : Exception
    {
        public PlayerReadException(string name) : base($"Неудается загрузить игрока с именем {name}. Произошла ошибка чтения файла сохранения, попробуйте перезаписать данные.") { }
    }
}
