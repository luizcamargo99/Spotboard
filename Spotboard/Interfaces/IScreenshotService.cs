namespace Spotboard.Interfaces;

public interface IScreenshotService
{
    Task CreateImageByElement(string elementId, string imageId);
    Task DownloadScreenshot(string elementId, string filename);
}
