using Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.FakeRepositoy;

public class FakeProducts
{
    public static List<Product> Products = new List<Product>()
    {
        new Product()
        {
            Name ="Cola",
            Price="1.4",
            ImageUrl="Images/coca-cola-original-20oz.png"
        },
        new Product()
        {
            Name ="Fanta",
            Price="2.9",
            ImageUrl="Images/fanta-orange_product_image_v2.jpg"
        },
        new Product()
        {
            Name ="Snickers",
            Price="2.0",
            ImageUrl="Images/snickers.jpg"
        },
        new Product()
        {
            Name ="Coffee",
            Price="5.4",
            ImageUrl="Images/nescafe.jpg"

        },
        new Product()
        {
            Name ="Alpen gold",
            Price="3.2",
            ImageUrl="Images/alpengold-sokolad.jpg"
        },
        new Product()
        {
            Name ="M&Ms",
            Price="2.2",
            ImageUrl="Images/mnms.jpg"
        },
    };
}
