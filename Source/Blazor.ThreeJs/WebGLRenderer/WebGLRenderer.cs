using Microsoft.JSInterop;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.JSObjects;

namespace Blazor.ThreeJs.WebGLRenderer;

/// <summary>
/// The WebGL renderer displays your beautifully crafted scenes using WebGL. 
/// https://threejs.org/docs/?q=WebGLRenderer#api/en/renderers/WebGLRenderer
/// </summary>
public class WebGLRenderer : JSObject
{
    /// <inheritdoc />
    public WebGLRenderer(IJSInProcessObjectReference _ref) : base(_ref) { }

    /// <summary>
    /// 
    /// </summary>
    public Element DomElement => JSRef!.Get<Element>("domElement");

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetSize(int width, int height) => JSRef!.CallVoid("setSize", width, height);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="action"></param>
    public void SetAnimationLoop(Action action) => JSRef!.CallVoid("setAnimationLoop", Callback.Create(action));

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="camera"></param>
    public void Render(Scene.Scene scene, Camera.Camera camera) => JSRef!.CallVoid("render", scene, camera);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    public void SetClearColor(int color) => JSRef!.CallVoid("setClearColor", color);
}
