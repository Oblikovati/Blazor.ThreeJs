using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace Blazor.ThreeJs.Camera;

/// <summary>
/// Abstract base class for cameras. This class should always be inherited when you build a new camera. 
/// https://threejs.org/docs/?q=came#api/en/cameras/Camera
/// </summary>
public abstract class Camera : Object3D
{
    /// <summary>
    /// Creates a new Camera. Note that this class is not intended to be called directly; 
    /// you probably want a PerspectiveCamera or OrthographicCamera instead. 
    /// </summary>
    /// <param name="_ref"></param>
    public Camera(IJSInProcessObjectReference _ref) : base(_ref) { }

    public Camera Clone () => JSRef!.Call<Camera>("clone");
}