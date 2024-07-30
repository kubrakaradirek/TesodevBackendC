using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Reflection.Metadata;
using System.Text;
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
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        private readonly ChangeOrderStatusToFalseCommandHandler _changeOrderStatusToFalseCommandHandler;
        private readonly ChangeOrderStatusToTrueCommandHandler _changeOrderStatusToTrueCommandHandler;
        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, ChangeOrderStatusToFalseCommandHandler changeOrderStatusToFalseCommandHandler, ChangeOrderStatusToTrueCommandHandler changeOrderStatusToTrueCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _changeOrderStatusToFalseCommandHandler = changeOrderStatusToFalseCommandHandler;
            _changeOrderStatusToTrueCommandHandler = changeOrderStatusToTrueCommandHandler;
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
            var orderDetail = await _createOrderDetailCommandHandler.Handle(command);

            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("OrderQ", false, false, false, null);

            var messageContent = $"Yeni sipariş oluşturuldu. Sipariş ID: {orderDetail.Id}";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);
            channel.BasicPublish(exchange: "", routingKey: "OrderQ", basicProperties: null, body: byteMessageContent);

            return Ok("Sipariş başarıyla eklendi ve bildirim mesajı kuyruğa alındı.");
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
        
        [HttpPost("ChangeOrderStatusToFalse/{orderId}")]
        public async Task<IActionResult> ChangeOrderStatusToFalse(Guid orderId)
        {
            var command = new ChangeOrderStatusToFalseCommand
            {
                OrderId = orderId,
                Status = "Sipariş İptal" 
            };

            var result = await _changeOrderStatusToFalseCommandHandler.Handle(command);

            if (result)
            {
                return Ok(new { Message = "Sipariş iptal edildi." });
            }
            else
            {
                return NotFound(new { Message = "Sipariş bulunamadı." });
            }
        }

        [HttpPost("ChangeOrderStatusToTrue/{orderId}")]
        public async Task<IActionResult> ChangeOrderStatusToTrue(Guid orderId)
        {
            var command = new ChangeOrderStatusToTrueCommand
            {
                OrderId = orderId
            };

            var result = await _changeOrderStatusToTrueCommandHandler.Handle(command);

            if (result)
            {
                return Ok(new { Message = "Sipariş aktifleştirildi." });
            }
            else
            {
                return NotFound(new { Message = "Sipariş bulunamadı." });
            }
        }
    }
}
