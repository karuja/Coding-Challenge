using Coding_Challenge.Repository;
using Xunit;

namespace Coding_Challenge.Tests
{
    public class VisitorsRepositoryTest
    {
        private readonly VisitorsRepository _visitorsRepository = new VisitorsRepository();

        [Fact]
        public void Add_EmptyParameters_ReturnsFalse()
        {
            bool outcome = _visitorsRepository.Add(string.Empty, string.Empty);
            Assert.False(outcome);
        }

        [Fact]
        public void Add_NullParameters_ReturnsFalse()
        {
            bool outcome = _visitorsRepository.Add(null, null);
            Assert.False(outcome);
        }

        [Fact]
        public void Add_OneVisitor_ReturnsTrue()
        {
            bool outcome = _visitorsRepository.Add("www.teste.com", "user1");
            Assert.True(outcome);
        }

        [Fact]
        public void Add_TwoVisitors_SameUrl_ReturnsTrue()
        {
            _visitorsRepository.Add("www.teste.com", "user1");
            bool outcome = _visitorsRepository.Add("www.teste.com", "user2");
            Assert.True(outcome);
        }

        [Fact]
        public void GetNumberOfVisitors_AddedSameUserAndUrl_ReturnsOne()
        {
            _visitorsRepository.Add("www.teste.com", "user1");
            _visitorsRepository.Add("www.teste.com", "user1");
            int nvisitors = _visitorsRepository.GetNumberOfVisitors("www.teste.com");
            Assert.Equal(1, nvisitors);
        }

        [Fact]
        public void GetNumberOfVisitors_DistinctUsers_ReturnsThree()
        {
            _visitorsRepository.Add("www.teste.com", "user1");
            _visitorsRepository.Add("www.teste.com", "user1");
            _visitorsRepository.Add("www.teste.com", "user2");
            _visitorsRepository.Add("www.teste.com", "user3");
            int nvisitors = _visitorsRepository.GetNumberOfVisitors("www.teste.com");
            Assert.Equal(3, nvisitors);
        }

        [Fact]
        public void GetNumberOfVisitors_EmptyRepo_ReturnsZero()
        {
            int nvisitors = _visitorsRepository.GetNumberOfVisitors("www.teste.com");
            Assert.Equal(0, nvisitors);
        }

        [Fact]
        public void GetNumberOfVisitors_EmptyUrl_ReturnsZero()
        {
            int nvisitors = _visitorsRepository.GetNumberOfVisitors(string.Empty);
            Assert.Equal(0, nvisitors);
        }

        [Fact]
        public void GetNumberOfVisitors_NullUrl_ReturnsZero()
        {
            int nvisitors = _visitorsRepository.GetNumberOfVisitors(null);
            Assert.Equal(0, nvisitors);
        }
    }
}