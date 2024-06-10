﻿namespace Shop.Core.Models;

public class Product
{

    private static int Count = 1;
    static Product()
    {
        Count = 1;
    }
    public Product(string Name, double costPrice, double salePrice)
    {
        Count++;
        Id = Count;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public double CostPrice { get; set; }
    public double SalePrice { get; set; }




}
