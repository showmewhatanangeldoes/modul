using System;

class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
   
}

interface IBuilder
{
    void BuildPartA();
    void BuildPartB();
    Product GetProduct();
}

class ConcreteBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildPartA()
    {
        product.PartA = "PartA";
    }

    public void BuildPartB()
    {
        product.PartB = "PartB";
    }

    public Product GetProduct()
    {
        return product;
    }
}

class Director
{
    private IBuilder builder;

    public Director(IBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct()
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IBuilder builder = new ConcreteBuilder();
        Director director = new Director(builder);

        director.Construct();

        Product product = builder.GetProduct();

        Console.WriteLine("Product Parts: {0} and {1}", product.PartA, product.PartB);
    }
}
