using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models;

public class Product
{
    public string? Name { get; set; }
    public string? Price { get; set; }
    public int Count { get; set; } = 0;
    public string? ImageUrl { get; set; }

    public override string ToString()
    {
        return $@"{Name} -- {Price} -- {Count}";
    }
}
