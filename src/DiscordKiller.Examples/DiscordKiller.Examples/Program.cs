record Author(string FirstName, string LastName, string? Patronymic = null);

public abstract class BaseCar : IBus
{
    public virtual void Move()
    {
    }

    public int SeatCount { get; }
}

public interface ICar
{
    public void Move();
}

public interface IBus
{
    public int SeatCount { get; }
}


public class Ferriry : BaseCar, IBus
{
    public void Move()
    {
        
    }

    public int SeatCount { get; }
}


internal class Program
{
    static void Inc(ref int x)
    {
        x = x + 1;
    }
    static void SetOtherName(Book book, out string newName)
    {
        newName = "Страуструп";
        book.Author = newName;
    }

    public delegate int Operation(int x, int y);

    public static int Foo(int a, int b, Operation operation)
    {
        var result = operation(a, b);
        return result;
    }

    public static int Sum(int a, int b)
    {
        return a + b;
    }

    public static void Print<T>(T obj)
    {
        Console.WriteLine(obj);
    }

    public void MoveCar(ICar car)
    {
        car.Move();
    }

    public static void Main(string[] args)
    {
        // var i = 0;
        // Console.WriteLine(i); // 0
        // Inc(ref i);
        // Console.WriteLine(i); // 0
        //
        //
        // var b = new Book();
        // b.Name = "DDD";
        // b.Author = "Вернон";
        // Console.WriteLine(b.GetFormatName()); 
        //
        // SetOtherName(b, out var newName);
        // Console.WriteLine(b.GetFormatName()); 
        // Console.WriteLine(newName);
        //
        // var vernon = new Author("Vernon", "Vaughn");
        // (var firstName, var lastName, string? patronymic) = vernon;
        // Console.WriteLine(vernon);
        //
        // var vernon2 = vernon with { Patronymic = "patronymic" };
        // Console.WriteLine(vernon2);

        var a = 1;
        var b = 10;

        var result = Foo(a, b, Sum);
        Console.WriteLine(result);
        
        result = Foo(a, b, (i, j) => (int)Math.Pow(i, j));
        Console.WriteLine(result);

        IBus f = new Ferriry();
        
    }
}

// var c = new Book();
// Console.WriteLine(c.Id); // 2
//
// Book.NextId();
// Console.WriteLine(b.Name); // Null
//

// Console.WriteLine(b.Name); // DDD 
//
// b.Author = "";
// Console.WriteLine(b.Author); // Null || AAA
//

// Console.WriteLine(b.Author); // Вернон
//
// b.Author = "";
// Console.WriteLine(b.Author); // Вернон
//
// Console.WriteLine(Book.StaticName);
// Book.StaticName = "";
// Console.WriteLine(Book.StaticName);
// Console.WriteLine(Book.StaticAuthor);
//
//
// Console.WriteLine("////");
// b.Sell();
// b.Sell();

public class Book
{
    public static string StaticName = "FFF";
    public static string StaticAuthor { get; private set; } = "Вернон";

    public int Id { get; private set; }
    
    
    public string Name; // Поле

    private string _author = "AAA";
    internal string Author {
        get
        {
            Console.WriteLine($"Getter Author: {_author}");
            return _author;
        }
        set
        {
            Console.WriteLine($"Setter Author: {value}");
            if (!string.IsNullOrWhiteSpace(value))
            {
                _author = value;
                Console.WriteLine($"Seted Author: {value}");
            }
        }
    } // Свойство

    private bool _isSold = false;
    public void Sell()
    {
        if (_isSold)
        {
            Console.WriteLine("Книга уже продана");
        }
        else
        {
            _isSold = true;    
        }
    }

    private static int _currentId;
    public static int NextId()
    {
        return ++_currentId;
    }

    public Book()
    {
        Id = NextId();
    }
}


public static class BookExtensions
{
    public static string GetFormatName(this Book book)
    {
        return $"Id: {book.Id} | Автор: {book.Author} \tНазвание книги: {book.Name}";
    }
}
