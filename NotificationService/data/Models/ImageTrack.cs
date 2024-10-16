using NotificationService.interfaces;

namespace NotificationService.data.Models;

public partial class ImageTrack : Entity
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Url { get; set; } = null!;

    public bool DeleteSoft { get; set; }

    public int ProductId { get; set; }

    public bool CanScan { get; set; } = false;
    public virtual Product Product { get; set; } = null!;
}
