namespace Blazor.ThreeJs.Components;

public abstract class BzCamera : ComponentBase
{
    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    [Parameter]
    public bool IsActive { get; set; }

    public abstract Camera.Camera Camera { get; protected set; }

    public void SetActive()
    {
        IsActive = true;
    }

    protected override void OnInitialized()
    {
        Parent?.CallbackCameras.Add(this);
    }
}
