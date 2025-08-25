namespace Blazor.ThreeJs.Core;

/// <summary>
/// This is the base class for most objects in three.js and provides a set of properties and methods for manipulating objects in 3D space.
/// Note that this can be used for grouping objects via the .add( object ) method which adds the object as a child, however it is better to use Group for this. 
/// https://threejs.org/docs/?q=came#api/en/core/Object3D
/// </summary>
public class Object3D(IJSInProcessObjectReference _ref) : EventTarget(_ref)
{

    /// <summary>
    /// Whether the object gets rendered into shadow map.
    /// </summary>
    public bool CastShadow
    {
        get => JSRef!.Get<bool>("castShadow");
        set => JSRef!.Set("castShadow", value);
    }

    /// <summary>
    /// Array with object's children. See Group for info on manually grouping objects.
    /// </summary>
    public Array<Element> Children
    {
        get => JSRef!.Get<Array<Element>>("children");
        set => JSRef!.Set("children", value);
    }

    /// <summary>
    /// Custom depth material to be used when rendering to the depth map. 
    /// Can only be used in context of meshes. 
    /// When shadow-casting with a DirectionalLight or SpotLight, 
    /// if you are modifying vertex positions in the vertex shader you must specify a customDepthMaterial for proper shadows. 
    /// </summary>
    public Material.Material CustomDepthMaterial
    {
        get => JSRef!.Get<Material.Material>("customDepthMaterial");
        set => JSRef!.Set("customDepthMaterial ", value);
    }

    /// <summary>
    /// Same as customDepthMaterial, but used with PointLight.
    /// </summary>
    public Material.Material CustomDistanceMaterial
    {
        get => JSRef!.Get<Material.Material>("customDistanceMaterial");
        set => JSRef!.Set("customDistanceMaterial ", value);
    }

    /// <summary>
    /// When this is set, it checks every frame if the object is in the frustum of the camera before rendering the object. 
    /// If set to false the object gets rendered every frame even if it is not in the frustum of the camera.
    /// </summary>
    public bool FrustumCulled
    {
        get => JSRef!.Get<bool>("frustumCulled");
        set => JSRef!.Set("frustumCulled", value);
    }

    /// <summary>
    /// Unique number for this object instance.
    /// </summary>
    public int Id
    {
        get => JSRef!.Get<int>("id");
    }

    /// <summary>
    /// Unique number for this object instance.
    /// </summary>
    public bool IsObject3D
    {
        get => JSRef!.Get<bool>("isObject3D");
    }

    /// <summary>
    /// The layer membership of the object. 
    /// The object is only visible if it has at least one layer in common with the Camera in use. 
    /// This property can also be used to filter out unwanted objects in ray-intersection tests when using Raycaster. 
    /// </summary>
    public Layers Layers
    {
        get => JSRef!.Get<Layers>("layers");
        set => JSRef!.Set("layers", value);
    }

    /// <summary>
    /// The local transform matrix.
    /// </summary>
    public Matrix4 Matrix
    {
        get => JSRef!.Get<Matrix4>("matrix");
        set => JSRef!.Set("matrix", value);
    }

    /// <summary>
    /// When this is set, it calculates the matrix of position, (rotation or quaternion)
    /// and scale every frame and also recalculates the matrixWorld property. 
    /// Default is Object3D.DEFAULT_MATRIX_AUTO_UPDATE (true). 
    /// </summary>
    public bool MatrixAutoUpdate
    {
        get => JSRef!.Get<bool>("matrixAutoUpdate");
        set => JSRef!.Set("matrixAutoUpdate", value);
    }

    /// <summary>
    /// The global transform of the object. 
    /// If the Object3D has no parent, then it's identical to the local transform Matrix. 
    /// </summary>
    public Matrix4 matrixWorld
    {
        get => JSRef!.Get<Matrix4>("matrixWorld");
        set => JSRef!.Set("matrixWorld", value);
    }

    /// <summary>
    /// If set, then the renderer checks every frame if the object and its children need matrix updates. 
    /// When it isn't, then you have to maintain all matrices in the object and its children yourself. 
    /// Default is Object3D.DEFAULT_MATRIX_WORLD_AUTO_UPDATE (true). 
    /// </summary>
    public bool MatrixWorldAutoUpdate
    {
        get => JSRef!.Get<bool>("matrixWorldAutoUpdate");
        set => JSRef!.Set("matrixWorldAutoUpdate", value);
    }

    /// <summary>
    /// When this is set, it calculates the matrixWorld in that frame and resets this property to false. 
    /// Default is false. 
    /// </summary>
    public bool MatrixWorldNeedsUpdate
    {
        get => JSRef!.Get<bool>("matrixWorldNeedsUpdate");
        set => JSRef!.Set("matrixWorldNeedsUpdate", value);
    }

    /// <summary>
    /// This is passed to the shader and used to calculate the position of the object. 
    /// </summary>
    public Matrix4 ModelViewMatrix
    {
        get => JSRef!.Get<Matrix4>("modelViewMatrix");
        set => JSRef!.Set("modelViewMatrix", value);
    }

    /// <summary>
    /// Optional name of the object (doesn't need to be unique).
    /// Default is an empty string.
    /// </summary>
    public string Name
    {
        get => JSRef!.Get<string>("name");
        set => JSRef!.Set("name", value);
    }

    /// <summary>
    /// This is passed to the shader and used to calculate lighting for the object. 
    /// It is the transpose of the inverse of the upper left 3x3 sub-matrix of this object's modelViewMatrix.
    /// The reason for this special matrix is that simply using the modelViewMatrix could result in a non-unit length of normals 
    /// (on scaling) or in a non-perpendicular direction (on non-uniform scaling).
    /// On the other hand the translation part of the modelViewMatrix is not relevant for the calculation of normals. 
    /// Thus a Matrix3 is sufficient. 
    /// </summary>
    public Matrix3 NormalMatrix
    {
        get => JSRef!.Get<Matrix3>("normalMatrix");
        set => JSRef!.Set("normalMatrix", value);
    }

    /// <summary>
    /// An optional callback that is executed immediately after a 3D object is rendered. 
    /// This function is called with the following parameters: renderer, scene, camera, geometry, material, group. 
    /// Please notice that this callback is only executed for renderable 3D objects. 
    /// Meaning 3D objects which define their visual appearance with geometries and materials like instances of Mesh, Line, Points or Sprite. 
    /// Instances of Object3D, Group or Bone are not renderable and thus this callback is not executed for such objects. 
    /// </summary>
    public ActionEvent<OnAfterRenderEvent> OnAfterRender { get => new ActionEvent<OnAfterRenderEvent>("onAfterRender", AddEventListener, RemoveEventListener); set { } }

    /// <summary>
    /// An optional callback that is executed immediately after a 3D object is rendered to a shadow map. 
    /// This function is called with the following parameters: renderer, scene, camera, shadowCamera, geometry, depthMaterial, group. 
    /// Please notice that this callback is only executed for renderable 3D objects. 
    /// Meaning 3D objects which define their visual appearance with geometries and materials like instances of Mesh, Line, Points or Sprite. 
    /// Instances of Object3D, Group or Bone are not renderable and thus this callback is not executed for such objects. 
    /// </summary>
    public ActionEvent<OnAfterShadowEvent> OnAfterShadow { get => new ActionEvent<OnAfterShadowEvent>("onAfterShadow", AddEventListener, RemoveEventListener); set { } }

    /// <summary>
    /// An optional callback that is executed immediately before a 3D object is rendered. 
    /// This function is called with the following parameters: renderer, scene, camera, geometry, material, group. 
    /// Please notice that this callback is only executed for renderable 3D objects. 
    /// Meaning 3D objects which define their visual appearance with geometries and materials like instances of Mesh, Line, Points or Sprite. 
    /// Instances of Object3D, Group or Bone are not renderable and thus this callback is not executed for such objects. 
    /// </summary>
    public ActionEvent<OnBeforeRenderEvent> OnBeforeRender { get => new ActionEvent<OnBeforeRenderEvent>("onBeforeRender", AddEventListener, RemoveEventListener); set { } }

    /// <summary>
    /// An optional callback that is executed immediately before a 3D object is rendered to a shadow map.
    /// This function is called with the following parameters: renderer, scene, camera, shadowCamera, geometry, depthMaterial, group. 
    /// Please notice that this callback is only executed for renderable 3D objects.
    /// Meaning 3D objects which define their visual appearance with geometries and materials like instances of Mesh, Line, Points or Sprite.
    /// Instances of Object3D, Group or Bone are not renderable and thus this callback is not executed for such objects.
    /// </summary>
    public ActionEvent<OnBeforeShadowEvent> OnBeforeShadow { get => new ActionEvent<OnBeforeShadowEvent>("onBeforeShadow", AddEventListener, RemoveEventListener); set { } }

    public Object3D Parent
    {
        get => JSRef!.Get<Object3D>("parent");
        set => JSRef!.Set("parent", value);
    }

    /// <summary>
    /// A Vector3 representing the object's local position.
    /// </summary>
    public Vector3 Position
    {
        get => JSRef!.Get<Vector3>("position");
        set => JSRef!.Set("position", value);
    }

    /// <summary>
    /// Object's local rotation as a Quaternion.
    /// </summary>
    public Quaternion Quaternion
    {
        get => JSRef!.Get<Quaternion>("quaternion");
        set => JSRef!.Set("quaternion", value);
    }

    /// <summary>
    /// Whether the material receives shadows. Default is false.
    /// </summary>
    public bool ReceiveShadow
    {
        get => JSRef!.Get<bool>("receiveShadow");
        set => JSRef!.Set("receiveShadow", value);
    }

    /// <summary>
    /// This value allows the default rendering order of scene graph objects to be overridden although opaque and transparent objects remain sorted independently. 
    /// When this property is set for an instance of Group, all descendants objects will be sorted and rendered together. 
    /// Sorting is from lowest to highest renderOrder. Default value is 0.
    /// </summary>
    public double RenderOrder
    {
        get => JSRef!.Get<double>("renderOrder");
        set => JSRef!.Set("renderOrder", value);
    }

    /// <summary>
    /// Object's local rotation (see Euler angles), in radians. 
    /// </summary>
    public Vector3 Rotation
    {
        get => JSRef!.Get<Vector3>("rotation");
        set => JSRef!.Set("rotation", value);
    }

    /// <summary>
    /// The object's local scale. Default is Vector3( 1, 1, 1 ).
    /// </summary>
    public Vector3 Scale
    {
        get => JSRef!.Get<Vector3>("scale");
        set => JSRef!.Set("scale", value);
    }

    /// <summary>
    /// This is used by the lookAt method, for example, to determine the orientation of the result.
    /// Default is Object3D.DEFAULT_UP - that is, ( 0, 1, 0 ). 
    /// </summary>
    public Vector3 Up
    {
        get => JSRef!.Get<Vector3>("up");
        set => JSRef!.Set("up", value);
    }

    /// <summary>
    /// An object that can be used to store custom data about the Object3D.
    /// It should not hold references to functions as these will not be cloned. Default is an empty object {}. 
    /// </summary>
    public JSObject UserData
    {
        get => JSRef!.Get<JSObject>("userData");
        set => JSRef!.Set("userData", value);
    }

    /// <summary>
    /// UUID of this object instance. This gets automatically assigned, so this shouldn't be edited. 
    /// </summary>
    public string Uuid
    {
        get => JSRef!.Get<string>("uuid");
    }

    /// <summary>
    /// Object gets rendered if true. Default is true.
    /// </summary>
    public bool Visible
    {
        get => JSRef!.Get<bool>("visible");
        set => JSRef!.Set("visible", value);
    }

    /// <summary>
    /// Adds object as child of this object. 
    /// An arbitrary number of objects may be added. 
    /// Any current parent on an object passed in here will be removed, since an object can have at most one parent.
    /// </summary>
    /// <param name="object3D"></param>
    public Object3D Add(Object3D obj) => JSRef!.Call<Object3D>("add", obj);

    /// <summary>
    /// Applies the matrix transform to the object and updates the object's position, rotation and scale. 
    /// </summary>
    /// <param name="matrix"></param>
    public void ApplyMatrix4(Matrix4 matrix) => JSRef!.CallVoid("applyMatrix4", matrix);

    /// <summary>
    /// Applies the rotation represented by the quaternion to the object.
    /// </summary>
    /// <param name="quaternion"></param>
    /// <returns></returns>
    public Object3D ApplyQuaternion(Quaternion quaternion) => JSRef!.Call<Object3D>("applyQuaternion", quaternion);

    /// <summary>
    /// Adds object as a child of this, while maintaining the object's world transform.
    /// Note: This method does not support scene graphs having non-uniformly-scaled nodes(s).
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public Object3D Attach(Object3D obj) => JSRef!.Call<Object3D>("attach", obj);

    /// <summary>
    /// Removes all child objects.
    /// </summary>
    public void Clear() => JSRef!.CallVoid("clear");

    /// <summary>
    /// Returns a clone of this object and optionally all descendants. 
    /// recursive -- if true, descendants of the object are also cloned. Default is true.
    /// </summary>
    /// <returns></returns>
    public Object3D Clone(bool recursive) => JSRef!.Call<Object3D>("Clone", recursive);

    /// <summary>
    /// Copies the given object into this object. 
    /// Note: Event listeners and user-defined callbacks (.onAfterRender and .onBeforeRender) are not copied. 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="recursive"> If set to true, descendants of the object are copied next to the existing ones. 
    /// If set to false, descendants are left unchanged. Default is true.</param>
    /// <returns></returns>
    public Object3D Copy(Object3D obj, bool recursive) => JSRef!.Call<Object3D>("copy", obj, recursive);

    /// <summary>
    /// Searches through an object and its children, starting with the object itself, and returns the first with a matching id.
    /// Note that ids are assigned in chronological order: 1, 2, 3, ..., incrementing by one for each new object. 
    /// </summary>
    /// <param name="id">Unique number of the object instance</param>
    /// <returns></returns>
    public Object3D GetObjectById(int id) => JSRef!.Call<Object3D>("getObjectById", id);

    /// <summary>
    /// Searches through an object and its children, starting with the object itself, and returns the first with a matching name.
    /// Note that for most objects the name is an empty string by default. You will have to set it manually to make use of this method.
    /// </summary>
    /// <param name="name">String to match to the children's Object3D.name property. </param>
    /// <returns></returns>
    public Object3D GetObjectByName(string name) => JSRef!.Call<Object3D>("getObjectByProperty", name);

    /// <summary>
    /// Searches through an object and its children, starting with the object itself, and returns the first with a property that matches the value given. 
    /// </summary>
    /// <param name="name">The property name to search for.</param>
    /// <param name="any">Value of the given property.</param>
    /// <returns></returns>
    public Object3D GetObjectsByProperty(string name, object any) => JSRef!.Call<Object3D>("getObjectsByProperty", name, any);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">The property name to search for</param>
    /// <param name="any">Value of the given property</param>
    /// <param name="optionalTarget">Optional target to set the result. Otherwise a new Array is instantiated. 
    /// If set, you must clear this array prior to each call (i.e., array.length = 0;).</param>
    /// <returns></returns>
    public Object3D GetObjectsByProperty(string name, object any, SpawnDev.BlazorJS.JSObjects.Array optionalTarget)
        => JSRef!.Call<Object3D>("getObjectByName", name, any, optionalTarget);

    /// <summary>
    /// Returns a vector representing the position of the object in world space. 
    /// </summary>
    /// <param name="target">the result will be copied into this Vector3</param>
    /// <returns></returns>
    public Vector3 GetWorldPosition(Vector3 target) => JSRef!.Call<Vector3>("getWorldPosition", target);

    /// <summary>
    /// Returns a quaternion representing the rotation of the object in world space.
    /// </summary>
    /// <param name="target">the result will be copied into this Quaternion.</param>
    /// <returns></returns>
    public Quaternion GetWorldQuaternion(Quaternion target) => JSRef!.Call<Quaternion>("getWorldQuaternion", target);

    /// <summary>
    /// Returns a vector of the scaling factors applied to the object for each axis in world space.
    /// </summary>
    /// <param name="target">the result will be copied into this Vector3.</param>
    /// <returns></returns>
    public Vector3 GetWorldScale(Vector3 target) => JSRef!.Call<Vector3>("getWorldScale", target);

    /// <summary>
    /// Returns a vector representing the direction of object's positive z-axis in world space. 
    /// </summary>
    /// <param name="target">the result will be copied into this Vector3.</param>
    /// <returns></returns>
    public Vector3 GetWorldDirection(Vector3 target) => JSRef!.Call<Vector3>("getWorldDirection", target);

    /// <summary>
    /// Converts the vector from this object's local space to world space.
    /// </summary>
    /// <param name="target">the result will be copied into this Vector3.</param>
    /// <returns></returns>
    public Vector3 LocalToWorld(Vector3 target) => JSRef!.Call<Vector3>("localToWorld", target);

    /// <summary>
    /// Rotates the object to face a point in world space.
    /// This method does not support objects having non-uniformly-scaled parent(s). 
    /// </summary>
    /// <param name="target">A vector representing a position in world space.</param>
    public void LookAt(Vector3 target) => JSRef!.CallVoid("lookAt", target);

    /// <summary>
    /// Rotates the object to face a point in world space.
    /// This method does not support objects having non-uniformly-scaled parent(s). 
    /// </summary>
    public void LookAt(float x, float y, float z) => JSRef!.CallVoid("lookAt", x, y, z);

    /// <summary>
    /// Abstract (empty) method to get intersections between a casted ray and this object. 
    /// Subclasses such as Mesh, Line, and Points implement this method in order to use raycasting. 
    /// </summary>
    /// <param name="raycaster"></param>
    /// <param name="intersects"></param>
    public void Raycast(Raycaster raycaster, SpawnDev.BlazorJS.JSObjects.Array intersects) 
        => JSRef!.CallVoid("raycast", raycaster, intersects);

    /// <summary>
    /// Removes object as child of this object. An arbitrary number of objects may be removed.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>This</returns>
    public Object3D Remove(Object3D obj) => JSRef!.Call<Object3D>("remove", obj);

    /// <summary>
    /// Removes this object from its current parent.
    /// </summary>
    /// <returns>This</returns>
    public Object3D RemoveFromParent() => JSRef!.Call<Object3D>("removeFromParent");

    /// <summary>
    /// Rotate an object along an axis in object space. The axis is assumed to be normalized. 
    /// </summary>
    /// <param name="axis">A normalized vector in object space. </param>
    /// <param name="rad">The angle in radians.</param>
    /// <returns>This</returns>
    public Object3D RotateOnAxis(Vector3 axis, float rad) => JSRef!.Call<Object3D>("rotateOnAxis", axis, rad);

    /// <summary>
    /// Rotate an object along an axis in world space. The axis is assumed to be normalized. Method Assumes no rotated parent. 
    /// </summary>
    /// <param name="axis">A normalized vector in world space.</param>
    /// <param name="rad">The angle in radians.</param>
    /// <returns>This</returns>
    public Object3D RotateOnWorldAxis(Vector3 axis, float rad) => JSRef!.Call<Object3D>("rotateOnWorldAxis", axis, rad);

    /// <summary>
    /// Rotates the object around x axis in local space. 
    /// </summary>
    /// <param name="rad">the angle to rotate in radians.</param>
    /// <returns>This</returns>
    public Object3D RotateX(float rad) => JSRef!.Call<Object3D>("rotateX", rad);

    /// <summary>
    /// Rotates the object around y axis in local space. 
    /// </summary>
    /// <param name="rad">the angle to rotate in radians.</param>
    /// <returns>This</returns>
    public Object3D RotateY(float rad) => JSRef!.Call<Object3D>("rotateY", rad);

    /// <summary>
    /// Rotates the object around z axis in local space. 
    /// </summary>
    /// <param name="rad">the angle to rotate in radians.</param>
    /// <returns>This</returns>
    public Object3D RotateZ(float rad) => JSRef!.Call<Object3D>("rotateZ", rad);

    /// <summary>
    /// Calls setFromAxisAngle( axis, angle ) on the .quaternion. 
    /// </summary>
    /// <param name="axis">A normalized vector in object space.</param>
    /// <param name="rad">angle in radians</param>
    public void SetRotationFromAxisAngle(Vector3 axis, float rad) => JSRef!.CallVoid("setRotationFromAxisAngle", axis, rad);

    /// <summary>
    /// Calls setRotationFromEuler( euler) on the .quaternion. 
    /// </summary>
    /// <param name="euler">Euler angle specifying rotation amount.</param>
    public void SetRotationFromEuler(Euler euler) => JSRef!.CallVoid("setRotationFromEuler", euler);

    /// <summary>
    /// Calls setFromRotationMatrix( m) on the .quaternion.
    /// Note that this assumes that the upper 3x3 of m is a pure rotation matrix (i.e, unscaled). 
    /// </summary>
    /// <param name="matrix">rotate the quaternion by the rotation component of the matrix.</param>
    public void SetRotationFromMatrix(Matrix4 matrix) => JSRef!.CallVoid("setRotationFromMatrix", matrix);

    /// <summary>
    /// Copy the given quaternion into .quaternion. 
    /// </summary>
    /// <param name="quaternion">normalized Quaternion.</param>
    public void SetRotationFromQuaternion(Quaternion quaternion) => JSRef!.CallVoid("setRotationFromQuaternion", quaternion);

    /// <summary>
    /// Convert the object to three.js JSON Object/Scene format. 
    /// https://github.com/mrdoob/three.js/wiki/JSON-Object-Scene-format-4
    /// </summary>
    /// <param name="meta">object containing metadata such as materials, textures or images for the object</param>
    /// <returns>JSON Object/Scene format</returns>
    public JSObject ToJSON(JSObject meta) => JSRef!.Call<JSObject>("toJSON", meta);

    /// <summary>
    /// Translate an object by distance along an axis in object space. The axis is assumed to be normalized. 
    /// </summary>
    /// <param name="axis">A normalized vector in object space.</param>
    /// <param name="distance">The distance to translate.</param>
    /// <returns>This</returns>
    public Object3D TranslateOnAxis(Vector3 axis, float distance) => JSRef!.Call<Object3D>("translateOnAxis", axis, distance);

    /// <summary>
    /// Translates object along x axis in object space by distance units.
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public Object3D TranslateX(float distance) => JSRef!.Call<Object3D>("translateX", distance);

    /// <summary>
    /// Translates object along y axis in object space by distance units.
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public Object3D TranslateY(float distance) => JSRef!.Call<Object3D>("translateY", distance);

    /// <summary>
    /// Translates object along z axis in object space by distance units.
    /// </summary>
    /// <param name="distance"></param>
    /// <returns></returns>
    public Object3D TranslateZ(float distance) => JSRef!.Call<Object3D>("translateZ", distance);

    /// <summary>
    /// Executes the callback on this object and all descendants.
    /// Note: Modifying the scene graph inside the callback is discouraged.
    /// </summary>
    /// <param name="action">A function with as first argument an object3D objec</param>
    public void Transverse(Action<Object3D> action) => JSRef!.CallVoid("transverse", Callback.Create(action));

    /// <summary>
    /// Like traverse, but the callback will only be executed for visible objects. Descendants of invisible objects are not traversed.
    /// Note: Modifying the scene graph inside the callback is discouraged. 
    /// </summary>
    /// <param name="action">A function with as first argument an object3D objec</param>
    public void TransverseVisible(Action<Object3D> action) => JSRef!.CallVoid("transverseVisible", Callback.Create(action));

    /// <summary>
    /// Executes the callback on all ancestors.
    /// Note: Modifying the scene graph inside the callback is discouraged. 
    /// </summary>
    /// <param name="action">A function with as first argument an object3D objec</param>
    public void TransverseAncestors(Action<Object3D> action) => JSRef!.CallVoid("transverseAncestors", Callback.Create(action));

    /// <summary>
    /// Updates the local transform.
    /// </summary>
    public void UpdateMatrix() => JSRef!.CallVoid("updateMatrix");

    /// <summary>
    /// Updates the global transform of the object and its descendants if the world matrix needs update (.matrixWorldNeedsUpdate set to true) or if the force parameter is set to true. 
    /// </summary>
    /// <param name="force">A boolean that can be used to bypass .matrixWorldAutoUpdate, to recalculate the world matrix of the object and descendants on the current frame.
    /// Useful if you cannot wait for the renderer to update it on the next frame (assuming .matrixWorldAutoUpdate set to true).</param>
    public void UpdateMatrixWorld(bool force) => JSRef!.CallVoid("updateMatrixWorld", force);

    /// <summary>
    /// Updates the global transform of the object. 
    /// </summary>
    /// <param name="updateParents">recursively updates global transform of ancestors.</param>
    /// <param name="updateChildren">recursively updates global transform of descendants.</param>
    public void UpdateWorldMatrix(bool updateParents, bool updateChildren) => JSRef!.CallVoid("updateWorldMatrix", updateParents, updateChildren);

    /// <summary>
    /// Converts the vector from world space to this object's local space. 
    /// </summary>
    /// <param name="vector">A vector representing a position in world space.</param>
    /// <returns>A vector representing a position in local space.</returns>
    public Vector3 WorldToLocal(Vector3 vector) => JSRef!.Call<Vector3>("worldToLocal", vector);
}