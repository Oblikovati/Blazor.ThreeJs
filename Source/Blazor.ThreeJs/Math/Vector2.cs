
namespace Blazor.ThreeJs.Math;

public class Vector2(IJSInProcessObjectReference _ref) : JSObject(_ref)
{
    public float X
    {
        get => JSRef!.Get<float>("x");
        set => JSRef!.Set("x", value);
    }

    public float Y
    {
        get => JSRef!.Get<float>("y");
        set => JSRef!.Set("y", value);
    }
}