using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EpicenterV2.Data.Queries;
using EpicenterV2.Models;

namespace EpicenterV2.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public ActionResult Index()
        {
            var shows = GetShows();

            return PartialView(shows);
        }

        private IEnumerable<Show> GetShows()
        {
            var showDtos = new GetShowsQuery().Execute();
            var showViewModels = new List<Show>();

            foreach (var dto in showDtos)
            {
                showViewModels.Add(new Show
                {
                    ShowId = dto.ShowId,
                    ShowName = dto.ShowName
                });
            }

            return showViewModels;
        }
    }
}