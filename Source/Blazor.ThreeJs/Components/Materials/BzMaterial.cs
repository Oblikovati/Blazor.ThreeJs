namespace Blazor.ThreeJs.Components;

public abstract class BzMaterial : ComponentBase
{
    [CascadingParameter]
    public BzRenderer? Parent { get; set; }

    public abstract Material.Material Material { get; protected set; }

    [Parameter]
    public string Name { get; set; } = "Default";

    protected override void OnInitialized()
    {
        Parent?.CallbackMaterials.Add(this);
    }
}
