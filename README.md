# Blazor.ThreeJs

# Package in development, not ready for production!

## ThreeJs C# Bindings for Blazor 

The package releases are available at: [NuGet]

# Instalation

First add the references your index.html file in the header section:

```html
<head>
    <!-- your other html tags -->
    <script type="module" src="./_content/Blazor.ThreeJs/js/three.core.js"></script>    
    <script type="module" src="./_content/Blazor.ThreeJs/js/interop.js"></script>
</head>
```

Second you have to setup your project with the proper dependant services.

```csharp
// Program.cs

using SpawnDev.BlazorJS;
using Blazor.ThreeJs;

// Register the following services
builder.Services.AddBlazorJSRuntime();
builder.Services.AddThreeJs();

// Replace RunAsync with BlazorJSRunAsync
await builder.Build().BlazorJSRunAsync();
```

# Usage

This example creates a canvas and shows a rotating cube.

```csharp
// Page.razor
@using SpawnDev.BlazorJS
@using Blazor.ThreeJs

@inject THREE THREE
@inject BlazorJSRuntime JS

<!-- Your Page Code -->

@code {
    private WebGLRenderer.WebGLRenderer? _renderer;
    private Scene.Scene? _scene;
    private Camera.Camera? _camera;
    private Mesh.Mesh? _cube;

    protected override void OnAfterRender(bool firstRender)
    {

        if (firstRender)
        {
            var window = JS.GetWindow();
            var document = JS.GetDocument();

            if (window is null || document is null) return;

            _scene = THREE.Scene();

            _camera = THREE.PerspectiveCamera(75, window.InnerWidth / window.InnerHeight, 0.1, 1000);

            _renderer = THREE.WebGLRenderer();
            _renderer.SetClearColor(0x333333);
            _renderer.SetSize(window.InnerWidth, window.InnerHeight);
            _renderer.SetAnimationLoop(Animate);

            document.Body?.AppendChild(_renderer.DomElement);

            var geometry = THREE.BoxGeometry(1, 1, 1);
            var material = THREE.MeshBasicMaterial( new Material.MeshBasicMaterialParameters { Color = 0x00ff00 } );
            _cube = THREE.Mesh(geometry, material);
            _scene.Add(_cube);

            _camera.Position.Z = 3;
        }
    }

    private void Animate()
    {
        if (_scene is null || _camera is null || _cube is null) return;

        _cube.Rotation.X += 0.01f;
        _cube.Rotation.Y += 0.01f;
        _renderer?.Render(_scene, _camera);
    }
}

```

# Development

The package contains 3 Projects

- Blazor.ThreeJs: Our Package with the API and bindings to JavaScript.
- Blazor.ThreeJs.Tests: Our Unit Tests Definitions.
- Blazor.ThreeJs.Tests.Runtime: Run this project and will you be able to run all the tests in the blazor page.

The project relies on [SpawnDev.BlazorJS] for interop operations, all the bindings are built on top of this library,
this library also supports bindings for all the browser apis.

# Governance

This package is mainained by [Vinicius Miguel]

We welcome PR's with API Improvements, Bug Fixes and Documentation.

# License

This source code is licensed under the MIT License

[NuGet]: https://www.nuget.org/packages/Blazor.ThreeJs
[SpawnDev.BlazorJS]: https://github.com/LostBeard/SpawnDev.BlazorJS
[Vinicius Miguel]: https://github.com/viniciusmiguel