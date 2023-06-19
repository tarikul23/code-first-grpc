using Gprc.Product.Services;
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


var app = builder.Build();

app.MapGrpcService<ProductService>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/order", async (List<string> names) =>
{
    using var channel = GrpcChannel.ForAddress("https://localhost:7044");
    var client = channel.CreateGrpcService<IOrderService>();
    IList<string> iLIst = names;
    IEnumerable<string> iEnumerable = names;
    var reply = await client.OrderAsync(
        new OrderRequest { NameList = names, NameIlist = iLIst, NameIEnumerable = iEnumerable });
    return reply;
});

app.MapGet("/generic", async (string param) =>
{
    using var channel = GrpcChannel.ForAddress("https://localhost:7044");
    var client = channel.CreateGrpcService<IOrderService>();
    var reply = await client.GetMyData(param);
    return reply;
});

app.MapGet("/get-page", async (string param) =>
{
    using var channel = GrpcChannel.ForAddress("https://localhost:7044");
    var client = channel.CreateGrpcService<IOrderService>();
    var reply = await client.GetPagination(param);
    return reply;
});

app.Run();

