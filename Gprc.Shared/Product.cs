using ProtoBuf;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Gprc.Shared
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class ProductReply 
    {
        public string? Name { get; set; }
    }
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class ProductRequest 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    [Service]
    public interface IProductService
    {
        Task<ProductReply> ProductAsync(ProductRequest request, CallContext context = default);
    }
}