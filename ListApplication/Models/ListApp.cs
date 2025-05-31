using System.ComponentModel.DataAnnotations.Schema;

namespace ListApplication.Models
{
    public class ListApp
    {
        public int ListAppId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly DeadLine { get; set; }
        public string Priority { get; set; }
        public bool IsFinished { get; set; }


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
