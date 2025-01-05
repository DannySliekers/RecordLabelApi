namespace RecordLabelApi.Models
{
    public class SingleRequest
    {
        public int? Id { get; set; }
        public required string Title { get; set; }
        public required string Status { get; set; }
        public required string Playlength { get; set; }
        public required string Cover { get; set; }
        public int ArtistId { get; set; }
        public List<int> PlatformIds { get; set; } = [];
    }
}
