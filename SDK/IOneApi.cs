using SDK.Contracts;
using System.Linq.Expressions;

namespace SDK
{
    public interface IOneApi
    {
        void Configure(string authKey);

        OneApi AddPreFilter(QueryParameter Param);

        Task<List<T>> RetrieveAll<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : new();
    }
}