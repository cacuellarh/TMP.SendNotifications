using MediatR;
using NotificationService.data.respositories;
using NotificationService.events.eventArgs;
using Serilog;

namespace NotificationService.events.handlers
{
    public class UpdateCurrentPriceScanedHandler : INotificationHandler<UpdateCurrentPriceScanedEvent>
    {
        private readonly IProductRepository productRepository;

        public UpdateCurrentPriceScanedHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(UpdateCurrentPriceScanedEvent notification, CancellationToken cancellationToken)
        {
            try
            { 
                var productDb = notification.ProductDb;
                var currentProduct = notification.CurrentProductScaned;
                productDb.UpdateCurrentPriceScaned(currentProduct.Precio);

                await productRepository.UpdateAsync(productDb);
                Log.Information($"Precio actualizado al producto {productDb.Descripcion}, id: {productDb.Id}");
                Console.WriteLine($"Precio actualizado al producto {productDb.Descripcion}, id: {productDb.Id}");
            
            }catch (Exception ex) 
            {
                Log.Error($"Ocurrio un error al actualizar el precio actual del producto {notification.ProductDb.Descripcion}," +
                    $" detalles: {ex.Message}");
            }
        }
    }
}
