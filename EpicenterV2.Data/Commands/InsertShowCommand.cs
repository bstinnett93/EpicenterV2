using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using EpicenterV2.Data.Dtos;

namespace EpicenterV2.Data.Commands
{
    public class InsertShowCommand : Base
    {
        private readonly ShowDto _show;
        private const string InsertQuery = @"INSERT INTO Show ([ShowName]) VALUES (@ShowName)";

        public InsertShowCommand(ShowDto show)
        {
            _show = show;
        }

        public void Execute()
        {
            Connection.Execute(InsertQuery, _show);
        }
    }
}