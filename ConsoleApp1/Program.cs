using ConsoleApp1;
using Grpc.Core;

class Program
{
    static void Main(string[] args)
    {
        const string host = "localhost";
        const int port = 50051;

        var server = new CalculatorServer();
        server.Start();

        var channel = new Channel($"{host}:{port}", ChannelCredentials.Insecure);
        var client = new CalculatorClient(channel);

        var num1 = 10;
        var num2 = 20;
        var result = client.Add(num1, num2).Result;

        Console.WriteLine($"Result of {num1} + {num2} = {result}");

        Console.WriteLine("Press any key to stop the server...");
        Console.ReadKey();
    }
}

