using ConsoleApp1;
using Grpc.Core;

class Program
{
    static void Main(string[] args)
    {
        start_server();
        start_client();
        Console.WriteLine("press any key to quit...");
        Console.ReadKey();
    }

    static void start_server()
    {
        Console.WriteLine("starting server");
        
        var server = new CalculatorServer();
        server.Start();
        
    }

    static void start_client()
    {
        Console.WriteLine("starting client");
        
        const string server_ip = "195.168.20.130";
        const int port = 50051;
        
        var channel = new Channel($"{server_ip}:{port}", ChannelCredentials.Insecure);
        var client = new CalculatorClient(channel);

        var num1 = 10;
        var num2 = 20;
        var result = client.Add(num1, num2).Result;

        Console.WriteLine($"Result of {num1} + {num2} = {result}");
    }
}

