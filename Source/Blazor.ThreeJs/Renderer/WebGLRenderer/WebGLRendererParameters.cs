using System.Text.Json.Serialization;

namespace Blazor.ThreeJs.Renderer.WebGLRenderer;

/// <summary>
/// Dbject with properties defining the renderer's behavior. 
/// https://threejs.org/docs/?q=we#api/en/renderers/WebGLRenderer
/// </summary>
public class WebGLRendererParameters
{
    /// <summary>
    /// A canvas where the renderer draws its output. 
    /// This corresponds to the domElement property below. If not passed in here, a new canvas element will be created.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Element? Canvas { get; set; }

    /// <summary>
    /// This can be used to attach the renderer to an existing RenderingContext. Default is null.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public WebGLRenderingContext? Context { get; set; }

    /// <summary>
    /// Shader precision. Can be "highp", "mediump" or "lowp". Defaults to "highp" if supported by the device.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Precision { get; set; }

    /// <summary>
    /// controls the default clear alpha value. When set to true, the value is 0. Otherwise it's 1. Default is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Alpha { get; set; }

    /// <summary>
    /// whether the renderer will assume that colors have premultiplied alpha. Default is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PremultipliedAlpha { get; set; }

    /// <summary>
    /// whether to perform antialiasing. Default is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Antialias { get; set; }

    /// <summary>
    /// whether the drawing buffer has a stencil buffer of at least 8 bits. Default is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Stencil { get; set; }

    /// <summary>
    /// whether to preserve the buffers until manually cleared or overwritten. Default is false.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? PreserveDrawingBuffer { get; set; }

    /// <summary>
    /// Provides a hint to the user agent indicating what configuration of GPU is suitable for this WebGL context. 
    /// Can be "high-performance", "low-power" or "default". Default is "default". See WebGL spec for details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PowerPreference { get; set; }

    /// <summary>
    /// whether the renderer creation will fail upon low performance is detected. Default is false. See WebGL spec for details.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? FailIfMajorPerformanceCaveat { get; set; }

    /// <summary>
    /// whether the drawing buffer has a depth buffer of at least 16 bits. Default is true.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Depth { get; set; }

    /// <summary>
    /// whether to use a logarithmic depth buffer. It may be necessary to use this if dealing with huge differences in scale in a single scene. 
    /// Note that this setting uses gl_FragDepth if available which disables the Early Fragment Test optimization and can cause a decrease in performance. 
    /// Default is false. See the camera / logarithmicdepthbuffer example. reverseDepthBuffer - whether to use a reverse depth buffer. 
    /// Requires the EXT_clip_control extension. This is a more faster and accurate version than logarithmic depth buffer. 
    /// Default is false. 
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? LogarithmicDepthBuffer { get; set; }
}
