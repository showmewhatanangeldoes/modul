using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

}

interface IBuilder
{
    void BuildProductName();
    void BuildProductPrice();
    void BuildProductCategory();
    Product GetProduct();
}

class OttoProductBuilder : IBuilder
{
    private Product product = new Product();

    public void BuildProductName()
    {
        product.Name = "Product A";
    }

    public void BuildProductPrice()
    {
        product.Price = 100.00m;
    }

    public void BuildProductCategory()
    {
        product.Category = "Category X";
    }

    public Product GetProduct()
    {
        return product;
    }
}


class ProductDirector
{
    private IBuilder builder;

    public ProductDirector(IBuilder builder)
    {
        this.builder = builder;
    }

    public void ConstructProduct()
    {
        builder.BuildProductName();
        builder.BuildProductPrice();
        builder.BuildProductCategory();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IBuilder builder = new OttoProductBuilder();
        ProductDirector director = new ProductDirector(builder);

        director.ConstructProduct();

        Product product = builder.GetProduct();

        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Category: {product.Category}");
    }
}


