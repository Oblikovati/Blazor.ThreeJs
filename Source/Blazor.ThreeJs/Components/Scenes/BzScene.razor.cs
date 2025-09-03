namespace Blazor.ThreeJs.Components;

public partial class BzScene : ComponentBase
{
    private readonly THREE _t;
    public BzScene(THREE t)
    {
        _t = t;
        Scene = _t.Scene(new Scene.SceneParameters
        {

        });
    }

    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    [Parameter]
    public RenderFragment? Meshes { get; set; }

    [Parameter]
    public bool IsActive { get; set; } = true;

    [Parameter]
    public string Name { get; set; } = "DefaultScene";

    [Parameter]
    public int? ClearColor { get; set; } = null;

    public Scene.Scene Scene { get; private set; }

    internal List<BzMesh> CallbackMeshes { get; set; } = [];

    public void SetActive()
    {
        IsActive = true;
    }

    protected override void OnInitialized()
    {
        foreach (var mesh in CallbackMeshes)
            Scene.Add(mesh.Mesh);

        Parent?.CallbackScenes.Add(this);
    }
}
