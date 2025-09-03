using Blazor.ThreeJs.Components.Cameras;
using Blazor.ThreeJs.Exceptions;
using Blazor.ThreeJs.Renderer.WebGLRenderer;

namespace Blazor.ThreeJs.Components;

public partial class BzRenderer(THREE THREE, BlazorJSRuntime JS) 
    : ComponentBase
{
    #region Parameters
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Cameras { get; set; }

    /// <summary>
    /// Not Used
    /// </summary>
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Holds all the Scene Components
    /// </summary>
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Scenes { get; set; }

    /// <summary>
    /// Holds all the View Canvas
    /// </summary>
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Views { get; set; }
    #endregion

    #region Internal Properties
    internal List<BzCamera> CallbackCameras { get; set; } = [];
    internal List<BzScene> CallbackScenes { get; set; } = [];
    internal List<BzCanvas> CallbackViews { get; set; } = [];
    internal BzScene? ActiveScene => CallbackScenes.FirstOrDefault(s => s.IsActive);
    internal BzCamera? ActiveCamera => CallbackCameras.FirstOrDefault(c => c.IsActive);
    #endregion

    #region Private Variables
    private Window? _window;
    private Document? _document;
    private WebGLRenderer? _renderer;
    #endregion

    protected override void OnAfterRender(bool firstRender)
    {
        if(firstRender)
        {
            if (CallbackScenes.Count == 0)
                throw new UndefinedSceneException();

            if (CallbackViews.Count == 0)
                throw new InvalidViewConfigurationException("No canvas was provided to the Renderer!");

            if (CallbackViews.Count > 1)
                throw new InvalidViewConfigurationException("Multiple Views implementation still missing, use ony one canvas!");

            if (CallbackCameras.Count == 0)
            {
                Console.WriteLine("No Camera was found, defining a default Perspective Camera");
                CallbackCameras.Add(new BzPerspectiveCamera(THREE));
            }

            if (CallbackCameras.Count == 1)
                CallbackCameras[0].SetActive();

            if (CallbackScenes.Count == 1)
                CallbackScenes[0].SetActive();

            _window = JS.GetWindow();
            _document = JS.GetDocument();

            _renderer = THREE.WebGLRenderer(new WebGLRendererParameters
            {
                Canvas = new Element(CallbackViews[0].CanvasReference),
            });

            if(ActiveScene!.ClearColor.HasValue)
                _renderer.SetClearColor(ActiveScene.ClearColor.Value);

            _renderer.SetSize(CallbackViews[0].Width, CallbackViews[0].Height);

            _renderer.SetAnimationLoop(AnimationLoop);
        }

    }

    private void AnimationLoop()
    {
        if (ActiveScene is null || ActiveCamera is null)
            return;

        _renderer?.Render(ActiveScene.Scene, ActiveCamera.Camera);
    }
}
