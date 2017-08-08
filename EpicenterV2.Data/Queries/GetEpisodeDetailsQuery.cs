using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Queries
{
    public class GetEpisodeDetailsQuery : Base
    {
        private readonly int _episodeId;
        private const string SelectQuery = @"SELECT E.EpisodeId
                                                  , E.ShowId
                                                  , E.EpisodeNumber
                                                  , E.SeasonNumber
                                                  , E.Description
                                                  , E.Rating
                                                  , S.ShowName
                                            FROM Episode AS E
                                                 INNER JOIN Show AS S ON S.ShowId = E.ShowId
                                            WHERE E.[EpisodeId] = @EpisodeId";

        public GetEpisodeDetailsQuery(int episodeId)
        {
            _episodeId = episodeId;
        }

        public EpisodeDto Execute()
        {
            return Connection.QuerySingleOrDefault<EpisodeDto>(SelectQuery, new EpisodeDto{EpisodeId = _episodeId});
        }
    }
}