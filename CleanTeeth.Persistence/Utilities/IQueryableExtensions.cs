namespace CleanTeeth.Persistence.Utilities;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int recordPerPage)
    {
        return queryable.Skip((page - 1) * recordPerPage).Take(recordPerPage);
    }
}
