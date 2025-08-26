namespace Blazor.ThreeJs.Renderer;

public class OnShaderErrorEvent(IJSInProcessObjectReference _ref) : Event(_ref)
{
    public JSObject Gl { get=> JSRef!.Get<JSObject>("gl"); set=> JSRef!.Set("gl", value); }

    public JSObject Program { get => JSRef!.Get<JSObject>("program"); set => JSRef!.Set("program", value); }

    public JSObject GlVertexShader { get => JSRef!.Get<JSObject>("glVertexShader"); set => JSRef!.Set("glVertexShader", value); }

    public JSObject GlFragmentShader { get => JSRef!.Get<JSObject>("glFragmentShader"); set => JSRef!.Set("glFragmentShader", value); }
}