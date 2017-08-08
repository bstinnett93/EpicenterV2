namespace EpicenterV2.Models
{
    public class Episode
    {
        public int EpisodeId { get; set; }
        public int ShowId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string ShowName { get; set; }
    }
}