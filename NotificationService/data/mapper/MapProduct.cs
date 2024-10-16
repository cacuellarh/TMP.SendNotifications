using NotificationService.data.Models;
using NotificationService.dto;
using NotificationService.interfaces;
using NanisGuard;
using NanisGuard.src;

namespace NotificationService.data.mapper
{
    public class MapProduct : IMap<ProductDto, Product>
    {
        public Product Map(ProductDto productDto)
        {
            var priceParsed = NanisGuardV.validation.ValidateParseStringToDecimal(productDto.precio!,nameof(productDto.precio));

            return new Product(id: 0,
                descripcion: productDto.descripcion,
                precio: priceParsed,
                descuento: productDto.descuento,
                deleteSoft: false,
                tipoMoneda: productDto.tipoMoneda
                );
        }
    }
}
