using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.ProductOrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.ProductOrderDetailQueries;

namespace TesodevBackendC.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderDetailsController : ControllerBase
    {
        private readonly GetProductListByOrderDetailIdQueryHandler _getProductListByOrderIdQueryHandler;

        public ProductOrderDetailsController(GetProductListByOrderDetailIdQueryHandler getProductListByOrderIdQueryHandler)
        {
            _getProductListByOrderIdQueryHandler = getProductListByOrderIdQueryHandler;
        }

        [HttpGet("ProductListByOrderDetailId/{id}")]
        public async Task<IActionResult> ProductListByOrderDetailId(Guid id)
        {
            var query = new GetProductListByOrderDetailIdQuery(id);
            var values = await _getProductListByOrderIdQueryHandler.Handle(query);
            return Ok(values);
        }
    }
}
