namespace PsuApi.Models
{
    public class SearchForm
    {
        public string Sn { get; set; }
        public string Cn { get; set; }
        public string Uid { get; set; }
        public string Mail { get; set; }
        public PsuSearchEnum Full { get; set; }
    }
}