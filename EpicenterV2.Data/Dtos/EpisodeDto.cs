using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicenterV2.Data.Dtos
{
    public class EpisodeDto
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