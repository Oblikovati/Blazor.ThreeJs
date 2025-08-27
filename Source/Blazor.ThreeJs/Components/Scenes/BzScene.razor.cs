namespace Blazor.ThreeJs.Components;

public partial class BzScene : ComponentBase
{
    [Parameter]
    public bool IsActive { get; set; } = true;

    [Parameter]
    public string Name { get; set; } = "DefaultScene";
}
