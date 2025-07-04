namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public sealed class BusinessNewsSection : NewsBaseModel
{
    private readonly List<string> _businessNews =
    [
        "Бизнес: Ведущая компания объявила о слиянии с конкурентом.",
        "Бизнес: Центральный банк снизил ключевую ставку.",
        "Бизнес: Опубликован рейтинг самых прибыльных компаний года.",
        "Бизнес: Инвесторы прогнозируют рост экономики во втором квартале.",
        "Бизнес: Объявлено о запуске уникального онлайн-сервиса.",
        "Бизнес: Президент компании рассказал о стратегии развития.",
        "Бизнес: На рынке недвижимости зафиксирован рост цен.",
        "Бизнес: Проведена международная бизнес-конференция.",
    ];
    
    public BusinessNewsSection()
    {
        StartGeneratingNewsArticles(1734);
    }

    private protected override void GenerateNewArticle()
    {
        PublishNewArticle(GetRandomNewsArticle(_businessNews), ConsoleColor.Green);
    }
}