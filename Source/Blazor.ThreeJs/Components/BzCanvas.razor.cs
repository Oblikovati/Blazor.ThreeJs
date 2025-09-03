namespace Blazor.ThreeJs.Components;

public partial class BzCanvas : ComponentBase
{
    private ElementReference _canvas;

    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    [Parameter]
    public ElementReference ExternalCanvasReference { protected get => _canvas; set => _canvas = value; }

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

    public ElementReference CanvasReference => _canvas;


    protected override void OnInitialized()
    {
        Parent?.CallbackViews.Add(this);
    }
}
