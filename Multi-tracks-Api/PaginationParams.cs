namespace Multi_Tracks_API
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 5;
        private int itemsPerPage;

        public int Page { get; set; } = 1;

        public int ItemsPerPage { get { return itemsPerPage; } set { itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value; } }
    }
}
