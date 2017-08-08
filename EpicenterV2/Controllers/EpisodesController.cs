using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpicenterV2.Data.Queries;
using EpicenterV2.Models;

namespace EpicenterV2.Controllers
{
    public class EpisodesController : Controller
    {
        // GET: Episodes
        public ActionResult Index(int id)
        {
            var episodes = GetEpisodes(id);

            return PartialView(episodes);
        }

        private IEnumerable<Episode> GetEpisodes(int showId)
        {
            var episodeDtos = new GetEpisodesQuery(showId).Execute();
            var episodeViewModels = new List<Episode>();

            foreach (var dto in episodeDtos)
            {
                episodeViewModels.Add(new Episode()
                {
                    EpisodeId = dto.EpisodeId,
                    ShowName = dto.ShowName,
                    SeasonNumber = dto.SeasonNumber,
                    EpisodeNumber = dto.EpisodeNumber,
                    Description = dto.Description,
                    Rating = dto.Rating
                });
            }

            return episodeViewModels;
        }
    }
}