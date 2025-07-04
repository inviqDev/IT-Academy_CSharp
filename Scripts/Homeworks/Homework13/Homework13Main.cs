using static IT_Academy_CSharp.Homeworks.Homework13.NewsTypes.NewsSections;

namespace IT_Academy_CSharp.Homeworks.Homework13;

public static class Homework13Main
{
    public static void RunHomework13()
    {
        var provider = new NewsProvider();

        var kolya = new Client("Коля", provider, 14);
        var igor = new Client("Игорь", provider, 11);
        var denis = new Client("Денис", provider,8);
        var sasha = new Client("Саша", provider, 6);
        var semen = new Client("Семён", provider, 3);

        kolya.SubscribeOnNewsSection(provider, Politics);
        igor.SubscribeOnNewsSection(provider, Business);
        denis.SubscribeOnNewsSection(provider, GameDev);
        sasha.SubscribeOnNewsSection(provider, Crypto);
        semen.SubscribeOnNewsSection(provider, Sport);
    }
}