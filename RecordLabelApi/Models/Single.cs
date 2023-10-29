namespace RecordLabelApi.Models
{
    public class Single
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Status { get; set; }
        public required string PlayLength { get; set; }
        public required string Cover { get; set; }
        public int PlatformId { get; set; }
        public int ArtistId { get; set; }
    }
}
