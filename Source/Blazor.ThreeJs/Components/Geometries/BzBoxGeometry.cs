using Blazor.ThreeJs.Geometry;

namespace Blazor.ThreeJs.Components.Geometries;

public sealed class BzBoxGeometry(THREE THREE) : BzBufferGeometry
{
    [Parameter]
    public double X { get; set; } = 1;

    [Parameter]
    public double Y { get; set; } = 1;

    [Parameter]
    public double Z { get; set; } = 1;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public override BufferGeometry Geometry { get; protected set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    protected override void OnInitialized()
    {
        Geometry = THREE.BoxGeometry(X, Y, Z);
    }
}
