using Microsoft.AspNetCore.Components;

namespace BlazorOkta.Shared
{
    public partial class RedirectToLogin
    {
        [Inject] public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var returnUrl = Navigation.ToBaseRelativePath(Navigation.Uri);

            Navigation.NavigateTo($"Login?returnUrl={returnUrl}", true);
        }
    }
}

