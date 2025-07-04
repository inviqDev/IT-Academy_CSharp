namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public sealed class GameDevNewsSection : NewsBaseModel
{
    private readonly List<string> _gameDevNews =
    [
        "Геймдев: Анонсирован новый инди-платформер с уникальной механикой.",
        "Геймдев: CD Project выпустила бесплатное обновление для Cyberpunk.",
        "Геймдев: Вышла демоверсия ожидаемого The Witcher 4.",
        "Геймдев: Известный блогер протестировал игровой движок GODOT.",
        "Геймдев: Открыт набор участников на международный геймджем.",
        "Геймдев: Ведущий разработчик рассказал о переходе на Unity Engine.",
        "Геймдев: Игроки нашли пасхалку в недавнем обновлении.",
        "Геймдев: Команда разработчиков поделилась планами на следующий год."
    ];

    public GameDevNewsSection()
    {
        StartGeneratingNewsArticles(2087);
    }

    private protected override void GenerateNewArticle()
    {
        PublishNewArticle(GetRandomNewsArticle(_gameDevNews), ConsoleColor.Magenta);
    }
}