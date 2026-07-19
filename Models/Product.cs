using System;

namespace Basic_Crud
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public string productCategory { get; set; } = string.Empty;
        public float productPrice { get; set; }
        public bool isProductActive { get; set; }

    }
}
