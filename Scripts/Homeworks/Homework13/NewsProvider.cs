using IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;
using static IT_Academy_CSharp.Homeworks.Homework13.NewsTypes.NewsSections;

namespace IT_Academy_CSharp.Homeworks.Homework13;



public class NewsProvider
{
    private readonly Dictionary<NewsSections, NewsBaseModel> _sections = new();

    public NewsProvider()
    {
        _sections[Business] = new BusinessNewsSection();
        _sections[Politics] = new PoliticsNewsSection();
        _sections[Sport] = new SportsNewsSection();
        _sections[GameDev] = new GameDevNewsSection();
        _sections[Crypto] = new CryptoNewsSection();
    }

    public bool TrySubscribeClientOnNewsSection(NewsSections newsSection, NewsBaseModel.NewsEventHandler handler)
    {
        if (!_sections.TryGetValue(newsSection, out var section))
        {
            Console.WriteLine($"The section {newsSection} doesn't exist.");
            return false;
        }
        
        section.OnNewsRelease += handler;
        return true;
    }

    public bool TryUnsubscribeClientOnNewsSection(NewsSections newsSection, NewsBaseModel.NewsEventHandler handler)
    {
        if (!_sections.TryGetValue(newsSection, out var section))
        {
            Console.WriteLine($"The section {newsSection} doesn't exist.");
            return false;
        }
        
        section.OnNewsRelease -= handler;
        return true;
    }
}