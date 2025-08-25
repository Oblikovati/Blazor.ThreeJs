namespace Blazor.ThreeJs.Math;

/// <summary>
/// Quaternions are used in three.js to represent rotations. 
/// </summary>
public class Quaternion(IJSInProcessObjectReference _ref) : JSObject(_ref)
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

    public float Z
    {
        get => JSRef!.Get<float>("z");
        set => JSRef!.Set("z", value);
    }

    public float W
    {
        get => JSRef!.Get<float>("w");
        set => JSRef!.Set("w", value);
    }

    public bool IsQuaternion
    {
        get => JSRef!.Get<bool>("isQuaternion");
    }
}