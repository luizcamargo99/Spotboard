using Microsoft.JSInterop;
using Spotboard.Shared.Interfaces;

namespace Spotboard.Shared.Services;

public class ScreenshotService : IScreenshotService
{
    private readonly IJSRuntime _jsRuntime;
    public ScreenshotService(IJSRuntime jsRuntime) 
    { 
        _jsRuntime = jsRuntime;
    }

    public async Task CreateImageByElement(string elementId, string imageId)
    {
        await _jsRuntime.InvokeVoidAsync("createImageByElement", elementId, imageId);
    }

    public async Task DownloadScreenshot(string elementId, string filename)
    {
        await _jsRuntime.InvokeVoidAsync("downloadScreenshot", elementId, filename);
    }
}
