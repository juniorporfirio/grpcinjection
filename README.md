# Grpc Injection
A Source Generator package for C#, that allow you to generate Grpc Services and Interceptors dependencies without Reflection.
<!-- [![Nuget count](https://img.shields.io/nuget/v/grpcinjection.svg)](https://www.nuget.org/packages/grpcinjection/) -->

[![Build](https://github.com/juniorporfirio/grpcinjection/actions/workflows/dotnet.yml/badge.svg)](https://github.com/juniorporfirio/grpcinjection/actions/workflows/dotnet.yml) [![License](https://img.shields.io/github/license/juniorporfirio/grpcinjection.svg)](https://github.com/giggio/grpcinjection/blob/master/LICENSE.txt)


## Installing
The package is available ([on NuGet](https://www.nuget.org/packages/grpcinjection).
To install from the command line:

```shell
dotnet add package grpcinjection --prerelease
```

Or use the Package Manager in Visual Studio.


## Setup Service Provider
Only add in your Startup or Program for use this package, like so:
```csharp
   public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpcInject();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseGrpcInject();
        }
```

## Inject one Service Grpc
Only add an attribute to the classes Grpc Service that you want injected in your service provider, like so:

```csharp

    [GrpcService]
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
```

## Inject one Interceptor Grpc
Only add an attribute to the classes Grpc Interceptors that you want injected in your service provider, like so:

```csharp

    [GrpcInterceptor]
    public class LogInterceptor : Interceptor
    {
        private readonly ILogger<LogInterceptor> _logger;
        public LogInterceptor(ILogger<LogInterceptor> logger) => _logger = logger;

    }
```
## Contributing

The main supported IDE for development is Visual Studio 2022.

Questions, comments, bug reports, and pull requests are all welcome.
Bug reports that include steps to reproduce (including code) are
preferred. Even better, make them in the form of pull requests.
Before you start to work on an existing issue, check if it is not assigned
to anyone yet, and if it is, talk to that person.

## Maintainers/Core team

-   [Júnior Porfirio](http://juniorporfirio.medium.com/), aka JP,
    [@juniorporfirio](https://twitter.com/juniorporfirio)

Contributors can be found at the [contributors](https://github.com/juniorporfirio/grpcinjection/graphs/contributors) page on Github.

## License

This software is open source, licensed under the MIT License.
See [LICENSE](https://github.com/juniorporfirio/grpcinjection/blob/master/LICENSE) for details.
Check out the terms of the license before you contribute, fork, copy or do anything
with the code. If you decide to contribute you agree to grant copyright of all your contribution to this project and agree to
mention clearly if do not agree to these terms. Your work will be licensed with the project at MIT, along the rest of the code.


 
