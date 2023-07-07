using System;
using System.Collections.Generic;

namespace SportShopAPI.Models;

public partial class TypeProduct
{
    public int IdTypeProduct { get; set; }

    public string NameType { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
