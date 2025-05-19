namespace JwtTechTask.Models
{
    public class Transaction
    {
        public string id { get; set; }
        public double amount { get; set; }
        public string currency { get; set; }
        public Meta meta { get; set; }
        public object status { get; set; }
    }
}
