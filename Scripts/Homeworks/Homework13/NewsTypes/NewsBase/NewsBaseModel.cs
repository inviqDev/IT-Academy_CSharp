using Timer = System.Timers.Timer;

namespace IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

public abstract class NewsBaseModel
{
    public delegate void NewsEventHandler(string news);
    public event NewsEventHandler? OnNewsRelease;

    private Timer? _timer;
    private Random NewsBaseRandom { get; } = new();

    protected void PublishNewArticle(string articleContext, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        OnNewsRelease?.Invoke(articleContext);
    }

    private protected abstract void GenerateNewArticle();

    private protected void StartGeneratingNewsArticles(int releasingInterval)
    {
        _timer = new Timer(releasingInterval);
        _timer.Elapsed += (sender, args) => GenerateNewArticle();
        _timer.Start();
    }

    protected string GetRandomNewsArticle(List<string> articles) => articles[NewsBaseRandom.Next(0, articles.Count)];
}