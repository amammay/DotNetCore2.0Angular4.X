using System.Collections.Generic;
using System.Threading.Tasks;
using ClassLibrary1.Models;

namespace ClassLibrary1
{
    public interface IPsuSearchClient
    {
        Task<IEnumerable<PsuSearchResult>> PostRetrieveShort(SearchForm searchForm);

    }
}
