using System;
using System.Collections.Generic;

namespace SportShopAPI.Models;

public partial class Manufacture
{
    public int IdManufacture { get; set; }

    public string Country { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
