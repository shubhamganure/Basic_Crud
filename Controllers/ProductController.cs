using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> productList = new List<Product>()
        {
            new Product { productId = 1, productName = "Product 1", productCategory = "Category 1", productPrice = 10.99f, isProductActive = true },
            new Product { productId = 2, productName = "Product 2", productCategory = "Category 2", productPrice = 19.99f, isProductActive = true },
            new Product { productId = 3, productName = "Product 3", productCategory = "Category 1", productPrice = 5.99f, isProductActive = false },
            new Product { productId = 4, productName = "Product 4", productCategory = "Category 3", productPrice = 15.49f, isProductActive = true }
        };

            
        [HttpGet("getAllProducts")]
        public List<Product> GetAllProducts()
        {
            
            return productList;
        }

        [HttpGet("getProductById/{id}")]
        public Product GetProductById(int id)
        {
            return productList.FirstOrDefault(p => p.productId == id);
        }

        [HttpPost("addProduct")]
        public Product AddProduct(Product obj)
        {
            obj.productId = productList.Count + 1;
            productList.Add(obj);
            return obj;
        }

        [HttpPut("updateProduct/{id}")]
        public Product UpdateProduct(int id, Product obj)
        {
            var product = productList.FirstOrDefault(p => p.productId == id);
            if (product == null)
            {
                return null;
            }
            productList.Remove(product);
            obj.productId = id;
            productList.Add(obj);
            productList.Sort((x, y) => x.productId.CompareTo(y.productId));
            return obj;
        }

        [HttpDelete("deleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            var product = productList.FirstOrDefault(p => p.productId == id);
            if (product == null)
            {
                return false;
            }
            productList.Remove(product);
            return true;
        }
    }
}
