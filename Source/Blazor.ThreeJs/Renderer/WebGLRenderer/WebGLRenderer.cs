namespace Blazor.ThreeJs.Renderer.WebGLRenderer;

/// <summary>
/// The WebGL renderer displays your beautifully crafted scenes using WebGL. 
/// https://threejs.org/docs/?q=WebGLRenderer#api/en/renderers/WebGLRenderer
/// </summary>
public class WebGLRenderer(IJSInProcessObjectReference _ref) : Renderer(_ref)
{
    /// <summary>
    /// Used to check whether various extensions are supported and returns an object with details of the extension if available.
    /// </summary>
    public Array<string> Extensions => JSRef!.Get<Array<string>>("extensions");

    /// <summary>
    /// Defines whether the renderer respects object-level clipping planes. Default is false.
    /// </summary>
    public bool LocalClippingEnabled { get => JSRef!.Get<bool>("localClippingEnabled"); set => JSRef!.Set("localClippingEnabled", value); }

    /// <summary>
    /// Used internally by the renderer to keep track of various sub object properties. 
    /// </summary>
    public JSObject Properties => JSRef!.Get<JSObject>("properties");
}
