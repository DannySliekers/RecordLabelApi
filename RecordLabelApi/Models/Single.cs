namespace RecordLabelApi.Models
{
    public class Single
    {
        public int id { get; set; }
        public required string title { get; set; }
        public required string status { get; set; }
        public required string playlength { get; set; }
        public required string cover { get; set; }
        public int platformid { get; set; }
        public int artistid { get; set; }
    }
}
