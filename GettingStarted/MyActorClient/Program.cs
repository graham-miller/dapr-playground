using System;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Client;
using MyActor.Interfaces;

namespace MyActorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await InvokeActorMethodWithRemotingAsync(new ActorId("Actor ID 1"));
            await InvokeActorMethodWithRemotingAsync(new ActorId("Actor ID 2"));
        }

        static async Task InvokeActorMethodWithRemotingAsync(ActorId actorId)
        {
            Console.WriteLine($"Actor ID: {actorId.GetId()}");
            
            var actorType = "MyActor"; // Registered Actor Type in Actor Service

            // Create the local proxy by using the same interface that the service implements
            // By using this proxy, you can call strongly typed methods on the interface using Remoting.
            var proxy = ActorProxy.Create<IMyActor>(actorId, actorType);
            var response = await proxy.SetDataAsync(new MyData()
            {
                PropertyA = "ValueA",
                PropertyB = "ValueB",
            });
            Console.WriteLine($"Response was: '{response}'");

            var savedData = await proxy.GetDataAsync();
            Console.WriteLine($"Saved data was: {savedData}");
            Console.WriteLine();
        }
    }
}
