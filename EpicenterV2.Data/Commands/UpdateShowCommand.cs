using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class UpdateShowCommand : Base
    {
        private readonly ShowDto _show;
        private const string UpdateQuery = @"UPDATE Show SET [ShowName] = @ShowName
            WHERE [ShowId] = @ShowId";

        public UpdateShowCommand(ShowDto show)
        {
            _show = show;
        }

        public void Execute()
        {
            Connection.Execute(UpdateQuery, _show);
        }
    }
}