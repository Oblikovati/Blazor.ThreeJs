namespace Blazor.ThreeJs.Components;

public partial class BzScene : ComponentBase
{
    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    [Parameter]
    public bool IsActive { get; set; } = true;

    [Parameter]
    public string Name { get; set; } = "DefaultScene";

    protected override void OnInitialized()
    {
        Parent?.CallbackScenes.Add(this);
    }
}
