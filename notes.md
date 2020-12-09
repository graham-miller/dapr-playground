## Prerequistes
* .Net Core SDK 3.0 (https://dotnet.microsoft.com/download)
* Dapr CLI (https://github.com/dapr/cli)
* Dapr DotNet SDK (https://github.com/dapr/dotnet-sdk)

## Getting started

https://github.com/dapr/dotnet-sdk/blob/master/docs/get-started-dapr-actor.md

## Run ActorService

> dapr init

> cd C:\Dev\repos\dapr-playground\GettingStarted\MyActorService

> dapr run --app-id myapp --app-port 3000 --dapr-http-port 3500 dotnet run