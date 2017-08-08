using System;
using System.Linq;
using System.Threading.Tasks;
using EpicenterV2.Data;
using EpicenterV2.Data.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpicenterV2.Tests
{
    [TestClass]
    public class QueryTests : Base

    {
        [TestMethod]
        public void CanGetShowsQueryTest()
        {
            var shows = new GetShowsQuery().Execute();

            Assert.AreEqual(shows.Count(), 5);
        }

        [TestMethod]
        public void CanGetAllEpisodesQueryTest()
        {
            var episodes = new GetAllEpisodesQuery().Execute();

            Assert.AreEqual(episodes.Count(), 15);
        }

        [TestMethod]
        public void CanGetEpisodesQueryTest()
        {
            var episodes = new GetEpisodesQuery(1).Execute();

            Assert.AreEqual(episodes.Count(), 3);
        }

        [TestMethod]
        public void CanGetEpisodeDetailsQueryTest()
        {
            var episode = new GetEpisodeDetailsQuery(1).Execute();

            Assert.AreEqual(episode.ShowName, "The Blacklist");
            Assert.AreEqual(episode.EpisodeId, 1);
            Assert.AreEqual(episode.ShowId, 1);
            Assert.AreEqual(episode.SeasonNumber, 1);
            Assert.AreEqual(episode.EpisodeNumber, 1);
            Assert.AreEqual(episode.Description, "Great pilot1");
            Assert.AreEqual(episode.Rating, 4);
        }
    }
}
