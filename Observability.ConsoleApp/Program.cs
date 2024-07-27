// See https://aka.ms/new-console-template for more information

using Observability.ConsoleApp;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

Console.WriteLine("Hello, World!");

var traceProvider = Sdk.CreateTracerProviderBuilder()
    .ConfigureResource(configure =>
    {
        configure.AddService(OpenTelemetryConstants.ServiceName, OpenTelemetryConstants.ServiceVersion)
                 .AddAttributes(new List<KeyValuePair<string, object>>()
                 {
                     new KeyValuePair<string,object>("host.machineName",Environment.MachineName),
                     new KeyValuePair<string,object>("host.environment", "dev"),
                 });
    }).Build();