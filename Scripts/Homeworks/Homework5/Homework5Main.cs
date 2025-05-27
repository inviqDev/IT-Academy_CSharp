namespace IT_Academy_CSharp.Homework5;

/*          #дз5
 * 1. Создайте класс Book:
   У класса должно быть три поля:
   - string Title — название книги.
   - string Author — автор книги.
   - int Pages — количество страниц.
 * 2. Реализуйте свойства для доступа к этим полям (с использованием get и set).
 * 3. Реализуйте конструктор по умолчанию, который устанавливает значения "Unknown" для Title и Author и Pages = 0.
 * 4. Реализуйте перегруженный конструктор, который принимает параметры для инициализации всех полей.
 * 5. Добавьте метод GetDescription, который возвращает строку: “Название: <Title>, Автор: <Author>, Страниц: <Pages>”
 */

public static class Homework5Main
{
    public static void RunHomework5()
    {
        var firstBook = new Book();
        // В ДЗ сказано создать метод, который просто возвращает строку
        var bookDescription = firstBook.GetDescription();
        // Решил также добавить отдельный метод для вывода описания в консоль
        firstBook.PrintDescription(bookDescription);

        var secondBook = new Book("The Art of Game Design", "Jesse Schell", 733);
        bookDescription = secondBook.GetDescription();
        secondBook.PrintDescription(bookDescription);

        string? brokenBookTitle = null;
        var brokenBookAuthor = string.Empty;
        var brokenBookPages = -733;
        var brokenBook = new Book(brokenBookTitle, brokenBookAuthor, brokenBookPages);
        bookDescription = brokenBook.GetDescription();
        brokenBook.PrintDescription(bookDescription);
    }
}