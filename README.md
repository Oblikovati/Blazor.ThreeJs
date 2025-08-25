# Blazor.ThreeJs

# Package in development, not ready for production!

## ThreeJs C# Bindings for Blazor 

The package releases are available at: [NuGet]

# Instalation

First add the references your index.html file in the header section:

```html
<head>
    <!-- your other html tags -->
    <script type="module" src="./_content/Blazor.ThreeJs/js/three.core.min.js"></script>
    <script type="module" src="./_content/Blazor.ThreeJs/js/three.module.min.js"></script>
</head>
```

Second you have to setup your project to use [SpawnDev.BlazorJS]

```csharp
// Program.cs

using SpawnDev.BlazorJS;

// Add SpawnDev.BlazorJS.BlazorJSRuntime
builder.Services.AddBlazorJSRuntime();

// build and Init using BlazorJSRunAsync (instead of RunAsync)
await builder.Build().BlazorJSRunAsync();
```

# Development

The package contains 3 Projects

- Blazor.ThreeJs: Our Package with the API and bindings to JavaScript.
- Blazor.ThreeJs.Tests: Our Unit Tests Definitions.
- Blazor.ThreeJs.Tests.Runtime: Run this project and will you be able to run all the tests in the blazor page.

The project relies on [SpawnDev.BlazorJS] for interop operations, all the bindinds are built on top of this library,
this library also supports bindings for all the browser apis.

# Governance

This package is mainained by [Vinicius Miguel]

We welcome PR's with API Improvements, Bug Fixes and Documentation.

# License

This source code is licensed under the MIT License

[NuGet]: https://www.nuget.org/packages/Blazor.ThreeJs
[SpawnDev.BlazorJS]: https://github.com/LostBeard/SpawnDev.BlazorJS
[Vinicius Miguel]: https://github.com/viniciusmiguel