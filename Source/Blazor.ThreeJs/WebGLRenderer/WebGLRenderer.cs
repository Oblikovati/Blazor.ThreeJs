namespace Blazor.ThreeJs.WebGLRenderer;

/// <summary>
/// The WebGL renderer displays your beautifully crafted scenes using WebGL. 
/// https://threejs.org/docs/?q=WebGLRenderer#api/en/renderers/WebGLRenderer
/// </summary>
public class WebGLRenderer(IJSInProcessObjectReference _ref) : JSObject(_ref)
{

    /// <summary>
    /// Defines whether the renderer should automatically clear its output before rendering a frame. Default is true. 
    /// </summary>
    public bool AutoClear { get => JSRef!.Get<bool>("autoClear"); set => JSRef!.Set("autoClear",value); }

    /// <summary>
    /// If autoClear is true, defines whether the renderer should clear the color buffer. Default is true.
    /// </summary>
    public bool AutoClearColor { get => JSRef!.Get<bool>("autoClearColor"); set => JSRef!.Set("autoClearColor", value); }

    /// <summary>
    /// If autoClear is true, defines whether the renderer should clear the depth buffer. Default is true.
    /// </summary>
    public bool AutoClearDepth { get => JSRef!.Get<bool>("autoClearDepth"); set => JSRef!.Set("autoClearDepth", value); }

    /// <summary>
    /// If autoClear is true, defines whether the renderer should clear the stencil buffer. Default is true.
    /// </summary>
    public bool AutoClearStencil { get => JSRef!.Get<bool>("autoClearStencil"); set => JSRef!.Set("autoClearStencil", value); }

    /// <summary>
    /// Debug Options
    /// </summary>
    public WebGLRendererDebugOptions Debug { get => JSRef!.Get<WebGLRendererDebugOptions>("debug"); set => JSRef!.Set("debug", value); }

    /// <summary>
    /// A canvas where the renderer draws its output.
    /// This is automatically created by the renderer in the constructor(if not provided already); you just need to add it to your page like so:
    /// Document.Body.AppendChild(renderer.DomElement);
    /// </summary>
    public Element DomElement => JSRef!.Get<Element>("domElement");

    /// <summary>
    /// Used to check whether various extensions are supported and returns an object with details of the extension if available.
    /// </summary>
    public Array<string> Extensions => JSRef!.Get<Array<string>>("extensions");

    /// <summary>
    /// Defines the output color space of the renderer. Default is THREE.SRGBColorSpace.
    /// </summary>
    public string OutputColorSpace => JSRef!.Get<string>("outputColorSpace");

    /// <summary>
    /// An object with a series of statistical information about the graphics board memory and the rendering process. 
    /// Useful for debugging or just for the sake of curiosity.
    /// </summary>
    public JSObject Info => JSRef!.Get<JSObject>("info");

    /// <summary>
    /// Defines whether the renderer respects object-level clipping planes. Default is false.
    /// </summary>
    public bool LocalClippingEnabled { get => JSRef!.Get<bool>("localClippingEnabled"); set => JSRef!.Set("localClippingEnabled", value); }

    /// <summary>
    /// Used internally by the renderer to keep track of various sub object properties. 
    /// </summary>
    public JSObject Properties => JSRef!.Get<JSObject>("properties");

    /// <summary>
    /// Tells the renderer to clear its color, depth or stencil drawing buffer(s). 
    /// This method initializes the color buffer to the current clear color value.Arguments default to true. 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="depth"></param>
    /// <param name="stencil"></param>
    public void Clear(bool color, bool depth, bool stencil) => JSRef!.CallVoid("clear", color, depth, stencil);

    /// <summary>
    /// Clear the color buffer.
    /// </summary>
    public void ClearColor() => JSRef!.CallVoid("clearColor");

    /// <summary>
    /// Clear the depth buffer.
    /// </summary>
    public void ClearDepth() => JSRef!.CallVoid("clearDepth");

    /// <summary>
    /// Clear the stencil buffer.
    /// </summary>
    public void ClearStencil() => JSRef!.CallVoid("clearStencil");

    /// <summary>
    /// Compiles all materials in the scene with the camera. This is useful to precompile shaders before the first rendering.
    /// If you want to add a 3D object to an existing scene, use the third optional parameter for applying the target scene.
    /// Note that the (target) scene's lighting and environment should be configured before calling this method.
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="camera"></param>
    /// <param name="targetScene"></param>
    /// <returns></returns>
    public Set Compile(Scene.Scene scene, Camera.Camera camera, Scene.Scene? targetScene)
    {
        if (targetScene is null)
            return JSRef!.Call<Set>("compile", scene, camera);
        else
            return JSRef!.Call<Set>("compile", scene, camera, targetScene);
    }

    /// <summary>
    /// Asynchronous version of .compile(). 
    /// The method returns a Promise that resolves when the given scene can be rendered without unnecessary stalling due to shader compilation.
    /// This method makes use of the KHR_parallel_shader_compile WebGL extension. 
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="camera"></param>
    /// <param name="targetScene"></param>
    /// <returns></returns>
    public Task CompileAsync(Scene.Scene scene, Camera.Camera camera, Scene.Scene? targetScene)
    {
        if (targetScene is null)
            return JSRef!.CallAsync<Set>("compileAsync", scene, camera);
        else
            return JSRef!.CallAsync<Set>("compileAsync", scene, camera, targetScene);
    }

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
