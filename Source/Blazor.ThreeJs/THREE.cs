using Blazor.ThreeJs.Camera;
using Blazor.ThreeJs.Math;

namespace Blazor.ThreeJs;

public class THREE
{
    private const string ThreeNS = "window.Three";
    private readonly BlazorJSRuntime JS;

    public THREE(BlazorJSRuntime js)
    {
        JS = js;

        if (JS is null)
            throw new InvalidOperationException(
                "BlazorJSRuntime not injected. Ensure you have added services.AddBlazorJSRuntime()" +
                " in Program.cs and that THREE is registered as a service.");
    }

    /// <summary>
    /// The WebGL renderer displays your beautifully crafted scenes using WebGL. 
    /// </summary>
    /// <returns>WebGLRenderer Instance</returns>
    public WebGLRenderer.WebGLRenderer WebGLRenderer(WebGLRenderer.WebGLRendererParameters? parameters = null)
    {
        if (parameters is null)
            return JS.New<WebGLRenderer.WebGLRenderer>($"{ThreeNS}.WebGLRenderer");
        else
            return JS.New<WebGLRenderer.WebGLRenderer>($"{ThreeNS}.WebGLRenderer", parameters);
    }

    /// <summary>
    /// Scenes allow you to set up what is to be rendered and where by three.js.
    /// This is where you place objects, lights and cameras. 
    /// </summary>
    /// <returns>Scene Instance</returns>
    public Scene.Scene Scene(Scene.SceneParameters? parameters = null)
    {
        if (parameters is null)
            return JS.New<Scene.Scene>($"{ThreeNS}.Scene");
        else
            return JS.New<Scene.Scene>($"{ThreeNS}.Scene", parameters);
    }

    /// <summary>
    /// Camera that uses perspective projection.
    /// This projection mode is designed to mimic the way the human eye sees. 
    /// It is the most common projection mode used for rendering a 3D scene. 
    /// </summary>
    /// <param name="fov">Field Of View</param>
    /// <param name="aspect">Aspect Ratio</param>
    /// <param name="near">Near Field</param>
    /// <param name="far">Far Field</param>
    /// <returns></returns>
    public PerspectiveCamera PerspectiveCamera(double fov, double aspect, double near, double far)
    {
        return JS.New<PerspectiveCamera>($"{ThreeNS}.PerspectiveCamera", fov, aspect, near, far);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="geometry"></param>
    /// <returns></returns>
    public Mesh.Mesh Mesh(Geometry.Geometry geometry, Material.Material material)
    {
        return JS.New<Mesh.Mesh>($"{ThreeNS}.Mesh", geometry, material);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public Material.MeshBasicMaterial MeshBasicMaterial(Material.MeshBasicMaterialParameters parameters)
    {
        return JS.New<Material.MeshBasicMaterial>($"{ThreeNS}.MeshBasicMaterial", parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public Geometry.BoxGeometry BoxGeometry(double x, double y, double z)
    {
        return JS.New<Geometry.BoxGeometry>($"{ThreeNS}.BoxGeometry", x, y, z);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public Vector3 Vector3(float x, float y, float z)
    {
        return JS.New<Vector3>($"{ThreeNS}.Vector3", x, y, z);
    }
}
