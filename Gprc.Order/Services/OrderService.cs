using Gprc.Shared;
using ProtoBuf.Grpc;

namespace Gprc.Order.Services
{
    public class OrderService : IOrderService
    {
        public ValueTask<MyGenericClass> GetMyData(string data, CallContext context = default)
        {
            return new ValueTask<MyGenericClass>(new MyGenericClass { Data = data });
        }

        public Task<OrderReply> OrderAsync(OrderRequest request, CallContext context = default)
        {

            return Task.FromResult(
                    new OrderReply
                    {
                        NameList = request.NameList,
                        NameIlist = request.NameIlist,
                        NameIEnumerable = request.NameIEnumerable,
                    });
        }

        public async Task<PagedList<MyMessage>> GetPagination(string message, CallContext context)
        {
            var pagination = new PagedList<MyMessage>()
            {
                Data = new List<MyMessage> { new MyMessage { Message = message } },
                TotalPages = 1,
                PageIndex = 1,
                PageSize = 10,
                TotalCount = 1
            };
            return await Task.FromResult(pagination);
        }
    }

}
