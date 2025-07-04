using IT_Academy_CSharp.Homeworks.Homework13.NewsTypes;

namespace IT_Academy_CSharp.Homeworks.Homework13;

public class Client
{
    public string Name { get; }
    public NewsProvider Provider { get; }
    public List<NewsSections> CurrentSubscribes { get; }

    public readonly int MaxNewsReceivesAmount;

    private int _receivedNewsCount;

    public Client(string name, NewsProvider provider, int receivesAmount)
    {
        Name = name;
        Provider = provider;
        MaxNewsReceivesAmount = receivesAmount;
        CurrentSubscribes = [];
    }

    private void ReceiveNews(string news)
    {
        Console.WriteLine($"{Name} получил новость: {news}");
        if (++_receivedNewsCount < MaxNewsReceivesAmount) return;

        foreach (var section in CurrentSubscribes)
        {
            UnsubscribeFromNewsSection(Provider, section);
        }
    }

    public void SubscribeOnNewsSection(NewsProvider provider, NewsSections newsSection)
    {
        if (CurrentSubscribes.Exists(_ => _ == newsSection))
        {
            Console.WriteLine($"{Name} has already subscribed on the {newsSection} news section.");
            return;
        }

        if (!provider.TrySubscribeClientOnNewsSection(newsSection, ReceiveNews)) return;

        CurrentSubscribes.Add(newsSection);
        Console.WriteLine($"{Name} has subscribed on the {newsSection} news section.");
    }

    public void UnsubscribeFromNewsSection(NewsProvider provider, NewsSections newsSection)
    {
        if (!CurrentSubscribes.Exists(_ => _ == newsSection))
        {
            Console.WriteLine($"{Name} has not subscribed on the {newsSection} news section.");
        }

        if (!provider.TryUnsubscribeClientOnNewsSection(newsSection, ReceiveNews)) return;

        CurrentSubscribes.Remove(newsSection);
        Console.WriteLine($"\n{Name} has unsubscribed from the {newsSection} news section.\n");
    }

    public void ShowCurrentSubscribes()
    {
        var currentSubscribes = CurrentSubscribes.Count;
        if (currentSubscribes == 0)
        {
            Console.WriteLine($"Client {Name} has not subscribed to any news.\n");
            return;
        }

        Console.Write($"Client {Name} has subscribed to: ");

        for (var i = 0; i < currentSubscribes; i++)
        {
            Console.Write(i < currentSubscribes - 1
                ? $"{CurrentSubscribes[i]}, "
                : $"{CurrentSubscribes[i]}"
            );
        }
    }
}