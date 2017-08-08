using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class InsertEpisodeCommand : Base
    {
        private readonly EpisodeDto _episode;
        private const string InsertQuery = @"INSERT INTO Episode ([ShowId], [SeasonNumber], [EpisodeNumber], [Description], [Rating]) 
            VALUES (@ShowId, @SeasonNumber, @EpisodeNumber, @Description, @Rating)";

        public InsertEpisodeCommand(EpisodeDto episode)
        {
            _episode = episode;
        }

        public void Execute()
        {
            Connection.Execute(InsertQuery, _episode);
        }
    }
}