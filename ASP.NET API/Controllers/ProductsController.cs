using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST_API
{
    // http:localhost:5154/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //ПОЛУЧИТЬ ПО АЙДИ ПРОДУКТ
        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _context.products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                return Ok(product);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        // ПОЛУЧИТЬ ВСЕ ПРОДУКТЫ
        // GET: api/products
        // ЗДЕСЬ АРГУМЕНТ title ПОЛУЧАЕТСЯ ИЗ ЗАПРОСА В ФИЛЬТРАЦИИ api/products?title=someOfProductName
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string? title,
            [FromQuery] int? id,
            [FromQuery] int? price
        )
        {
            try
            {
                // Изначально создаём базовый запрос
                var query = _context.products.AsQueryable();

                // Применяем фильтры только при наличии параметров
                if (!string.IsNullOrEmpty(title))
                {
                    query = query.Where(p => p.title.ToLower().Contains(title.ToLower()));
                }

                if (id.HasValue)
                {
                    query = query.Where(p => p.id == id.Value);
                }

                if (price.HasValue)
                {
                    query = query.Where(p => p.price == price.Value);
                }

                // Выполняем запрос и возвращаем результат
                var products = await query.ToListAsync();
                if (!products.Any())
                {
                    // Если список пустой
                    return NotFound("No products found.");
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                // Логируем ошибку и возвращаем статус 500
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return StatusCode(500, "An error occurred while fetching products.");
            }
        }

        // ДОБАВИТЬ ПРОДУКТ
        // POST: ap/products
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            try
            {
                var _product = _context.products.FirstOrDefault(p => p.title == product.title);
                if (_product != null)
                {
                    return BadRequest("This product already exist.");
                }

                _context.products.Add(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        //ОБНОВИТЬ ПО АЙДИ ПРОДУКТ
        // PUT: api/products/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (id < 0)
                {
                    throw new Exception("Wrong id");
                }

                if (product == null)
                {
                    throw new Exception("Product is null");
                }

                var _product = await _context.products.FindAsync(id);

                if (_product == null)
                {
                    throw new Exception("Product not found");
                }

                _product.title = product.title;
                _product.price = product.price;
                _product.img = product.img;

                await _context.SaveChangesAsync();
                return Ok(_product);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }

        //УДАЛИТЬ ПО АЙДИ ПРОДУКТ
        // DELETE: api/products/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception Error)
            {
                return BadRequest(Error.Message);
            }
        }
    }
}
