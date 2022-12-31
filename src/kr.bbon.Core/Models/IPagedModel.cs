using System.Collections.Generic;

namespace kr.bbon.Core.Models
{
    public interface IPagedModel<TModel> where TModel : class
    {
        /// <summary>
        /// Current page; Page starts at 1.
        /// </summary>
        uint CurrentPage { get; }

        /// <summary>
        /// Records
        /// </summary>
        List<TModel> Items { get; }

        /// <summary>
        /// Items count per page
        /// </summary>
        uint Limit { get; }

        /// <summary>
        /// Total items count
        /// </summary>
        ulong TotalItems { get; }

        /// <summary>
        /// Total page count
        /// </summary>
        uint TotalPages { get; }

        /// <summary>
        /// Has next page
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// has previous page
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Current page is first page or not
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Current page is last page or not
        /// </summary>
        bool IsLastPage { get; }

        void SetInformation(uint currentPage, uint limit, ulong totalItems, uint totalPages);

        void SetItems(IEnumerable<TModel> items);
    }
}
