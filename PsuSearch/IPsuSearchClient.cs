using System;
using System.Threading.Tasks;
using PsuSearch.Models;

namespace PsuSearch
{
    public interface IPsuSearchClient
    {
        Task<PsuShortResult> PostRetrieveStudentShort(SearchForm searchForm);

    }
}
