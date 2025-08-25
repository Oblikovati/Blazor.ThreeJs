namespace Blazor.ThreeJs.Core;

public class OnAfterRenderEvent : Event
{
    public OnAfterRenderEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
}