namespace mickion.tuckshops.warehouse.domain.Contracts.Repositories
{
    public interface IPagedList<T> : IList<T>
    {
        public int TotalCount { get; }
        public int PageCount { get; }
        public int PageNo { get; }
        public int PageSize { get; }
    }
}
