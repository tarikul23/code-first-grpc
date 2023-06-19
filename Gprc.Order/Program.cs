using Gprc.Order.Services;
using Gprc.Shared;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCodeFirstGrpc();

using var channel = GrpcChannel.ForAddress("https://localhost:7206");
var data =  channel.CreateGrpcService<IProductService>();
builder.Services.AddSingleton<IProductService>(data);


var app = builder.Build();

app.MapGrpcService<OrderService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/product", async (string productName, IProductService productService) =>
{
    using var channel = GrpcChannel.ForAddress("https://localhost:7206");
    var client = channel.CreateGrpcService<IProductService>();

    var reply = await productService.ProductAsync(
        new ProductRequest { Name = $"{productName} The product is request from Oerder.Api" });
    return reply.Name;
});

app.Run();
