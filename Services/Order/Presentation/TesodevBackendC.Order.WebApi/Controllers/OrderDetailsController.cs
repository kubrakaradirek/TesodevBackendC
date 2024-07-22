using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesodevBackendC.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using TesodevBackendC.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using TesodevBackendC.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace TesodevBackendC.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHadnler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler, UpdateOrderDetailCommandHadnler updateOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(Guid id)
        {
            var values = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş  başarıyla eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok("Sipariş başarıyla silindi.");
        }
    }
}
