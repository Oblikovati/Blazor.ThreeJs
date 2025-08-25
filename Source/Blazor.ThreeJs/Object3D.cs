using Microsoft.JSInterop;
using SpawnDev.BlazorJS;

namespace Blazor.ThreeJs;

/// <summary>
/// This is the base class for most objects in three.js and provides a set of properties and methods for manipulating objects in 3D space.
/// Note that this can be used for grouping objects via the .add( object ) method which adds the object as a child, however it is better to use Group for this. 
/// https://threejs.org/docs/?q=came#api/en/core/Object3D
/// </summary>
public class Object3D : JSObject
{
    /// <inheritdoc />
    public Object3D(IJSInProcessObjectReference _ref) : base(_ref) { }

    /// <summary>
    /// A Vector3 representing the object's local position.
    /// </summary>
    public Vector3 Position
    {
        get => JSRef!.Get<Vector3>("position");
        set => JSRef!.Set("position", value);
    }

    /// <summary>
    /// Object's local rotation (see Euler angles), in radians. 
    /// </summary>
    public Vector3 Rotation
    {
        get => JSRef!.Get<Vector3>("rotation");
        set => JSRef!.Set("rotation", value);
    }
}