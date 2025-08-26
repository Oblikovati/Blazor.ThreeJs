using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace Blazor.ThreeJs.Geometry;

public class BufferGeometry(IJSInProcessObjectReference _ref) : Geometry(_ref)
{
    public BufferGeometry SetFromPoints(Array<Vector3> points) => JSRef!.Call<BufferGeometry>("setFromPoints", points);
}