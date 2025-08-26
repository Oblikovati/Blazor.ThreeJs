namespace Blazor.ThreeJs.WebGLRenderer;

/// <summary>
/// https://threejs.org/docs/?q=we#api/en/renderers/WebGLRenderer
/// </summary>
public class WebGLRendererDebugOptions(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{
    /// <summary>
    /// defines whether material shader programs are checked for errors during compilation and linkage process. 
    /// It may be useful to disable this check in production for performance gain. It is strongly recommended to keep these checks enabled during development. 
    /// If the shader does not compile and link - it will not work and associated material will not render. Default is true.
    /// </summary>
    public bool CheckShaderErrors { get => JSRef!.Get<bool>("checkShaderErrors"); set => JSRef!.Set("checkShaderErrors", value); }

    /// <summary>
    ///  A callback function that can be used for custom error reporting. 
    ///  The callback receives the WebGL context, an instance of WebGLProgram as well two instances of WebGLShader representing the vertex and fragment shader. 
    ///  Assigning a custom function disables the default error reporting. Default is null. 
    /// </summary>
    public ActionEvent<OnShaderErrorEvent> OnShaderError { get => new ActionEvent<OnShaderErrorEvent>("onShaderError", AddEventListener, RemoveEventListener); set { } }
}