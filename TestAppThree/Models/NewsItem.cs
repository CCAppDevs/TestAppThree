using System.ComponentModel.DataAnnotations;

namespace TestAppThree.Models
{
    public class NewsItem
    {
        public int NewsItemID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public DateTime PostedOn { get; set; }
        public string ImageURL { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
