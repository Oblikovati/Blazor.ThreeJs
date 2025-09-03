namespace Blazor.ThreeJs.Components;

public abstract class BzCamera : ComponentBase
{
    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    public abstract Camera.Camera Camera { get; protected set; }

    protected override void OnInitialized()
    {
        Parent?.CallbackCameras.Add(this);
    }
}
