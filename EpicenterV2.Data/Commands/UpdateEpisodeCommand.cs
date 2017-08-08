using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class UpdateEpisodeCommand : Base
    {
        private readonly EpisodeDto _episode;
        private const string UpdateQuery = @"UPDATE Episode SET [SeasonNumber] = @SeasonNumber, [EpisodeNumber] = @EpisodeNumber, 
            [Description] = @Description, [Rating] = @Rating 
            WHERE [EpisodeId] = @EpisodeId";

        public UpdateEpisodeCommand(EpisodeDto episode)
        {
            _episode = episode;
        }

        public void Execute()
        {
            Connection.Execute(UpdateQuery, _episode);
        }
    }
}