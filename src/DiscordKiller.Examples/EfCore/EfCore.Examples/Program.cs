using Microsoft.EntityFrameworkCore;

namespace EfCore.Examples;

internal class Program
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }


        public override string ToString()
        {
            return $"{Id}. {Name} | {Price}";
        }
    }

    private static Article GetById(int id)
    {
        var appDB12 = new ApplicationDBContext();
        var secondArticle = appDB12.Articles.First(x => x.Id == 2);
        return secondArticle;
    }
    
    public static void Main(string[] args)
    {
        // var ints = new List<int>() {1, 2, 3, 6, 4 ,5};
        // ints.Average();
        //
        // var products = Enumerable.Range(0, 10).Select(x => new Product()
        // {
        //     Id = x,
        //     Name = $"Product {x}",
        //     Price = x * Random.Shared.Next(0, 1000)
        // }).ToList();
        //
        // var products1 = products.Where(x => x.Price > 3000).ToList();
        // products1.ForEach(Console.WriteLine);
        //
        // Console.WriteLine(products.MaxBy(x => x.Price));
        // Console.WriteLine(products.Average(x => x.Price));
        // Console.WriteLine(products.MinBy(x => x.Price));
        //
        // Console.WriteLine("До");
        // products.ForEach(Console.WriteLine);
        // products.ForEach(x => x.Price /= 2);
        // Console.WriteLine("После");
        // products.ForEach(Console.WriteLine);
        //
        // var productsName = new List<string>();
        // productsName = products.Select(x => x.Name).ToList();
        //
        // // foreach (var product in products)
        // // {
        // //     productsName.Add(product.Name);
        // // }
        // productsName.ForEach(Console.WriteLine);
        var appDB = new ApplicationDBContext();
        // Добавление
        // var article = new Article()
        // {
        //     Author = "Rick-Anderson",
        //     Title = "Начало работы с EF Core"
        // };
        // appDB.Articles.Add(article);
        // appDB.SaveChanges();

        // var articles = appDB.Articles.ToList();
        // foreach (var article in articles)
        // {
        //     Console.WriteLine($"{article.Id} | Title: {article.Title} | Author: {article.Author}");
        // }

        var secondArticle = GetById(2);
        // appDB.Articles.Find(2);
        secondArticle.Title = "Необходимые компоненты2";
        appDB.SaveChangesAsync();
    }
}