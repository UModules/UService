# UService 🚀
UService is a lightweight service locator utility for Unity, designed to manage and retrieve service instances efficiently. The tool allows for the easy registration, retrieval, and management of services, including `MonoBehaviour` services which must be attached to `GameObject`.

## Features ✨
* 🔧 **Service Registration:** Register services either by providing an instance or through lazy instantiation.
* 🎮 **MonoBehaviour Management:** Handles `MonoBehaviour` services by attaching them to Unity `GameObjects`.
* 🔍 **Service Retrieval:** Retrieve registered services with lazy instantiation.
* 🧹 **Unregister Services:** Clean up services when they are no longer needed.

## Installation 📦
* Clone or download the repository.
* Add the `ServiceLocator` script to your Unity project.
* Make sure the namespace `UService` is referenced in your code.
  
## Usage 🚀
### Registering a Service 🛠️
To register an existing instance of a service:
```C#
ServiceLocator.RegisterService<IService>(myServiceInstance);
```
For lazy instantiation:
```C#
ServiceLocator.RegisterService<IService>();
```

### Retrieving a Service 🔍
```C#
var myService = ServiceLocator.GetService<IService>();
```

### Unregistering a Service 🧹
```C#
ServiceLocator.UnregisterService<IService>();
```
## Example 💡
Here is a simple usage example:
```C#
// Register a new service
ServiceLocator.RegisterService<MyService>();

// Retrieve the registered service
MyService service = ServiceLocator.GetService<MyService>();

// Unregister the service when it's no longer needed
ServiceLocator.UnregisterService<MyService>();
```

## License 📄
This project is licensed under the MIT License. See the [LICENSE](https://github.com/UModules/UService/blob/main/LICENSE) file for details.

## Contributing 🤝
Contributions are welcome! Please submit a pull request or open an issue for discussion.
