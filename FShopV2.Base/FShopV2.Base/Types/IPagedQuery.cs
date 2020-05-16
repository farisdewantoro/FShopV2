namespace FShopV2.Base.Types
{
    public interface IPagedQuery : IQuery
    {
        int Page { get; }
        int Results { get; }
        string OrderBy { get; }
        string SortOrder { get; }
    }
}