namespace RecordLabelApi.Models
{
    public class Album
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Cover { get; set; }
        public required string Status { get; set; }
        public int PlatformId { get; set; }
        public int ArtistId { get; set; }
    }
}
