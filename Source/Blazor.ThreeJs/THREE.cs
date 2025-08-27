using Blazor.ThreeJs.Camera;
using Blazor.ThreeJs.Renderer.WebGPURenderer;
using Blazor.ThreeJs.Renderer.WebGLRenderer;
using Blazor.ThreeJs.Geometry;
using Blazor.ThreeJs.Extras.Core;
namespace Blazor.ThreeJs;

#pragma warning disable S101 // Types should be named in PascalCase
public class THREE
#pragma warning restore S101 // Types should be named in PascalCase
{
    #region Private And Ctor
    private readonly string ThreeNS = "window.Three";
    private readonly BlazorJSRuntime JS;

    public THREE(BlazorJSRuntime js)
    {
        JS = js;

        if (JS is null)
            throw new InvalidOperationException(
                "BlazorJSRuntime not injected. Ensure you have added services.AddBlazorJSRuntime()" +
                " in Program.cs and that THREE is registered as a service.");
    }

    #endregion

    #region Addons

    #endregion

    #region Camera
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
    #endregion

    #region Core

    #endregion

    #region Geometry
    /// <summary>
    /// Creates a Box Geometry
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public BoxGeometry BoxGeometry(double x, double y, double z)
    {
        return JS.New<BoxGeometry>($"{ThreeNS}.BoxGeometry", x, y, z);
    }

    /// <summary>
    /// Creates a Buffer Geometry
    /// </summary>
    /// <returns></returns>
    public BufferGeometry BufferGeometry()
    {
        return JS.New<BufferGeometry>($"{ThreeNS}.BufferGeometry");
    }

    /// <summary>
    /// Creates a Capsule Geometry
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="height"></param>
    /// <param name="capSegments"></param>
    /// <param name="radialSegments"></param>
    /// <param name="heightSegments"></param>
    /// <returns></returns>
    public CapsuleGeometry CapsuleGeometry(float radius, float height, int capSegments, int radialSegments, int heightSegments)
    {
        return JS.New<CapsuleGeometry>($"{ThreeNS}.CapsuleGeometry", radius, height, capSegments, radialSegments, heightSegments);
    }

    /// <summary>
    /// Creates a Circle Geometry
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="segments"></param>
    /// <param name="thetaStart"></param>
    /// <param name="thetaEnd"></param>
    /// <returns></returns>
    public CircleGeometry CircleGeometry(float radius = 1, int segments = 32, float thetaStart = 0, float thetaEnd = MathF.PI * 2)
    {
        return JS.New<CircleGeometry>($"{ThreeNS}.CircleGeometry", radius, segments, thetaStart, thetaEnd);
    }

    /// <summary>
    /// Creates a Cone Geometry.
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="height"></param>
    /// <param name="radialSegments"></param>
    /// <param name="heightsegments"></param>
    /// <param name="openEnded"></param>
    /// <param name="thetaStart"></param>
    /// <param name="thetaEnd"></param>
    /// <returns></returns>
    public ConeGeometry ConeGeometry(float radius = 1, float height = 1, int radialSegments = 32, int heightsegments = 1, bool openEnded = false, float thetaStart = 0, float thetaEnd = MathF.PI *2)
    {
        return JS.New<ConeGeometry>($"{ThreeNS}.ConeGeometry", radius, height, radialSegments, heightsegments, openEnded, thetaStart, thetaEnd);
    }

    /// <summary>
    /// Creates a Cylinder Geometry.
    /// </summary>
    /// <param name="radiusTop"></param>
    /// <param name="radiusBottom"></param>
    /// <param name="height"></param>
    /// <param name="radialSegments"></param>
    /// <param name="heightSegments"></param>
    /// <param name="openEnded"></param>
    /// <param name="thetaStart"></param>
    /// <param name="thetaEnd"></param>
    /// <returns></returns>
    public CylinderGeometry CylinderGeometry(float radiusTop =1, float radiusBottom =1, float height =1, int radialSegments =32, int heightSegments=1, bool openEnded=false, float thetaStart=0, float thetaEnd=MathF.PI*2)
    {
        return JS.New<CylinderGeometry>($"{ThreeNS}.CylinderGeometry", radiusTop, radiusBottom, height, radialSegments, heightSegments, openEnded, thetaStart, thetaEnd);
    }
    /// <summary>
    /// Creates a Dodecahedron Geometry
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="detail"></param>
    /// <returns></returns>
    public DodecahedronGeometry DodecahedronGeometry(float radius = 1, int detail = 0)
    {
        return JS.New<DodecahedronGeometry>($"{ThreeNS}.DodecahedronGeometry", radius, detail);
    }

    /// <summary>
    /// Create a Edges Geometry
    /// </summary>
    /// <param name="geometry"></param>
    /// <param name="thresholdAngle"></param>
    /// <returns></returns>
    public EdgesGeometry EdgesGeometry(BufferGeometry geometry, int thresholdAngle)
    {
        return JS.New<EdgesGeometry>($"{ThreeNS}.EdgesGeometry", geometry, thresholdAngle);
    }

    public ExtrudeGeometry ExtrudeGeometry(Shape shape, ExtrudeGeometrySettings settings)
    {
        return JS.New<ExtrudeGeometry>($"{ThreeNS}.ExtrudeGeometry", shape, settings);
    }


    #endregion

    #region Material
    /// <summary>
    /// Creates a Mesh Basic Material
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
    /// <param name="parameters"></param>
    /// <returns></returns>
    public Material.LineBasicMaterial LineBasicMaterial(Material.LineBasicMaterialParameters parameters)
    {
        return JS.New<Material.LineBasicMaterial>($"{ThreeNS}.LineBasicMaterial", parameters);
    }
    #endregion

    #region Math
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
    #endregion

    #region Mesh
    /// <summary>
    /// Creates a Mesh
    /// </summary>
    /// <param name="geometry"></param>
    /// <returns></returns>
    public Mesh.Mesh Mesh(Geometry.BufferGeometry geometry, Material.Material material)
    {
        return JS.New<Mesh.Mesh>($"{ThreeNS}.Mesh", geometry, material);
    }
    #endregion

    #region Objects
    /// <summary>
    /// 
    /// </summary>
    /// <param name="geometry"></param>
    /// <param name="material"></param>
    /// <returns></returns>
    public Objects.Line Line(BufferGeometry geometry, Material.Material material)
    {
        return JS.New<Objects.Line>($"{ThreeNS}.Line", geometry, material);
    }

    #endregion

    #region Renderer
    /// <summary>
    /// Creates a WebGL Renderer
    /// </summary>
    /// <returns>WebGLRenderer Instance</returns>
    public WebGLRenderer WebGLRenderer(WebGLRendererParameters? parameters = null)
    {
        if (parameters is null)
            return JS.New<WebGLRenderer>($"{ThreeNS}.WebGLRenderer");
        else
            return JS.New<WebGLRenderer>($"{ThreeNS}.WebGLRenderer", parameters);
    }

    /// <summary>
    /// Creates a WebGPU Renderer
    /// You must import interop-webgpu.js Instead of interop.js In your Index.html to use WebGPU
    /// </summary>
    /// <returns>WebGPURenderer Instance</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public WebGPURenderer WebGPURenderer()
    {
        if (ThreeNS is "window.Three")
            throw new InvalidOperationException("You must call ActivateWebGPU() before calling any of the THREE functions!");

        return JS.New<WebGPURenderer>($"{ThreeNS}.WebGLRenderer");
    }
    #endregion

    #region Scene
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
    #endregion

    #region Texture

    #endregion
}
