const int numberOfBooks = 100;
var bookPages = GetCollectionOfBooks(numberOfBooks);

var pagesInThickestBook = bookPages.Max();

Console.WriteLine($"\nThe thickest book contains {pagesInThickestBook} pages.");

static int[] GetCollectionOfBooks(int count)
{
    var bookPages = new int[count];
    var random = new Random();

    for (int i = 0; i < count; i++)
    {
        bookPages[i] = random.Next(1, 999);
    }

    return bookPages;
}