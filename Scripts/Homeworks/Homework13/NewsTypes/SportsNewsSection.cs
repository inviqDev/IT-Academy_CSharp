namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public sealed class SportsNewsSection : NewsBaseModel
{
    private readonly List<string> _sportsNews =
    [
        "Спорт: Национальная сборная одержала победу в отборочном матче.",
        "Спорт: В столице прошёл марафон с участием тысяч спортсменов.",
        "Спорт: Баскетбольная команда выиграла чемпионат страны.",
        "Спорт: Ведущий теннисист объявил о завершении карьеры.",
        "Спорт: Хоккейный клуб назначил нового главного тренера.",
        "Спорт: Завершился этап Кубка мира по биатлону.",
        "Спорт: В городе прошёл турнир по боксу среди юниоров.",
    ];
    
    public SportsNewsSection()
    {
        StartGeneratingNewsArticles(3264);
    }
    
    private protected override void GenerateNewArticle()
    {
        PublishNewArticle(GetRandomNewsArticle(_sportsNews), ConsoleColor.Cyan);
    }
}