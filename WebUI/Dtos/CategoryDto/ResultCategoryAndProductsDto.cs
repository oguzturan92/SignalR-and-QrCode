using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.CategoryDto
{
    public class ResultCategoryAndProductsDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }
        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public decimal ProductPrice { get; set; }
            public string ProductImage { get; set; }
            public bool ProductStatus { get; set; }
            public int CategoryId { get; set; }
        }
    }
}