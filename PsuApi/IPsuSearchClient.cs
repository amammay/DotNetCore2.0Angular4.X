using System.Collections.Generic;
using System.Threading.Tasks;
using PsuApi.Models;

namespace PsuApi
{
    public interface IPsuSearchClient
    {
        Task<IEnumerable<PsuSearchResult>> PostRetrieveShort(SearchForm searchForm);
        Task<IEnumerable<PsuSearchResult>> PostRetrieveLong(SearchForm searchForm);

    }
}