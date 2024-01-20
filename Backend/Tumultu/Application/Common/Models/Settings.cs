namespace Tumultu.Application.Common.Models;

internal class Settings
{
    internal Common Common { get; set; } = new();
}

internal class Common
{
    internal int MaximumFileSize { get; set; } = -1;
    internal int MinimumFileSize { get; set; } = -1;
    internal int MaximumFileNameLength { get; set; } = -1;
}
