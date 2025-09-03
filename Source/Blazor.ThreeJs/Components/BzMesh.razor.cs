using Blazor.ThreeJs.Components.Geometries;

namespace Blazor.ThreeJs.Components;

public partial class BzMesh(THREE THREE) : ComponentBase
{

    /// <summary>
    /// Holds all the Material Components
    /// </summary>
    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Material { get; set; }

    [Parameter]
    [Category("Behavior")]
    public RenderFragment? Geometry { get; set; }

    internal List<BzMaterial> CallbackMaterials { get; set; } = [];

    internal List<BzBufferGeometry> CallbackGeometries { get; set; } = [];


    public Mesh.Mesh Mesh { get; private set; }

    protected override void OnInitialized()
    {
        if (CallbackMaterials.Count == 0)
            throw new InvalidDataException("A material must be defined for the mesh!");

        if (CallbackGeometries.Count == 0)
            throw new InvalidDataException("A Geometry must be define for the mesh!");

        Mesh = THREE.Mesh(CallbackGeometries[0].Geometry, CallbackMaterials[0].Material);
    }
}
