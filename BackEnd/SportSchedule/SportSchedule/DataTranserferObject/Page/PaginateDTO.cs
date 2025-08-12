namespace SportSchedule.DataTranserferObject.Page
{
    public class PaginateDTO
    {
        public int TotalItem {  get; set; }
        public int PageSizes {  get; set; }
        public int TotalPages {  get; set; }
        public int CurrentPage {  get; set; }
        public int StartPage {  get; set; }
        public int EndPage { get; set; }
        public PaginateDTO() { }
        public PaginateDTO(int total_item, int page, int page_size)
        {
            int total_page = (int)Math.Ceiling((decimal)total_item/(decimal)page_size);
            int current_page = page;

            int start_page = current_page - page_size;
            int end_page = current_page + (page_size - 1);

            if(start_page <= 0)
            {
                end_page = end_page - (start_page - 1);
                start_page = 1;
            }
            if(end_page > total_page)
            {
                end_page = total_page;
            }
            TotalItem = total_item;
            TotalPages = total_page;
            CurrentPage = current_page;
            StartPage = start_page;
            EndPage = end_page;
            PageSizes = page_size;
        }
    }
}
