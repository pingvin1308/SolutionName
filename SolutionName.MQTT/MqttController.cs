﻿using MQTTnet.Server;

internal sealed class MqttController
{
    public MqttController()
    {
        // Inject other services via constructor.
    }

    public Task OnClientConnected(ClientConnectedEventArgs eventArgs)
    {
        Console.WriteLine($"Client '{eventArgs.ClientId}' connected.");
        return Task.CompletedTask;
    }


    public Task ValidateConnection(ValidatingConnectionEventArgs eventArgs)
    {
        Console.WriteLine($"Client '{eventArgs.ClientId}' wants to connect. Accepting!");
        return Task.CompletedTask;
    }
}
