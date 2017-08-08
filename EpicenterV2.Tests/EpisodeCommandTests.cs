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
    public class EpisodeCommandTests : Base

    {
        [TestMethod]
        public void CanInsertEpisodeCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var episodesBefore = new GetEpisodesQuery(1).Execute();

                var episode = new EpisodeDto
                {
                    ShowId = 1,
                    SeasonNumber = 12,
                    EpisodeNumber = 12,
                    Description = "Test",
                    Rating = 5.5
                };
                new InsertEpisodeCommand(episode).Execute();

                var episodesAfter = new GetEpisodesQuery(1).Execute();

                Assert.AreEqual(episodesBefore.Count(), 3);
                Assert.AreEqual(episodesAfter.Count(), 4);
                Assert.AreEqual(episodesAfter.LastOrDefault().ShowId, 1);
                Assert.AreEqual(episodesAfter.LastOrDefault().SeasonNumber, 12);
                Assert.AreEqual(episodesAfter.LastOrDefault().Description, "Test");
            }
        }

        [TestMethod]
        public void CanDeleteEpisodeCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var episodesBefore = new GetEpisodesQuery(1).Execute();

                new DeleteEpisodeCommand(1).Execute();

                var episodesAfter = new GetEpisodesQuery(1).Execute();

                Assert.AreEqual(episodesBefore.Count(), 3);
                Assert.AreEqual(episodesAfter.Count(), 2);
            }
        }

        [TestMethod]
        public async Task CanUpdateEpisodeCommandTest()
        {
            using (new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var episode = new EpisodeDto
                {
                    EpisodeId = 1,
                    EpisodeNumber = 12,
                    SeasonNumber = 12,
                    Description = "Test",
                    Rating = 5.5
                };

                new UpdateEpisodeCommand(episode).Execute();

                var episodeAfter = new GetEpisodeDetailsQuery(episode.EpisodeId).Execute();

                Assert.AreEqual(episodeAfter.SeasonNumber, 12);
                Assert.AreEqual(episodeAfter.EpisodeNumber, 12);
                Assert.AreEqual(episodeAfter.Description, "Test");
                Assert.AreEqual(episodeAfter.Rating, 5.5);
            }
        }
    }
}
