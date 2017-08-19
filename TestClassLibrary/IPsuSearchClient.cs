using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestClassLibrary.Models;


namespace TestClassLibrary
{
    public interface IPsuSearchClient
    {
        Task<IEnumerable<PsuSearchResult>> PostRetrieveShort(SearchForm searchForm);

    }
}
