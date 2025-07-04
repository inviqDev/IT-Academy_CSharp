namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public sealed class CryptoNewsSection : NewsBaseModel
{
    private readonly List<string> _cryptoNews =
    [
        "Крипто: Биткоин преодолел отметку в 120 000 $.",
        "Крипто: Ведущая биржа объявила о запуске нового токена.",
        "Крипто: Ethereum обновился до новой версии протокола.",
        "Крипто: Хакеры атаковали крупный DeFi-проект.",
        "Крипто: Курс Dogecoin резко вырос за сутки.",
        "Крипто: Крупный инвестор приобрёл биткоинов на 100 млн долларов.",
        "Крипто: Аналитики прогнозируют рост рынка альткоинов."
    ];
    
    public CryptoNewsSection()
    {
        StartGeneratingNewsArticles(2528);
    }

    private protected override void GenerateNewArticle()
    {
        PublishNewArticle(GetRandomNewsArticle(_cryptoNews), ConsoleColor.Yellow);
    }
}