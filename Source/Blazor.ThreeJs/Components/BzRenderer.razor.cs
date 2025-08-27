namespace Blazor.ThreeJs.Components;

public partial class BzRenderer : ComponentBase
{
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Cameras { get; set; }

    [Parameter]
    [Category("Behavior")]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Materials { get; set; }

    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Scenes { get; set; }

    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Views { get; set; }
}
