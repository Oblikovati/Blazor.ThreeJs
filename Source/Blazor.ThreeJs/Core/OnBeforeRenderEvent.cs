

namespace Blazor.ThreeJs.Core;

public class OnBeforeRenderEvent : Event
{
    public OnBeforeRenderEvent(IJSInProcessObjectReference _ref) : base(_ref)
    {
    }
}