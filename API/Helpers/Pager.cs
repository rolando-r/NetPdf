namespace API.Helpers
{
    public class Pager<T> where T : class
    {
        public string Search { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Registers { get; private set; }

        public Pager(IEnumerable<T> registers, string search, int total, int pageIndex, int pageSize)
        {
            Registers = registers;
            Search = search;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Total = total;
        }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(Total / (double)PageSize);
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}