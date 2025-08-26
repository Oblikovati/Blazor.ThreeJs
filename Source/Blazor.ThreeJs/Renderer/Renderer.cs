
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.RemoteJSRuntime;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Blazor.ThreeJs.Renderer;

/// <summary>
/// Renderer base class
/// https://github.com/mrdoob/three.js/blob/dev/src/renderers/common/Renderer.js
/// </summary>
/// <param name="_ref"></param>
public abstract class Renderer(IJSInProcessObjectReference _ref) : JSObject(_ref)
{
    /// <summary>
    /// 
    /// </summary>
    public bool IsRenderer { get => JSRef!.Get<bool>("isRenderer"); }
    /// <summary>
    /// A canvas where the renderer draws its output.
    /// This is automatically created by the renderer in the constructor(if not provided already); you just need to add it to your page like so:
    /// Document.Body.AppendChild(renderer.DomElement);
    /// </summary>
    public Element DomElement => JSRef!.Get<Element>("domElement");

    /// <summary>
    /// Defines whether the renderer should automatically clear its output before rendering a frame. Default is true. 
    /// </summary>
    public bool AutoClear { get => JSRef!.Get<bool>("autoClear"); set => JSRef!.Set("autoClear", value); }

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
    public DebugConfig Debug { get => JSRef!.Get<DebugConfig>("debug"); set => JSRef!.Set("debug", value); }

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
    /// Initializes the renderer so it is ready for usage.
    /// </summary>
    /// <returns>A Promise that resolves when the renderer has been initialized.</returns>
    public Task<Renderer> InitAsync() => JSRef!.CallAsync<Renderer>("init");

    /// <summary>
    /// The coordinate system of the renderer. The value of this property depends on the selected backend.
    /// </summary>
    /// <returns></returns>
    public Number GetCoordinateSystem() => JSRef!.Call<Number>("coordinateSystem");

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
    /// Renders the scene.
    /// </summary>
    /// <param name="scene">The scene or 3D object to render.</param>
    /// <param name="camera">The camera to render the scene with.</param>
    public void Render(Scene.Scene scene, Camera.Camera camera) => JSRef!.CallVoid("render", scene, camera);

    /// <summary>
    /// Renders the scene in an async fashion.
    /// </summary>
    /// <param name="scene">The scene or 3D object to render.</param>
    /// <param name="camera">The camera to render the scene with.</param>
    /// <returns>A Promise that resolve when the scene has been rendered.</returns>
    public Task RenderAsync(Scene.Scene scene, Camera.Camera camera) => JSRef!.CallAsync("render", scene, camera);

    /// <summary>
    /// Can be used to synchronize CPU operations with GPU tasks. So when this method is called,
    /// the CPU waits for the GPU to complete its operation(e.g.a compute task).
    /// </summary>
    /// <returns>A Promise that resolves when synchronization has been finished.</returns>
    public Task WaitForGPU() => JSRef!.CallAsync("waitForGPU");

    /// <summary>
    /// Returns the maximum available anisotropy for texture filtering.
    /// </summary>
    /// <returns>The maximum available anisotropy.</returns>
    public Number GetMaxAnisotropy() => JSRef!.Call<Number>("getMaxAnisotropy");

    /// <summary>
    /// Returns the active cube face.
    /// </summary>
    /// <returns>The active cube face.</returns>
    public Number GetActiveCubeFace() => JSRef!.Call<Number>("getActiveCubeFace");

    /// <summary>
    /// Returns the active mipmap level.
    /// </summary>
    /// <returns>The active mipmap level.</returns>
    public Number GetActiveMipmapLevel() => JSRef!.Call<Number>("getActiveMipmapLevel");

    /// <summary>
    /// Applications are advised to always define the animation loop  with this method and not manually with `requestAnimationFrame()` for best compatibility.
    /// </summary>
    /// <param name="action">The application's animation loop.</param>
    /// <returns>A Promise that resolves when the set has been executed.</returns>
    public Task SetAnimationLoop(Action action) => JSRef!.CallAsync("setAnimationLoop", Callback.Create(action));

    /// <summary>
    /// Can be used to transfer buffer data from a storage buffer attribute from the GPU to the CPU in context of compute shaders.
    /// </summary>
    /// <param name="attribute">The storage buffer attribute.</param>
    /// <returns>A promise that resolves with the buffer data when the data are ready.</returns>
    public Task<ArrayBuffer> GetArrayBufferAsync(StorageBufferAttribute attribute) 
        => JSRef!.CallAsync<ArrayBuffer>("getArrayBufferAsync", attribute);

    /// <summary>
    /// Returns the pixel ratio.
    /// </summary>
    /// <returns>The pixel ratio.</returns>
    public Number GetPixelRatio() => JSRef!.Call<Number>("getPixelRatio");

    /// <summary>
    /// Returns the drawing buffer size in physical pixels. This method honors the pixel ratio.
    /// </summary>
    /// <param name="target">The method writes the result in this target object.</param>
    /// <returns>The drawing buffer size.</returns>
    public Vector2 GetDrawingBufferSize(Vector2 target) => JSRef!.Call<Vector2>("getDrawingBufferSize", target);

    /// <summary>
    /// Returns the renderer's size in logical pixels. This method does not honor the pixel ratio.
    /// </summary>
    /// <param name="target">The method writes the result in this target object.</param>
    /// <returns>The renderer's size in logical pixels.</returns>
    public Vector2 GetSize(Vector2 target) => JSRef!.Call<Vector2>("getSize", target);

    /// <summary>
    /// Sets the given pixel ratio and resizes the canvas if necessary.
    /// </summary>
    /// <param name="value">The pixel ratio.</param>
    public void SetPixelRatio(Number value) => JSRef!.CallVoid("setPixelRatio", value);

    /// <summary>
    /// This method allows to define the drawing buffer size by specifying width, height and pixel ratio all at once.
    /// The size of the drawing buffer is computed with this formula:
    /// size.x = width * pixelRatio;
    /// size.y = height * pixelRatio;
    /// </summary>
    /// <param name="width">The width in logical pixels.</param>
    /// <param name="height">The height in logical pixels.</param>
    /// <param name="pixelRatio">The pixel ratio.</param>
    public void SetDrawingBufferSize(Number width, Number height, Number pixelRatio) => JSRef!.CallVoid("setDrawingBufferSize", width, height, pixelRatio);

    /// <summary>
    /// Sets the size of the renderer.
    /// </summary>
    /// <param name="width">The width in logical pixels.</param>
    /// <param name="height">The height in logical pixels.</param>
    /// <param name="updateStyle">Whether to update the `style` attribute of the canvas or not.</param>
    public void SetSize(int width, int height,bool updateStyle = true) => JSRef!.CallVoid("setSize", width, height, updateStyle);

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
    /// Defines the clear color and optionally the clear alpha.
    /// </summary>
    /// <param name="alpha">The clear alpha.</param>
    public void SetClearColor(int alpha) => JSRef!.CallVoid("setClearColor", alpha);
}