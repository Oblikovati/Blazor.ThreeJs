using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace Blazor.ThreeJs.Core;

/// <summary>
/// This class stores data for an attribute (such as vertex positions, face indices, normals, colors, UVs, and any custom attributes ) 
/// associated with a BufferGeometry, which allows for more efficient passing of data to the GPU. See that page for details and a usage example. 
/// When working with vector-like data, the .fromBufferAttribute( attribute, index )
/// helper methods on Vector2, Vector3, Vector4, and Color classes may be helpful.
/// </summary>
public class BufferAttribute(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{
    /// <summary>
    /// The array holding data stored in the buffer.
    /// </summary>
    public TypedArray Array { get => JSRef!.Get<TypedArray>("array"); set => JSRef!.Set("array", value); }

    /// <summary>
    /// Represents the number of items this buffer attribute stores. 
    /// It is internally computed by dividing the array's length by the itemSize. Read-only property.
    /// </summary>
    public int Count { get => JSRef!.Get<int>("count"); }

    /// <summary>
    /// Configures the bound GPU type for use in shaders. Either THREE.FloatType or THREE.IntType, default is THREE.FloatType. 
    /// Note: this only has an effect for integer arrays and is not configurable for float arrays. 
    /// For lower precision float types, see THREE.Float16BufferAttribute.
    /// </summary>
    public Number GpuType { get => JSRef!.Get<Number>("gpuType"); set => JSRef!.Set("gpuType", value); }

    /// <summary>
    /// Read-only flag to check if a given object is of type BufferAttribute.
    /// </summary>
    public bool IsBufferAttribute { get => JSRef!.Get<bool>("isBufferAttribute"); }

    /// <summary>
    /// Unique number for this attribute instance.
    /// </summary>
    public int Id { get => JSRef!.Get<int>("id"); set => JSRef!.Set("id", value); }

    /// <summary>
    /// The length of vectors that are being stored in the array.
    /// </summary>
    public int ItemSize { get => JSRef!.Get<int>("itemSize"); set => JSRef!.Set("itemSize", value); }

    /// <summary>
    /// Optional name for this attribute instance. Default is an empty string.
    /// </summary>
    public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }

    /// <summary>
    /// Flag to indicate that this attribute has changed and should be re-sent to the GPU.
    /// Set this to true when you modify the value of the array.
    /// </summary>
    public bool NeedsUpdate { get => JSRef!.Get<bool>("needsUpdate"); set => JSRef!.Set("needsUpdate", value); }

    /// <summary>
    /// Indicates how the underlying data in the buffer maps to the values in the GLSL shader code. See the constructor above for details.
    /// </summary>
    public bool Normalized { get => JSRef!.Get<bool>("normalized"); set => JSRef!.Set("normalized", value); }

    /// <summary>
    /// A callback function that is executed after the Renderer has transferred the attribute array data to the GPU.
    /// </summary>
    public Callback OnUploadCallback { get => JSRef!.Get<Callback>("onUploadCallback"); }

    /// <summary>
    /// Array of objects containing:
    /// start: Position at which to start update.
    /// count: The number of components to update.
    /// </summary>
    public JSObject UpdateRanges { get => JSRef!.Get<JSObject>("updateRanges"); set => JSRef!.Set("updateRanges", value); }

    /// <summary>
    /// A version number, incremented every time the needsUpdate property is set to true.
    /// </summary>
    public int Version { get => JSRef!.Get<int>("version"); set => JSRef!.Set("version", value); }

    /// <summary>
    /// Applies matrix m to every Vector3 element of this BufferAttribute.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>This</returns>
    public BufferAttribute ApplyMatrix3(Matrix3 matrix) => JSRef!.Call<BufferAttribute>("applyMatrix3", matrix);

    /// <summary>
    /// Applies matrix m to every Vector3 element of this BufferAttribute.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>This</returns>
    public BufferAttribute ApplyMatrix4(Matrix4 matrix) => JSRef!.Call<BufferAttribute>("applyMatrix4", matrix);

    /// <summary>
    /// Applies normal matrix m to every Vector3 element of this BufferAttribute.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>This</returns>
    public BufferAttribute ApplyNormalMatrix(Matrix3 matrix) => JSRef!.Call<BufferAttribute>("applyNormalMatrix", matrix);

    /// <summary>
    /// Applies matrix m to every Vector3 element of this BufferAttribute, interpreting the elements as a direction vectors.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>This</returns>
    public BufferAttribute TransformDirection(Matrix4 matrix) => JSRef!.Call<BufferAttribute>("transformDirection", matrix);

    /// <summary>
    /// Adds a range of data in the data array to be updated on the GPU. Adds an object describing the range to the updateRanges array.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <returns>This</returns>
    public BufferAttribute AddUpdateRange(int start, int count) => JSRef!.Call<BufferAttribute>("addUpdateRange", start, count);

    /// <summary>
    /// Clears the updateRanges array.
    /// </summary>
    /// <returns>This</returns>
    public BufferAttribute ClearUpdateRanges() => JSRef!.Call<BufferAttribute>("clearUpdateRanges");

    /// <summary>
    /// Return a copy of this bufferAttribute.
    /// </summary>
    /// <returns>New</returns>
    public BufferAttribute Clone() => JSRef!.Call<BufferAttribute>("clone");

    /// <summary>
    /// Copies another BufferAttribute to this BufferAttribute.
    /// </summary>
    /// <param name="attribute"></param>
    /// <returns>This</returns>
    public BufferAttribute Copy(BufferAttribute attribute) => JSRef!.Call<BufferAttribute>("clone", attribute);

    /// <summary>
    /// Copy the array given here (which can be a normal array or TypedArray) into array.
    /// See TypedArray.set for notes on requirements if copying a TypedArray.
    /// </summary>
    /// <param name="array"></param>
    /// <returns>This</returns>
    public BufferAttribute CopyArray(Union<Array, TypedArray> array) => JSRef!.Call<BufferAttribute>("copyArray", array);

    /// <summary>
    /// Copy a vector from bufferAttribute[index2] to array[index1].
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="bufferAttribute"></param>
    /// <param name="index2"></param>
    /// <returns>This</returns>
    public BufferAttribute CopyAt(int index1, BufferAttribute bufferAttribute, int index2) => JSRef!.Call<BufferAttribute>("copyAt", index1, bufferAttribute, index2);

    /// <summary>
    /// Returns the given component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <returns>Vector Component</returns>
    public Number GetComponent(int index, int component) => JSRef!.Call<Number>("getComponent", index, component);

    /// <summary>
    /// Returns the x component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <returns></returns>
    public Number GetX(int index) => JSRef!.Call<Number>("getX", index);

    /// <summary>
    /// Returns the y component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <returns></returns>
    public Number GetY(int index) => JSRef!.Call<Number>("getY", index);

    /// <summary>
    /// Returns the z component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <returns></returns>
    public Number GetZ(int index) => JSRef!.Call<Number>("getZ", index);

    /// <summary>
    /// Returns the w component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <returns></returns>
    public Number GetW(int index) => JSRef!.Call<Number>("getW", index);

    /// <summary>
    /// Sets the value of the onUploadCallback property.
    /// In the WebGL / Buffergeometry this is used to free memory after the buffer has been transferred to the GPU.
    /// </summary>
    public BufferAttribute OnUpload(Action action) => JSRef!.Call<BufferAttribute>("onUpload", Callback.Create(action));

    /// <summary>
    /// Calls TypedArray.set( value, offset ) on the array.
    /// In particular, see that page for requirements on value being a TypedArray.
    /// </summary>
    /// <param name="array">an Array or TypedArray from which to copy values.</param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public BufferAttribute Set(Union<Array,TypedArray> array, int offset = 0) => JSRef!.Call<BufferAttribute>("set", array, offset);

    /// <summary>
    /// Set usage to value. See usage constants for all possible input values.
    /// Note: After the initial use of a buffer, its usage cannot be changed. 
    /// Instead, instantiate a new one and set the desired usage before the next render.
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public BufferAttribute SetUsage(Usage usage) => JSRef!.Call<BufferAttribute>("setUsage", usage);

    /// <summary>
    /// Sets the given component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="component"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public Number SetComponent(int index, int component, float value) => JSRef!.Call<Number>("setComponent", index, component, value);

    /// <summary>
    /// Sets the x component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public BufferAttribute SetX(int index, float value) => JSRef!.Call<BufferAttribute>("setX", index, value);

    /// <summary>
    /// Sets the y component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public BufferAttribute SetY(int index, float value) => JSRef!.Call<BufferAttribute>("setY", index, value);

    /// <summary>
    /// Sets the z component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public BufferAttribute SetZ(int index, float value) => JSRef!.Call<BufferAttribute>("setZ", index, value);

    /// <summary>
    /// Sets the w component of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public BufferAttribute SetW(int index, float value) => JSRef!.Call<BufferAttribute>("setW", index, value);

    /// <summary>
    /// Sets the x and y components of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public BufferAttribute SetXY(int index, float x, float y) => JSRef!.Call<BufferAttribute>("setXY", index, x, y);

    /// <summary>
    /// Sets the x, y, and z components of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public BufferAttribute SetXYZ(int index, float x, float y, float z) => JSRef!.Call<BufferAttribute>("setXYZ", index, x, y, z);

    /// <summary>
    /// Sets the x, y, z and w components of the vector at the given index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    public BufferAttribute SetXYZW(int index, float x, float y, float z, float w) => JSRef!.Call<BufferAttribute>("setXYZW", index, x, y, z, w);

}