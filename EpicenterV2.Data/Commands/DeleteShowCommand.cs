using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class DeleteShowCommand : Base
    {
        private readonly int _showId;
        private const string DeleteEpisodesQuery = @"DELETE FROM Episode WHERE ShowId = @ShowId";
        private const string DeleteShowQuery = @"DELETE FROM Show WHERE ShowId = @ShowId";

        public DeleteShowCommand(int showId)
        {
            _showId = showId;
        }

        public void Execute()
        {
            Connection.Execute(DeleteEpisodesQuery, new ShowDto{ShowId = _showId});
            Connection.Execute(DeleteShowQuery, new ShowDto{ShowId = _showId});
        }
    }
}