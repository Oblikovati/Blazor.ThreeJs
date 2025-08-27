using System;
using System.Security.Cryptography;
using System.Threading.Channels;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace Blazor.ThreeJs.Geometry;

/// <summary>
/// A representation of mesh, line, or point geometry. Includes vertex positions, face indices,
/// normals, colors, UVs, and custom attributes within buffers, reducing the cost of passing all this data to the GPU.
/// https://threejs.org/docs/?q=CircleGeometry#api/en/core/BufferGeometry
/// </summary>
/// <param name="_ref"></param>
public class BufferGeometry(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{
    /// <summary>
    /// This hashmap has as id the name of the attribute to be set and as value the buffer to set it to.
    /// Rather than accessing this property directly, use .setAttribute and .getAttribute to access attributes of this geometry.
    /// </summary>
    public JSObject Attributes { get => JSRef!.Get<JSObject>("attributes"); set => JSRef!.Set("attributes", value); }

    /// <summary>
    /// Bounding box for the bufferGeometry, which can be calculated with .computeBoundingBox(). Default is null.
    /// </summary>
    public Box3 BoundingBox { get => JSRef!.Get<Box3>("boundingBox"); set => JSRef!.Set("boundingBox", value); }

    /// <summary>
    /// Bounding sphere for the bufferGeometry, which can be calculated with .computeBoundingSphere(). Default is null.
    /// </summary>
    public Sphere BoundingSphere { get => JSRef!.Get<Sphere>("boundingSphere"); set => JSRef!.Set("oundingSphere", value); }

    /// <summary>
    /// Determines the part of the geometry to render. This should not be set directly, instead use .setDrawRange. 
    /// Default is { start: 0, count: Infinity }
    /// For non-indexed BufferGeometry, count is the number of vertices to render. For indexed BufferGeometry, count is the number of indices to render.
    /// </summary>
    public JSObject DrawRange { get => JSRef!.Get<JSObject>("drawRange"); set => JSRef!.Set("drawRange", value); }

    /// <summary>
    /// Split the geometry into groups, each of which will be rendered in a separate WebGL draw call. This allows an array of materials to be used with the geometry.
    /// Each group is an object of the form: { start: Integer, count: Integer, materialIndex: Integer }
    /// where start specifies the first element in this draw call – the first vertex for non-indexed geometry, 
    /// otherwise the first triangle index. Count specifies how many vertices (or indices) are included, and materialIndex specifies the material array index to use.
    /// Use .addGroup to add groups, rather than modifying this array directly.
    /// Every vertex and index must belong to exactly one group — groups must not share vertices or indices, and must not leave vertices or indices unused.
    /// </summary>
    public Array Groups { get => JSRef!.Get<Array>("groups"); set => JSRef!.Set("groups", value); }

    /// <summary>
    /// Unique number for this bufferGeometry instance.
    /// </summary>
    public int Id { get => JSRef!.Get<int>("id"); set => JSRef!.Set("id", value); }

    /// <summary>
    /// Allows for vertices to be re-used across multiple triangles; this is called using "indexed triangles". 
    /// Each triangle is associated with the indices of three vertices. This attribute therefore stores the index of each vertex for each triangular face. 
    /// If this attribute is not set, the renderer assumes that each three contiguous positions represent a single triangle. Default is null.
    /// </summary>
    public BufferAttribute Index { get => JSRef!.Get<BufferAttribute>("index"); set => JSRef!.Set("index", value); }

    /// <summary>
    /// Read-only flag to check if a given object is of type BufferGeometry.
    /// </summary>
    public bool IsBufferGeometry { get => JSRef!.Get<bool>("isBufferGeometry"); set => JSRef!.Set("isBufferGeometry", value); }

    /// <summary>
    /// Hashmap of BufferAttributes holding details of the geometry's morph targets.
    /// Note: Once the geometry has been rendered, the morph attribute data cannot be changed.You will have to call .dispose(), and create a new instance of BufferGeometry.
    /// </summary>
    public JSObject MorphAttributes { get => JSRef!.Get<JSObject>("morphAttributes"); set => JSRef!.Set("morphAttributes", value); }

    /// <summary>
    /// Used to control the morph target behavior; when set to true, the morph target data is treated as relative offsets, rather than as absolute positions/normals. Default is false.
    /// </summary>
    public bool MorphTargetsRelative { get => JSRef!.Get<bool>("morphTargetsRelative"); set => JSRef!.Set("morphTargetsRelative", value); }

    /// <summary>
    /// Optional name for this bufferGeometry instance. Default is an empty string.
    /// </summary>
    public string Name { get => JSRef!.Get<string>("name"); set => JSRef!.Set("name", value); }

    public JSObject UserData { get => JSRef!.Get<JSObject>("userData"); set => JSRef!.Set("userData", value); }

    /// <summary>
    /// UUID of this object instance. This gets automatically assigned and shouldn't be edited.
    /// </summary>
    public string Uuid { get => JSRef!.Get<string>("uuid"); set => JSRef!.Set("uuid", value); }

    /// <summary>
    /// Adds a group to this geometry; see the groups property for details.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="count"></param>
    /// <param name="materialIndex"></param>
    public void AddGroup(int start, int count, int materialIndex) => JSRef!.CallVoid("addGroup", start, count, materialIndex);

    /// <summary>
    /// Applies the matrix transform to the geometry.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns>This</returns>
    public BufferGeometry ApplyMatrix4(Matrix4 matrix) => JSRef!.Call<BufferGeometry>("applyMatrix4", matrix);

    /// <summary>
    /// Applies the rotation represented by the quaternion to the geometry.
    /// </summary>
    /// <param name="quaternion"></param>
    /// <returns>This</returns>
    public BufferGeometry ApplyQuaternion(Quaternion quaternion) => JSRef!.Call<BufferGeometry>("applyQuaternion", quaternion);

    /// <summary>
    /// Center the geometry based on the bounding box.
    /// </summary>
    /// <returns>This</returns>
    public BufferGeometry Center() => JSRef!.Call<BufferGeometry>("center");

    /// <summary>
    /// Clears all groups.
    /// </summary>
    public void ClearGroups() => JSRef!.CallVoid("clearGroups");

    /// <summary>
    /// Creates a clone of this BufferGeometry.
    /// </summary>
    /// <returns>New</returns>
    public BufferGeometry Clone() => JSRef!.Call<BufferGeometry>("clone");

    /// <summary>
    /// Computes the bounding box of the geometry, and updates the .boundingBox attribute. 
    /// The bounding box is not computed by the engine; it must be computed by your app. Y
    /// ou may need to recompute the bounding box if the geometry vertices are modified.
    /// </summary>
    public void ComputeBoundingBox() => JSRef!.CallVoid("computeBoundingBox");

    /// <summary>
    /// Computes the bounding sphere of the geometry, and updates the .boundingSphere attribute. 
    /// The engine automatically computes the bounding sphere when it is needed, e.g., for ray casting or view frustum culling. 
    /// You may need to recompute the bounding sphere if the geometry vertices are modified.
    /// </summary>
    public void ComputeBoundingSphere() => JSRef!.CallVoid("computeBoundingSphere");

    /// <summary>
    /// Calculates and adds a tangent attribute to this geometry.
    /// The computation is only supported for indexed geometries and if position, normal, and uv attributes are defined.
    /// When using a tangent space normal map, prefer the MikkTSpace algorithm provided by BufferGeometryUtils.computeMikkTSpaceTangents instead.
    /// </summary>
    public void ComputeTangents() => JSRef!.CallVoid("computeTangents");

    /// <summary>
    /// Computes vertex normals for the given vertex data. For indexed geometries, the method sets each vertex normal to be the average
    /// of the face normals of the faces that share that vertex. For non-indexed geometries, vertices are not shared, 
    /// and the method sets each vertex normal to be the same as the face normal.
    /// </summary>
    public void ComputeVertexNormals() => JSRef!.CallVoid("computeVertexNormals");

    /// <summary>
    /// Copies another BufferGeometry to this BufferGeometry.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public BufferGeometry Copy(BufferGeometry source) => JSRef!.Call<BufferGeometry>("copy", source);

    /// <summary>
    /// Deletes the attribute with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public BufferAttribute DeleteAttribute(string name) => JSRef!.Call<BufferAttribute>("deleteAttribute", name);

    /// <summary>
    /// Returns the attribute with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public BufferAttribute GetAttribute(string name) => JSRef!.Call<BufferAttribute>("getAttribute", name);

    /// <summary>
    /// Return the .index buffer.
    /// </summary>
    /// <returns></returns>
    public BufferAttribute GetIndex() => JSRef!.Call<BufferAttribute>("getIndex");

    /// <summary>
    /// Returns true if the attribute with the specified name exists.
    /// </summary>
    public bool HasAttribute { get => JSRef!.Get<bool>("hasAttribute"); set => JSRef!.Set("hasAttribute", value); }

    /// <summary>
    /// A world vector to look at.
    /// </summary>
    /// <param name="vector">This</param>
    /// <returns>This</returns>
    public BufferGeometry LookAt(Vector3 vector) => JSRef!.Call<BufferGeometry>("lookAt", vector);

    /// <summary>
    /// Rotates the geometry to face a point in space. This is typically done as a one time operation, and not during a loop. 
    /// Use Object3D.lookAt for typical real-time mesh usage.
    /// </summary>
    public void NormalizeNormals() => JSRef!.CallVoid("normalizeNormals");

    /// <summary>
    /// Rotate the geometry about the X axis. This is typically done as a one time operation, and not during a loop. Use Object3D.rotation for typical real-time mesh rotation.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>This</returns>
    public BufferGeometry RotateX(float radians) => JSRef!.Call<BufferGeometry>("rotateX", radians);

    /// <summary>
    /// Rotate the geometry about the Y axis. This is typically done as a one time operation, and not during a loop. Use Object3D.rotation for typical real-time mesh rotation.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>This</returns>
    public BufferGeometry RotateY(float radians) => JSRef!.Call<BufferGeometry>("rotateY", radians);

    /// <summary>
    /// Rotate the geometry about the Z axis. This is typically done as a one time operation, and not during a loop. Use Object3D.rotation for typical real-time mesh rotation.
    /// </summary>
    /// <param name="radians"></param>
    /// <returns>This</returns>
    public BufferGeometry RotateZ(float radians) => JSRef!.Call<BufferGeometry>("rotateZ", radians);

    /// <summary>
    /// Scale the geometry data. This is typically done as a one time operation, and not during a loop. 
    /// Use Object3D.scale for typical real-time mesh scaling.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns>This</returns>
    public BufferGeometry Scale(float x, float y, float z) => JSRef!.Call<BufferGeometry>("scale", x, y, z);

    /// <summary>
    /// Sets an attribute to this geometry. Use this rather than the attributes property, because an internal hashmap of .attributes is maintained to speed up iterating over attributes.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="attribute"></param>
    /// <returns>This</returns>
    public BufferAttribute SetAttribute(string name, BufferAttribute attribute) => JSRef!.Call<BufferAttribute>("setAttribute", name, attribute);

    /// <summary>
    /// Set the .drawRange property. For non-indexed BufferGeometry, count is the number of vertices to render. 
    /// For indexed BufferGeometry, count is the number of indices to render.
    /// </summary>
    /// <param name="start"></param>
    /// <param name="count"></param>
    public void SetDrawRange(int start, int count) => JSRef!.CallVoid("setDrawRange", start, count);

    /// <summary>
    /// Defines a geometry by creating a position attribute based on the given array of points. The array can hold instances of Vector2 or Vector3. 
    /// When using two-dimensional data, the z coordinate for all vertices is set to 0.
    /// If the method is used with an existing position attribute, the vertex data are overwritten with the data from the array. 
    /// The length of the array must match the vertex count.
    /// </summary>
    /// <param name="points"></param>
    /// <returns></returns>
    public BufferGeometry SetFromPoints(Array<Vector3> points) => JSRef!.Call<BufferGeometry>("setFromPoints", points);

    /// <summary>
    /// Set the .index buffer.
    /// </summary>
    /// <param name="index"></param>
    /// <returns>This</returns>
    public BufferGeometry SetIndex(BufferAttribute index) => JSRef!.Call<BufferGeometry>("setIndex", index);

    /// <summary>
    /// Convert the buffer geometry to three.js JSON Object/Scene format.
    /// </summary>
    /// <returns>JSON</returns>
    public JSObject ToJSON() => JSRef!.Call<JSObject>("toJSON");

    /// <summary>
    /// 
    /// </summary>
    /// <returns>This</returns>
    public BufferGeometry ToNonIndexed() => JSRef!.Call<BufferGeometry>("toNonIndexed");

    /// <summary>
    /// Translate the geometry. This is typically done as a one time operation, and not during a loop.
    /// Use Object3D.position for typical real-time mesh translation.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    /// <returns></returns>
    public BufferGeometry Translate(float x, float y, float z) => JSRef!.Call<BufferGeometry>("translate", x, y, z);
}