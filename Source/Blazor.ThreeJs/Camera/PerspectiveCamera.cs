namespace Blazor.ThreeJs.Camera;

/// <summary>
/// Camera that uses perspective projection.
/// This projection mode is designed to mimic the way the human eye sees. 
/// It is the most common projection mode used for rendering a 3D scene. 
/// https://threejs.org/docs/?q=came#api/en/cameras/PerspectiveCamera
/// </summary>
public class PerspectiveCamera : Camera
{
    /// <summary>
    /// Camera that uses perspective projection.
    /// </summary>
    /// <param name="_ref"></param>
    public PerspectiveCamera(IJSInProcessObjectReference _ref) : base(_ref) { }
}