using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Queries
{
    public class GetAllEpisodesQuery : Base
    {
        private const string SelectQuery = @"SELECT * FROM Episode";

        public IEnumerable<EpisodeDto> Execute()
        {
            return Connection.Query<EpisodeDto>(SelectQuery);
        }
    }
}