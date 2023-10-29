namespace RecordLabelApi.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Residence { get; set; }
    }
}
