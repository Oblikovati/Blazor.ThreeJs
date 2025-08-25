using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace Blazor.ThreeJs;

public class Vector3 : JSObject
{
    public Vector3(IJSInProcessObjectReference _ref) : base(_ref) { }

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

    public float Z
    {
        get => JSRef!.Get<float>("z");
        set => JSRef!.Set("z", value);
    }
}