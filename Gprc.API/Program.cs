using Gprc.Shared;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.ClientFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCodeFirstGrpcClient<IProductService>(o => {

    // Address of grpc server
    //o.Address = new Uri(Configuration.GetValue<string>("https://localhost:5001"));
    o.Address = new Uri("https://localhost:7206");

    //o.ChannelOptionsActions.Add(options =>
    //{
    //    options.HttpHandler = new SocketsHttpHandler()
    //    {
    //        // keeps connection alive
    //        PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
    //        KeepAlivePingDelay = TimeSpan.FromSeconds(60),
    //        KeepAlivePingTimeout = TimeSpan.FromSeconds(30),

    //        // allows channel to add additional HTTP/2 connections
    //        EnableMultipleHttp2Connections = true
    //    };
    //});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/product", async (string productName, IProductService productService) =>
{

    var reply = await productService.ProductAsync(
        new ProductRequest { Name = $"{productName} The product is request from Api" });
    return reply.Name;
});

app.MapGet("/order", async (string orderName, IConfiguration config) =>
{
    //using var channel = GrpcChannel.ForAddress(config.GetServiceUri("gprc-order"));
    //using var channel = GrpcChannel.ForAddress("https://localhost:7044");
    //var client = channel.CreateGrpcService<IOrderService>();
    //var heades = new Metadata();
    //heades.Add("user", "Tarikul");
    //var options = new CallOptions(heades);
    //var headers = new Metadata();
    ////options.Headers.Add("Authorization", $"Bearer ");

    //var reply = await client.OrderAsync(
    //    new OrderRequest { Name = $"{orderName} The Order is request from Api" }, options);
    //return reply.Name;
    return "";
});

app.Run();


