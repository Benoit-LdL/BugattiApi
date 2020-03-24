using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[Route("api/v1/books")]
public class BookController : Controller
{
    //this action is accessible via the url (route): http://localhost:44335/hi

    [HttpGet]
    public List<Book> GetBooks()
    {
        var list = new List<Book>();
        list.Add(new Book()
        {
            Id = 1,
            Title = "test2",
            ISBN = "33-44",
            Author = "noix"
        });

        list.Add(new Book()
        {
            Id = 2,
            Title = "test",
            ISBN = "11-22",
            Author = "ben"
        });
        return list;
    }

    [Route("{id}")]
    [HttpGet]
    public Book GetBook(int id) //should come from list but test data for now
    {
        if (id == 14)
        {
            return new Book()
            {
                Id = 14,
                Title = "katorz",
                ISBN = "14",
                Author = "Albert 1"
            };
        }
        else
            return new Book()
            {
                Id = 4,
                Title = "test3",
                ISBN = "33-44",
                Author = "noix"
            };
    }
    [Route("{id}")]
    [HttpDelete]
    public IActionResult DeleteBook(int id)
    {
        // book verwijderen
        return NoContent();
    }
    [HttpPost]
    public IActionResult CreateBook([FromBody] Book newBook)
    {
        newBook.Id = 3;
        return Created("",newBook);
    }
}