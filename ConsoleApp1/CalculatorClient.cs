namespace ConsoleApp1;

using System.Threading.Tasks;
using Grpc.Core;

public class CalculatorClient
{
    private readonly Calculator.CalculatorClient _client;

    public CalculatorClient(Channel channel)
    {
        _client = new Calculator.CalculatorClient(channel);
    }

    public async Task<int> Add(int num1, int num2)
    {
        var request = new AddRequest { Num1 = num1, Num2 = num2 };
        var response = await _client.AddAsync(request);
        return response.Result;
    }
}
