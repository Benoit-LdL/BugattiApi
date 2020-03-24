public class Book
{
    public Book()
    {
    }

    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }
    public int Id { get; internal set; }
}