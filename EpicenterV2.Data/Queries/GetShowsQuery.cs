using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Queries
{
    public class GetShowsQuery : Base
    {
        const string SelectQuery = @"SELECT * FROM Show";

        public IEnumerable<ShowDto> Execute()
        {
            return Connection.Query<ShowDto>(SelectQuery);
        }
    }
}