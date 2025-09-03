using Blazor.ThreeJs.Components.Cameras;
using Blazor.ThreeJs.Exceptions;

namespace Blazor.ThreeJs.Components;

public partial class BzRenderer : ComponentBase
{
    private readonly THREE _t;

    public BzRenderer(THREE t)
    {
        _t = t;
    }
    #region Parameters
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
    #endregion

    #region Internal Properties
    internal List<BzCamera> CallbackCameras { get; set; } = [];
    internal List<BzMaterial> CallbackMaterials { get; set; } = [];
    internal List<BzScene> CallbackScenes { get; set; } = [];
    internal List<BzCanvas> CallbackViews { get; set; } = [];
    #endregion

    protected override void OnAfterRender(bool firstRender)
    {
        if(firstRender)
        {
            if (CallbackViews.Count == 0)
                throw new InvalidViewConfigurationException("No canvas was provided to the Renderer");

            if (CallbackCameras.Count == 0)
            {
                Console.WriteLine("No Camera was found, defining a default Perspective Camera");
                CallbackCameras.Add(new BzPerspectiveCamera(_t));
            }


        }

    }
}
