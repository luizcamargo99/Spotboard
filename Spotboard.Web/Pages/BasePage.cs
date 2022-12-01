using Microsoft.AspNetCore.Components;

namespace Spotboard.Web.Pages
{
    public class BasePage : ComponentBase
    {
        protected bool IsLoading { get; private set; }

        protected override void OnInitialized()
        {
            IsLoading = true;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                IsLoading = false;
            }
        }
    }
}
