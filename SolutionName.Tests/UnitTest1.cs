using MQTTnet;
using MQTTnet.Client;
using Xunit.Abstractions;

namespace SolutionName.Tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper outputHelper;

        public UnitTest1(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Fact]
        public async Task Test1()
        {
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer("127.0.0.1").Build();

                try
                {
                    using (var timeoutToken = new CancellationTokenSource(TimeSpan.FromSeconds(5)))
                    {
                        await mqttClient.ConnectAsync(mqttClientOptions, timeoutToken.Token);
                    }
                }
                catch (OperationCanceledException)
                {
                    Assert.Fail("Timeout while connecting.");
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.ToString());
                }
            }
        }
    }
}