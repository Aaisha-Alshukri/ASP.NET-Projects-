namespace ListApplication.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }


        public ICollection<ListApp> Lists { get; set; } = new List<ListApp>();
    }
}
