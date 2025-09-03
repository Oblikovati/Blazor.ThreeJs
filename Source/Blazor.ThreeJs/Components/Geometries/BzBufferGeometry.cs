namespace Blazor.ThreeJs.Components.Geometries;

public abstract class BzBufferGeometry : ComponentBase
{
    [CascadingParameter]
    public BzMesh? Parent { get; set; }
    public abstract Geometry.BufferGeometry Geometry { get; protected set; }
}
