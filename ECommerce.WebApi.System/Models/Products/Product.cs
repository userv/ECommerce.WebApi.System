﻿using ECommerce.WebApi.System.Models.Categories;

namespace ECommerce.WebApi.System.Models.Products
{
    public class Product : BaseModel<int>
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
    }
}
