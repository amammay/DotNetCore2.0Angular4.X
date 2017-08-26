using System.Collections.Generic;
using System.Threading.Tasks;
using PsuApi.Models;

namespace ClassLibrary1
{
    public interface IPsuSearchClient
    {
        Task<IEnumerable<PsuSearchResult>> PostRetrieveShort(SearchForm searchForm);
    }
}