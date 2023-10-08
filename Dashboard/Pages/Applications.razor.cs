using Dashboard.Data;
using Microsoft.AspNetCore.Components;

namespace Dashboard.Pages;

public partial class Applications
{
    [Parameter]
    public string? Name { get; set; }
    
    [Inject]
    public ApplicationsService ApplicationsService { get; set; }
    
    private string? applicationUrl;

    protected override async Task OnInitializedAsync()
    {
        applicationUrl = await ApplicationsService.GetApplicationUrl(Name);
    }

    protected override async void OnParametersSet()
    {
        applicationUrl = await ApplicationsService.GetApplicationUrl(Name);
    }
}