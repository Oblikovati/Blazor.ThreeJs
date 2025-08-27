namespace Blazor.ThreeJs.Components.Cameras;

public class BzPerspectiveCamera : BzCamera
{
    private readonly THREE _t;

    public BzPerspectiveCamera(THREE t)
    {
        _t = t;

        Camera = _t.PerspectiveCamera(Fov, Aspect, Near, Far);
    }

    public override Camera.Camera Camera { get; protected set; }

    [Parameter]
    public double Fov { get; set; } = 100;

    [Parameter]
    public double Aspect { get; set; } = 1;

    [Parameter]
    public double Near { get; set; } = 1;

    [Parameter]
    public double Far { get; set; } = 1000;
}