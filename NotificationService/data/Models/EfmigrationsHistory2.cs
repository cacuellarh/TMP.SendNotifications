using System;
using System.Collections.Generic;

namespace NotificationService.data.Models;

public partial class EfmigrationsHistory2
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
