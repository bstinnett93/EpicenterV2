using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using EpicenterV2.Data;
using EpicenterV2.Data.Commands;
using EpicenterV2.Data.Dtos;
using EpicenterV2.Data.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpicenterV2.Tests
{
    [TestClass]
    public class ShowCommandTests : Base

    {
        [TestMethod]
        public void CanInsertShowCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var showsBefore = new GetShowsQuery().Execute();

                var show = new ShowDto
                {
                    ShowName = "Agents of Shield"
                };
                new InsertShowCommand(show).Execute();

                var showsAfter = new GetShowsQuery().Execute();

                Assert.AreEqual(showsBefore.Count(), 5);
                Assert.AreEqual(showsAfter.Count(), 6);
            }
        }

        [TestMethod]
        public void CanDeleteShowCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var showsBefore = new GetShowsQuery().Execute();
                var episodesBefore = new GetEpisodesQuery(1).Execute();

                new DeleteShowCommand(1).Execute();

                var showsAfter = new GetShowsQuery().Execute();
                var episodesAfter = new GetEpisodesQuery(1).Execute();

                Assert.AreEqual(showsBefore.Count(), 5);
                Assert.AreEqual(showsAfter.Count(), 4);
                Assert.AreEqual(episodesBefore.Count(), 3);
                Assert.AreEqual(episodesAfter.Count(), 0);
            }
        }

        [TestMethod]
        public void CanUpdateShowCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var show = new ShowDto
                {
                    ShowId = 1,
                    ShowName = "Test"
                };

                new UpdateShowCommand(show).Execute();

                var showAfter = (new GetShowsQuery().Execute()).FirstOrDefault();

                Assert.AreEqual(showAfter.ShowId, 1);
                Assert.AreEqual(showAfter.ShowName, "Test");
            }
        }
    }
}
