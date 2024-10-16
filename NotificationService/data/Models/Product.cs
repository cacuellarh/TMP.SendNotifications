using NotificationService.interfaces;

namespace NotificationService.data.Models;

public partial class Product : Entity
{
    public Product(int id, string? descripcion, decimal precio, string? descuento, bool deleteSoft, string? tipoMoneda)
    {
        Id = id;
        Descripcion = descripcion;
        Precio = precio;
        Descuento = descuento;
        DeleteSoft = deleteSoft;
        TipoMoneda = tipoMoneda;
    }
    public int Id { get; private set; }
    public string? Descripcion { get; private set; }
    public decimal Precio { get; private set; }
    public decimal PrecioActualEscaneado { get; private set; }
    public string? Descuento { get; private set; }
    public bool DeleteSoft { get; private set; }
    public string? TipoMoneda { get; private set; }
    public virtual ICollection<ImageTrack> ImageTracks { get; set; } = new List<ImageTrack>();

    public void UpdateCurrentPriceScaned(decimal currentProduct)
    {
        PrecioActualEscaneado = currentProduct;
    }
}
