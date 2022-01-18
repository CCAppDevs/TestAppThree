namespace TestAppThree.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }

        public List<NewsItem> NewsItems { get; set; }
    }
}
