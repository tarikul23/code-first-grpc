using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Grpc;

namespace Gprc.Shared
{
    [Service]
    public interface IPageList<T> where T : class
    {
        public Task<T> GetPagination(string message, CallContext context = default);
    }
}
