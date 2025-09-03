using Blazor.ThreeJs.Exceptions;

namespace Blazor.ThreeJs.Components;

public partial class BzCanvas : ComponentBase
{
    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    [Parameter]
    public ElementReference? CanvasReference { get; set; }

    [Parameter]
    public int Width { get; set; } = 300;

    [Parameter]
    public int Height { get; set; } = 300;

    [Parameter]
    public string Style { get; set; } = "";

    [Parameter]
    public bool FullScreen { get; set; } = false;

    [Parameter]
    public bool ExternalCanvas { get; set; } = false;

    protected override void OnInitialized()
    {
        if (ExternalCanvas && !CanvasReference.HasValue)
            throw new InvalidViewConfigurationException("A canvas was marked as External but no CanvasReference was provided!");

        Parent?.CallbackViews.Add(this);
    }
}
