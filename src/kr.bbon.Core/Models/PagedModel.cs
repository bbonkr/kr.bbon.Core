using System.Collections.Generic;
using System.Linq;

namespace kr.bbon.Core.Models
{
    public class PagedModel<TModel> : IPagedModel<TModel> where TModel : class
    {
        public PagedModel() { }

        public PagedModel(uint currentPage, uint limit, ulong totalItems, uint totalPages, IEnumerable<TModel> items)
        {
            SetInformation(currentPage, limit, totalItems, totalPages);
            SetItems(items);
        }

        /// <inheritdoc />
        public uint CurrentPage { get; private set; }

        /// <inheritdoc />
        public uint Limit { get; private set; }

        /// <inheritdoc />
        public ulong TotalItems { get; private set; }

        /// <inheritdoc />
        public uint TotalPages { get; private set; }

        /// <inheritdoc />
        public List<TModel> Items { get; private set; }

        /// <inheritdoc />
        public bool HasNextPage
        {
            get => CurrentPage < TotalPages;
        }

        /// <inheritdoc />
        public bool HasPreviousPage
        {
            get => CurrentPage > 1;
        }

        /// <inheritdoc />
        public bool IsFirstPage
        {
            get => CurrentPage == 1;
        }

        /// <inheritdoc />
        public bool IsLastPage
        {
            get => CurrentPage == TotalPages;
        }

        public void SetInformation(uint currentPage, uint limit, ulong totalItems, uint totalPages)
        {
            CurrentPage = currentPage;
            Limit = limit;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public void SetItems(IEnumerable<TModel> items)
        {
            Items = new List<TModel>(items ?? Enumerable.Empty<TModel>());
        }
    }
}
