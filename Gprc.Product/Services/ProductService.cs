using Gprc.Shared;
using ProtoBuf.Grpc;

namespace Gprc.Product.Services
{
    public class ProductService : IProductService
    {

        public Task<ProductReply> ProductAsync(ProductRequest request, CallContext context = default)
        {
            return Task.FromResult(
                    new ProductReply
                    {
                        Name = $"Hello Product : {request.Name}"
                    });
        }
    }

}
