using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.ProductCommands;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductQueries;

namespace TesodevBackendC.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        public ProductsController(GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, DeleteProductCommandHandler deleteProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, CreateProductCommandHandler createProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _createProductCommandHandler = createProductCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductListById(Guid id)
        {
            var values = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok("Ürün bilgisi başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return Ok("Ürün bilgisi başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
            return Ok("Ürün bilgisi başarıyla silindi.");
        }
    }
}
