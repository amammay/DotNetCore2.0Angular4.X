using System.Collections.Generic;
using System.Threading.Tasks;
using PsuApi.Models;

namespace PsuApi
{
    public interface IPsuSearchClient
    {
        Task<IEnumerable<PsuSearchResult>> PostRetrieveSearch(SearchForm searchForm);

    }
}