namespace WebApplication3.Models
{
    public class KrisInfo
    {
        public List<DateTime> Datum { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public int Displaymode { get; set; }
        public bool Emergency { get; set; }
    }
}
