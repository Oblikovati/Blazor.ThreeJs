using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace Blazor.ThreeJs.Geometry;

/// <summary>
/// https://threejs.org/docs/?q=CircleGeometry#api/en/core/BufferGeometry
/// </summary>
/// <param name="_ref"></param>
public class BufferGeometry(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{
    public BufferGeometry SetFromPoints(Array<Vector3> points) => JSRef!.Call<BufferGeometry>("setFromPoints", points);
}