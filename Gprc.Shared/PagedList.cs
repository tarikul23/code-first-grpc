using ProtoBuf;

namespace Gprc.Shared
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    public class PagedList<T>
    {
        public List<T>? Data { get; set; }
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }
    }
}
