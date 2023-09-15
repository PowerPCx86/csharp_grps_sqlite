namespace ConsoleApp1;

using System;
using System.Threading.Tasks;
using Grpc.Core;
//using GrpcConsoleApp;

public class CalculatorService : Calculator.CalculatorBase
{
    public override Task<AddResponse> Add(AddRequest request, ServerCallContext context)
    {
        int result = request.Num1 + request.Num2;
        return Task.FromResult(new AddResponse { Result = result });
    }
}

public class CalculatorServer
{
    private readonly Server _server;

    public CalculatorServer()
    {
        _server = new Server
        {
            Services = { Calculator.BindService(new CalculatorService()) },
            Ports = { new ServerPort("195.168.20.130", 50051, ServerCredentials.Insecure) }
        };
    }

    public void Start()
    {
        _server.Start();
        Console.WriteLine("Server started on port 50051.");
    }

    public void Shutdown()
    {
        _server.ShutdownAsync().Wait();
    }
}
