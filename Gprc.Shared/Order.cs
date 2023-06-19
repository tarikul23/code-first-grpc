using ProtoBuf;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace Gprc.Shared
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class OrderReply
    {
        public List<string>? NameList { get; set; }
        public IList<string>? NameIlist { get; set; }
        public IEnumerable<string>? NameIEnumerable { get; set; }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class OrderRequest
    {
        public List<string>? NameList { get; set; }
        public IList<string>? NameIlist { get; set; }
        public IEnumerable<string>? NameIEnumerable { get; set; }
    }

    [ProtoContract]
    public class MyGenericClass
    {
        [ProtoMember(1)]
        public string? Data { get; set; }
    }

    [ProtoContract]
    public class MyMessage
    {
        [ProtoMember(1)]
        public string? Message { get; set; }
    }


    [Service]
    public interface IOrderService : IGeneric<MyGenericClass>, IPageList<PagedList<MyMessage>>
    {
        Task<OrderReply> OrderAsync(OrderRequest request, CallContext context = default);
    }

    [Service]
    public interface IGeneric<T> where T : class
    {
        public ValueTask<T> GetMyData(string data, CallContext context = default);
    }

    



}