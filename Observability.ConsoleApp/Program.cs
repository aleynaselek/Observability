﻿// See https://aka.ms/new-console-template for more information

using Observability.ConsoleApp;
using OpenTelemetry;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

Console.WriteLine("Hello, World!");

var traceProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(OpenTelemetryConstants.ActivitySourceName) 
    .ConfigureResource(configure =>
    {
        configure.AddService(OpenTelemetryConstants.ServiceName,serviceVersion: OpenTelemetryConstants.ServiceVersion)
                 .AddAttributes(new List<KeyValuePair<string, object>>()
                 {
                     new KeyValuePair<string,object>("host.machineName",Environment.MachineName),
                     new KeyValuePair<string,object>("host.environment", "dev"),
                 });
    }).AddConsoleExporter().Build();

var serviceHelper = new ServiceHelper();

await serviceHelper.Work1();