using IT_Academy_CSharp.SideFiles;

namespace IT_Academy_CSharp.Homeworks.Homework5;

public class Book
{
    private string? _title;
    private string? _author;
    private int _pages;

    public string? Title
    {
        get => _title;
        private set => _title = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
    }

    public string? Author
    {
        get => _author;
        private set => _author = !string.IsNullOrWhiteSpace(value) ? value : "Unknown";
    }

    public int Pages
    {
        get => _pages;
        private set => _pages = value >= 0 ? value : 0;
    }

    public Book()
    {
        Title = "Unknown";
        Author = "Unknown";
        Pages = 0;
    }

    public Book(string? title, string? author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }

    public string GetDescription()
    {
        return $"Название: {_title}, Автор: {_author}, Страниц: {_pages}";
    }

    public void PrintDescription(string? bookDescription)
    {
        MyUtilities.PrintGreenColorMessage(bookDescription);
        MyUtilities.PrintSeparationLine('-');
    }
}