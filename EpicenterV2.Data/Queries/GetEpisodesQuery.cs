using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Queries
{
    public class GetEpisodesQuery : Base
    {
        private readonly int _showId;
        private const string SelectQuery = @"SELECT E.EpisodeId
                                                  , E.ShowId
                                                  , E.EpisodeNumber
                                                  , E.SeasonNumber
                                                  , E.Description
                                                  , E.Rating
                                                  , S.ShowName
                                            FROM Episode AS E
                                                 INNER JOIN Show AS S ON S.ShowId = E.ShowId
                                            WHERE E.[ShowId] = @ShowId";

        public GetEpisodesQuery(int showId)
        {
            _showId = showId;
        }

        public IEnumerable<EpisodeDto> Execute()
        {
            return Connection.Query<EpisodeDto>(SelectQuery, new ShowDto{ShowId = _showId});
        }
    }
}