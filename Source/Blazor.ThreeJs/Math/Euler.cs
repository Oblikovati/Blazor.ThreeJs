namespace Blazor.ThreeJs.Math;

/// <summary>
/// A class representing Euler Angles.
/// Euler angles describe a rotational transformation by rotating an object on its 
/// various axes in specified amounts per axis, and a specified axis order. 
/// Iterating through a Euler instance will yield its components (x, y, z, order) in the corresponding order. 
/// https://threejs.org/docs/?q=obj#api/en/math/Euler
/// </summary>
public class Euler(IJSInProcessObjectReference _ref) : JSObject(_ref)
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

    public bool IsEuler
    {
        get => JSRef!.Get<bool>("isEuler");
    }
}