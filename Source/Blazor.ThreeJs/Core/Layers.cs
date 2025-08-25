namespace Blazor.ThreeJs.Core;

/// <summary>
/// A Layers object assigns an Object3D to 1 or more of 32 layers numbered 0 to 31 
/// - internally the layers are stored as a bit mask, and by default all Object3Ds are a member of layer 0.
/// This can be used to control visibility - an object must share a layer with a camera to be visible when that camera's view is rendered.
/// </summary>
public class Layers : JSObject
{
    public Layers(IJSInProcessObjectReference _ref) : base(_ref) { }

    /// <summary>
    /// A bit mask storing which of the 32 layers this layers object is currently a member of
    /// </summary>
    public int Mask
    {
        get => JSRef!.Get<int>("mask");
        set => JSRef!.Set("mask", value);
    }
}