namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public sealed class PoliticsNewsSection : NewsBaseModel
{
    private readonly List<string> _politicsNews =
    [
        "Политика: В столице прошла встреча лидеров оппозиции и правящей партии.",
        "Политика: Принят новый закон о поддержке малого бизнеса.",
        "Политика: Президент выступил с ежегодным обращением к нации.",
        "Политика: В парламенте обсуждают повышение минимальной зарплаты.",
        "Политика: Проведена пресс-конференция по вопросам экологии.",
        "Политика: Прошли переговоры по вопросам национальной безопасности.",
        "Политика: Правительство объявило о введении новых налоговых льгот.",
    ];

    public PoliticsNewsSection()
    {
        StartGeneratingNewsArticles(1241);
    }

    private protected override void GenerateNewArticle()
    {
        PublishNewArticle(GetRandomNewsArticle(_politicsNews), ConsoleColor.Red);
    }
}