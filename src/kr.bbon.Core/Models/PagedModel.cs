using System.Collections.Generic;
using System.Linq;

namespace kr.bbon.Core.Models
{
    public interface IPagedModel<TModel> where TModel : class
    {
        /// <summary>
        /// Current page
        /// </summary>
        int CurrentPage { get; set; }

        /// <summary>
        /// Records
        /// </summary>
        List<TModel> Items { get; }

        /// <summary>
        /// Items count per page
        /// </summary>
        int Limit { get; set; }

        /// <summary>
        /// Total items count
        /// </summary>
        int TotalItems { get; set; }

        /// <summary>
        /// Total page count
        /// </summary>
        int TotalPages { get; set; }

        /// <summary>
        /// Has next page
        /// </summary>
        bool HasNextPage { get; set; }

        /// <summary>
        /// has previous page
        /// </summary>
        bool HasPreviousPage { get; set; }

        /// <summary>
        /// Current page is first page or not
        /// </summary>
        bool IsFirstPage { get; set; }

        /// <summary>
        /// Current page is last page or not
        /// </summary>
        bool IsLastPage { get; set; }
    }


    public class PagedModel<TModel> : IPagedModel<TModel> where TModel : class
    {
        //#if NET5_0_OR_GREATER
        //        public PagedModel() { }
        //#else
        //        private PagedModel()
        //        {
        //        }
        //#endif

        public PagedModel() { }

        public PagedModel(int currentPage, int limit, int totalItems, int totalPages, IEnumerable<TModel> items)
        {
            CurrentPage = currentPage;
            Limit = limit;
            TotalItems = totalItems;
            TotalPages = totalPages;
            Items = new List<TModel>(items ?? Enumerable.Empty<TModel>());

            HasNextPage = CurrentPage < TotalPages;
            HasPreviousPage = CurrentPage > 1;

            IsFirstPage = currentPage == 1;
            IsLastPage = currentPage == TotalPages;
        }

        /// <inheritdoc />
        public int CurrentPage
        {
            get;
            //#if NET5_0_OR_GREATER
            //            init;
            //#endif
            set;
        }

        /// <inheritdoc />
        public int Limit
        {
            get;
            //#if NET5_0_OR_GREATER
            //            init;
            //#endif
            set;
        }

        /// <inheritdoc />
        public int TotalItems
        {
            get;
            //#if NET5_0_OR_GREATER
            //            init;
            //#endif
            set;
        }

        /// <inheritdoc />
        public int TotalPages
        {
            get;
            //#if NET5_0_OR_GREATER
            //            init;
            //#endif
            set;
        }

        /// <inheritdoc />
        public List<TModel> Items
        {
            get;
            //#if NET5_0_OR_GREATER
            //            init;
            //#endif
            set;
        }

        /// <inheritdoc />
        public bool HasNextPage
        {
            get;// => CurrentPage < TotalPages;
            set;
        }

        /// <inheritdoc />
        public bool HasPreviousPage
        {
            get;// => CurrentPage > 1;
            set;
        }

        /// <inheritdoc />
        public bool IsFirstPage { get; set; }

        /// <inheritdoc />
        public bool IsLastPage { get; set; }
    }
}
