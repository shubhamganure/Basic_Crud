using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Crud
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceProductController : ControllerBase
    {
        public readonly EmployeeDbContextClass _dbContext;
        public EcommerceProductController(EmployeeDbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("createEcomProduct")]
        public async Task<IActionResult> CreateEcomProduct([FromBody] ProductDetailsViewModel productDetails)
        {
            try
            {
                ProductDetailsModel prodDetails = new ProductDetailsModel()
                {
                    prodId = 0,
                    prodName = productDetails.prodName,
                    categoryName = productDetails.categoryName,
                    mainImage = productDetails.mainImage,
                    shortName = productDetails.shortName
                };
                await _dbContext.ProductDetailsModels.AddAsync(prodDetails);
                await _dbContext.SaveChangesAsync();

                ProductExtraDetailsModel prodExtraDetails = new ProductExtraDetailsModel()
                {
                    prodExtraDetailId = 0,
                    prodId = prodDetails.prodId,
                    description = productDetails.description,
                    discount = productDetails.discount,
                    price = productDetails.price
                };

                await _dbContext.ProductExtraDetailsModels.AddAsync(prodExtraDetails);
                await _dbContext.SaveChangesAsync();
                return Created("Product created successfully.",  prodDetails);

            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding the Ecom Product."); 

            }
        }
    }
}
