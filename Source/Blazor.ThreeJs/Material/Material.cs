using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace Blazor.ThreeJs.Material;

public abstract class Material(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{
    /// <summary>
    /// Enables alpha hashed transparency, an alternative to .transparent or .alphaTest. 
    /// The material will not be rendered if opacity is lower than a random threshold. 
    /// Randomization introduces some grain or noise, but approximates alpha blending without the associated problems of sorting. 
    /// Using TAARenderPass can reduce the resulting noise.
    /// </summary>
    public bool AlphaHash { get => JSRef!.Get<bool>("alphaHash"); set => JSRef!.Set("alphaHash", value); }

    /// <summary>
    /// Sets the alpha value to be used when running an alpha test. 
    /// The material will not be rendered if the opacity is lower than this value. Default is 0.
    /// </summary>
    public float AlphaTest { get => JSRef!.Get<float>("alphaTest"); set => JSRef!.Set("alphaTest", value); }

    /// <summary>
    /// Enables alpha to coverage. 
    /// Can only be used with MSAA-enabled contexts (meaning when the renderer was created with antialias parameter set to true). 
    /// Enabling this will smooth aliasing on clip plane edges and alphaTest-clipped edges. Default is false.
    /// </summary>
    public bool AlphaToCoverage { get => JSRef!.Get<bool>("alphaToCoverage"); set => JSRef!.Set("alphaToCoverage", value); }

    /// <summary>
    /// Represents the alpha value of the constant blend color. Default is 0. This property has only an effect when using custom blending with ConstantAlpha or OneMinusConstantAlpha.
    /// </summary>
    public float BlendAlpha { get => JSRef!.Get<float>("blendAlpha"); set => JSRef!.Set("blendAlpha", value); }

    /// <summary>
    /// Represent the RGB values of the constant blend color. Default is 0x000000.
    /// This property has only an effect when using custom blending with ConstantColor or OneMinusConstantColor.
    /// </summary>
    public Color BlendColor { get => JSRef!.Get<Color>("blendColor"); set => JSRef!.Set("blendColor", value); }

    /// <summary>
    /// Blending destination. Default is OneMinusSrcAlphaFactor. See the destination factors constants for all possible values.
    /// The material's blending must be set to CustomBlending for this to have any effect.
    /// </summary>
    public int BlendDst { get => JSRef!.Get<int>("blendDst"); set => JSRef!.Set("blendDst", value); }

    /// <summary>
    /// The transparency of the .blendDst. Uses .blendDst value if null. Default is null.
    /// </summary>
    public int BlendDstAlpha { get => JSRef!.Get<int>("blendDstAlpha"); set => JSRef!.Set("blendDstAlpha", value); }

    /// <summary>
    /// Blending equation to use when applying blending. Default is AddEquation. See the blending equation constants for all possible values.
    /// The material's blending must be set to CustomBlending for this to have any effect.
    /// </summary>
    public int BlendEquation { get => JSRef!.Get<int>("blendEquation"); set => JSRef!.Set("blendEquation", value); }

    /// <summary>
    /// The transparency of the .blendEquation. Uses .blendEquation value if null. Default is null.
    /// </summary>
    public int BlendEquationAlpha { get => JSRef!.Get<int>("blendEquationAlpha"); set => JSRef!.Set("blendEquationAlpha", value); }

    /// <summary>
    /// Which blending to use when displaying objects with this material.
    /// This must be set to CustomBlending to use custom blendSrc, blendDst or blendEquation.See the blending mode constants for all possible values.
    /// Default is NormalBlending.
    /// </summary>
    public Blending Blending { get => JSRef!.Get<Blending>("blending"); set => JSRef!.Set("blending", value); }

    /// <summary>
    /// Blending source. Default is SrcAlphaFactor. See the source factors constants for all possible values.
    /// The material's blending must be set to CustomBlending for this to have any effect.
    /// </summary>
    public int BlendSrc { get => JSRef!.Get<int>("blendSrc"); set => JSRef!.Set("blendSrc", value); }

    /// <summary>
    /// The transparency of the .blendSrc. Uses .blendSrc value if null. Default is null.
    /// </summary>
    public int BlendSrcAlpha { get => JSRef!.Get<int>("blendSrcAlpha"); set => JSRef!.Set("blendSrcAlpha", value); }

    /// <summary>
    /// Changes the behavior of clipping planes so that only their intersection is clipped, rather than their union. Default is false.
    /// </summary>
    public bool ClipIntersection { get => JSRef!.Get<bool>("clipIntersection"); set => JSRef!.Set("clipIntersection", value); }

    /// <summary>
    /// User-defined clipping planes specified as THREE.Plane objects in world space. 
    /// These planes apply to the objects this material is attached to. 
    /// Points in space whose signed distance to the plane is negative are clipped (not rendered). 
    /// This requires WebGLRenderer.localClippingEnabled to be true. See the WebGL / clipping /intersection example. Default is null.
    /// </summary>
    public Array ClippingPlanes { get => JSRef!.Get<Array>("clippingPlanes"); set => JSRef!.Set("clippingPlanes", value); }

    /// <summary>
    /// Defines whether to clip shadows according to the clipping planes specified on this material. Default is false.
    /// </summary>
    public bool ClipShadows { get => JSRef!.Get<bool>("clipShadows"); set => JSRef!.Set("clipShadows", value); }

    /// <summary>
    /// Whether to render the material's color. 
    /// This can be used in conjunction with a mesh's renderOrder property to create invisible objects that occlude other objects. Default is true.
    /// </summary>
    public bool ColorWrite { get => JSRef!.Get<bool>("colorWrite"); set => JSRef!.Set("colorWrite", value); }

    /// <summary>
    /// Custom defines to be injected into the shader. These are passed in form of an object literal, with key/value pairs. 
    /// { MY_CUSTOM_DEFINE: '' , PI2: Math.PI * 2 }. 
    /// The pairs are defined in both vertex and fragment shaders. Default is undefined.
    /// </summary>
    public JSObject Defines { get => JSRef!.Get<JSObject>("defines"); set => JSRef!.Set("defines", value); }

    /// <summary>
    /// Which depth function to use. Default is LessEqualDepth. See the depth mode constants for all possible values.
    /// </summary>
    public int DepthFunc { get => JSRef!.Get<int>("depthFunc"); set => JSRef!.Set("depthFunc", value); }

    /// <summary>
    /// Whether to have depth test enabled when rendering this material. Default is true. 
    /// When the depth test is disabled, the depth write will also be implicitly disabled.
    /// </summary>
    public bool DepthTest { get => JSRef!.Get<bool>("depthTest"); set => JSRef!.Set("depthTest", value); }

    /// <summary>
    /// Whether rendering this material has any effect on the depth buffer. Default is true.
    /// When drawing 2D overlays it can be useful to disable the depth writing in order to layer several things together without creating z-index artifacts.
    /// </summary>
    public bool DepthWrite { get => JSRef!.Get<bool>("depthWrite"); set => JSRef!.Set("depthWrite", value); }

    /// <summary>
    /// Whether double-sided, transparent objects should be rendered with a single pass or not. Default is false.
    /// The engine renders double-sided, transparent objects with two draw calls (back faces first, then front faces) 
    /// to mitigate transparency artifacts. There are scenarios however where this approach produces no quality gains 
    /// but still doubles draw calls e.g. when rendering flat vegetation like grass sprites. In these cases,
    /// set the forceSinglePass flag to true to disable the two pass rendering to avoid performance issues.
    /// </summary>
    public bool ForceSinglePass { get => JSRef!.Get<bool>("forceSinglePass"); set => JSRef!.Set("forceSinglePass", value); }

    /// <summary>
    /// Read-only flag to check if a given object is of type Material.
    /// </summary>
    public bool IsMaterial { get => JSRef!.Get<bool>("isMaterial"); set => JSRef!.Set("isMaterial", value); }

    /// <summary>
    /// Whether stencil operations are performed against the stencil buffer. In order to perform writes or comparisons against 
    /// the stencil buffer this value must be true. Default is false.
    /// </summary>
    public bool StencilWrite { get => JSRef!.Get<bool>("stencilWrite"); set => JSRef!.Set("stencilWrite", value); }

    /// <summary>
    /// The bit mask to use when writing to the stencil buffer. Default is 0xFF.
    /// </summary>
    public int StencilWriteMask { get => JSRef!.Get<int>("stencilWriteMask"); set => JSRef!.Set("stencilWriteMask", value); }

    /// <summary>
    /// The stencil comparison function to use. Default is AlwaysStencilFunc. See stencil function constants for all possible values.
    /// </summary>
    public int StencilFunc { get => JSRef!.Get<int>("stencilFunc"); set => JSRef!.Set("stencilFunc", value); }

    /// <summary>
    /// The value to use when performing stencil comparisons or stencil operations. Default is 0.
    /// </summary>
    public int StencilRef { get => JSRef!.Get<int>("stencilRef"); set => JSRef!.Set("stencilRef", value); }

    /// <summary>
    /// The bit mask to use when comparing against the stencil buffer. Default is 0xFF.
    /// </summary>
    public int StencilFuncMask { get => JSRef!.Get<int>("stencilFuncMask"); set => JSRef!.Set("stencilFuncMask", value); }

    /// <summary>
    /// Which stencil operation to perform when the comparison function returns false. Default is KeepStencilOp. 
    /// See the stencil operations constants for all possible values.
    /// </summary>
    public int StencilFail { get => JSRef!.Get<int>("stencilFail"); set => JSRef!.Set("stencilFail", value); }

    /// <summary>
    /// Which stencil operation to perform when the comparison function returns true but the depth test fails. 
    /// Default is KeepStencilOp. See the stencil operations constants for all possible values.
    /// </summary>
    public int StencilZFail { get => JSRef!.Get<int>("stencilZFail"); set => JSRef!.Set("stencilZFail", value); }

    /// <summary>
    /// Which stencil operation to perform when the comparison function returns true and the depth test passes. 
    /// Default is KeepStencilOp. See the stencil operations constants for all possible values.
    /// </summary>
    public int StencilZPas { get => JSRef!.Get<int>("stencilZPass"); set => JSRef!.Set("stencilZPass", value); }

}