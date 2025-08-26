namespace Blazor.ThreeJs.Texture;

public class Texture(IJSInProcessObjectReference _ref) : JSObject(_ref)
{
    /// <summary>
    /// Unique number for this object instance.
    /// </summary>
    public int Id => JSRef!.Get<int>("id");

    /// <summary>
    /// 
    /// </summary>
    public bool IsTexture => JSRef!.Get<bool>("isTexture");

    /// <summary>
    /// UUID of this object instance. This gets automatically assigned, so this shouldn't be edited. 
    /// </summary>
    public string Uuid => JSRef!.Get<string>("uuid");

    /// <summary>
    /// Optional name of the object (doesn't need to be unique).
    /// Default is an empty string.
    /// </summary>
    public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }

    /// <summary>
    /// An image object, typically created using the TextureLoader.load method. 
    /// This can be any image (e.g., PNG, JPG, GIF, DDS) or video (e.g., MP4, OGG/OGV) type supported by three.js.
    /// To use video as a texture you need to have a playing HTML5 video element as a source for your texture image and 
    /// continuously update this texture as long as video is playing - the VideoTexture class handles this automatically. 
    /// </summary>
    public HTMLImageElement Image { get => JSRef!.Get<HTMLImageElement>("image"); set => JSRef!.Set("image", value); }
}