using Blazor.ThreeJs.Camera;

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
    /// Creates a WebGL Renderer
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
    /// Creates a Scene
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
    /// Creates a Perspective Camera
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
    /// Creates a Mesh
    /// </summary>
    /// <param name="geometry"></param>
    /// <returns></returns>
    public Mesh.Mesh Mesh(Geometry.Geometry geometry, Material.Material material)
    {
        return JS.New<Mesh.Mesh>($"{ThreeNS}.Mesh", geometry, material);
    }

    /// <summary>
    /// Creates a Mesh Basic Material
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public Material.MeshBasicMaterial MeshBasicMaterial(Material.MeshBasicMaterialParameters parameters)
    {
        return JS.New<Material.MeshBasicMaterial>($"{ThreeNS}.MeshBasicMaterial", parameters);
    }

    public Material.LineBasicMaterial LineBasicMaterial(Material.LineBasicMaterialParameters parameters)
    {
        return JS.New<Material.LineBasicMaterial>($"{ThreeNS}.LineBasicMaterial", parameters);
    }

    /// <summary>
    /// Creates a Box Geometry
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
    /// Creates a Buffer Geometry
    /// </summary>
    /// <returns></returns>
    public Geometry.BufferGeometry BufferGeometry()
    {
        return JS.New<Geometry.BufferGeometry>($"{ThreeNS}.BufferGeometry");
    }

    /// <summary>
    /// Creates a continuous line.
    /// </summary>
    /// <param name="geometry"></param>
    /// <param name="material"></param>
    /// <returns></returns>
    public Objects.Line Line(Geometry.Geometry geometry, Material.Material material)
    {
        return JS.New<Objects.Line>($"{ThreeNS}.Line", geometry, material);
    }

    /// <summary>
    /// Creates a Vector3
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
