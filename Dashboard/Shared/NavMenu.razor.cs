using Dashboard.Data;
using Microsoft.AspNetCore.Components;

namespace Dashboard.Shared;

public partial class NavMenu
{
    [Inject]
    public ApplicationsService ApplicationsService { get; set; }
    
    private List<Application>? applications;
    
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    protected override async Task OnInitializedAsync()
    {
        applications = await ApplicationsService.GetApplicationsAsync();
    }
}