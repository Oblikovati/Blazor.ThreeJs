
namespace Blazor.ThreeJs.Components.Materials;

public class BzMeshBasicMaterial : BzMaterial
{
    private readonly THREE _t;

    public BzMeshBasicMaterial(THREE t)
    {
        _t = t;

        Material = _t.MeshBasicMaterial(new Material.MeshBasicMaterialParameters
        {
            Color = Color
        });
    }
    
    public override Material.Material Material { get; protected set; }

    [Parameter]
    public int Color { get; set; } = 0xFFFFFF;
}