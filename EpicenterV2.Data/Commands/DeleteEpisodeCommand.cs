using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class DeleteEpisodeCommand : Base
    {
        private readonly int _episodeId;
        private const string DeleteQuery = @"DELETE FROM Episode WHERE EpisodeId = @EpisodeId";

        public DeleteEpisodeCommand(int episodeId)
        {
            _episodeId = episodeId;
        }

        public void Execute()
        {
            Connection.Execute(DeleteQuery, new EpisodeDto{EpisodeId = _episodeId});
        }
    }
}