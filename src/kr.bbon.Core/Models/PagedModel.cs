using System;
using System.Collections.Generic;
using System.Text;

namespace kr.bbon.Core.Models
{
    public interface IPagedModel<TModel>
    {
        /// <summary>
        /// Current page
        /// </summary>
        int CurrentPage { get; }

        /// <summary>
        /// Records
        /// </summary>
        IEnumerable<TModel> Items { get; }

        /// <summary>
        /// Items count per page
        /// </summary>
        int Limit { get; }

        /// <summary>
        /// Total items count
        /// </summary>
        int TotalItems { get; }

        /// <summary>
        /// Total page count
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Has next page
        /// </summary>
        bool HasNextPage { get; }

        /// <summary>
        /// has previous page
        /// </summary>
        bool HasPreviousPage { get; }
    }


    public class PagedModel<TModel> : IPagedModel<TModel>
    {
#if NET5_0_OR_GREATER
        public PagedModel() { }
#else
        private PagedModel() { }
#endif

        public PagedModel(int currentPage, int limit, int totalItems, int totalPages, IEnumerable<TModel> items)
        {
            CurrentPage = currentPage;
            Limit = limit;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Items = items;
        }

        /// <inheritdoc />
        public int CurrentPage
        {
            get;
#if NET5_0_OR_GREATER            
            init;
#endif        
        }

        /// <inheritdoc />
        public int Limit
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }

        /// <inheritdoc />
        public int TotalItems
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }

        /// <inheritdoc />
        public int TotalPages
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }

        /// <inheritdoc />
        public IEnumerable<TModel> Items
        {
            get;
#if NET5_0_OR_GREATER
            init;
#endif        
        }

        /// <inheritdoc />
        public bool HasNextPage { get => CurrentPage < TotalPages; }

        /// <inheritdoc />
        public bool HasPreviousPage { get => CurrentPage > 1; }
    }
}
