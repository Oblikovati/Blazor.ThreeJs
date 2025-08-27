namespace Blazor.ThreeJs.Math;

public class Color(IJSInProcessObjectReference _ref) : JSObject(_ref)
{
    public bool IsColor { get => JSRef!.Get<bool>("isColor"); set => JSRef!.Set("isColor", value); }

    public float R { get => JSRef!.Get<float>("r"); set => JSRef!.Set("r", value); }

    public float G { get => JSRef!.Get<float>("g"); set => JSRef!.Set("g", value); }

    public float B { get => JSRef!.Get<float>("b"); set => JSRef!.Set("b", value); }
}
