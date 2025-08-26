namespace Blazor.ThreeJs.Scene;

/// <summary>
/// Scenes allow you to set up what is to be rendered and where by three.js. This is where you place objects, lights and cameras. 
/// https://threejs.org/docs/?q=Scene#api/en/scenes/Scene
/// </summary>
public class Scene(IJSInProcessObjectReference _ref) : Object3D(_ref)
{

}