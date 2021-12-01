using Coding_Challenge.Business;
using Coding_Challenge.Common.Dto;
using Coding_Challenge.Common.Exceptions;
using Coding_Challenge.Common.Logging;
using Coding_Challenge.Repository;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Coding_Challenge.Tests.Business.Services
{
    public class VisitorsServiceTest
    {
        private readonly Mock<ILogg> _mockLogg = new Mock<ILogg>();
        private readonly Mock<IVisitorsRepository> _mockRepo;
        private readonly VisitorsService _service;

        public VisitorsServiceTest()
        {
            _mockRepo = new Mock<IVisitorsRepository>();
            _mockRepo.Setup(x => x.Add(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _mockRepo.Setup(x => x.GetNumberOfVisitors(It.IsAny<string>())).Returns(5);
            _service = new VisitorsService(_mockRepo.Object, _mockLogg.Object);
        }

        [Fact]
        public void GetNumberOfVisitors_Successful()
        {
            VisitorsDto expected = new VisitorsDto()
            {
                Url = "teste",
                NVisitors = 5
            };
            VisitorsDto actual = _service.GetNumberOfVisitors("teste");
            _mockRepo.Verify(mock => mock.GetNumberOfVisitors("teste"), Times.Once());
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RegisterVisitor_Null_ReturnsFalse()
        {
            bool succ = _service.RegisterVisitor(null);
            Assert.False(succ);
        }

        [Fact]
        public void RegisterVisitor_NonJsonString_CouldNotParseEventFromBodyException()
        {
            Assert.Throws<CouldNotParseEventFromBodyException>(() => _service.RegisterVisitor("teste"));
        }

        [Fact]
        public void RegisterVisitor_Successful()
        {
            bool succ = _service.RegisterVisitor(JsonConvert.SerializeObject(new Common.Dto.EventDto() { Url = "1234", UserId = "user" }));
            _mockRepo.Verify(mock => mock.Add("1234", "user"), Times.Once());
            Assert.True(succ);
        }
        [Fact]
        public void RegisterVisitor_EscapeUrl_Successful()
        {
            _service.RegisterVisitor(JsonConvert.SerializeObject(new Common.Dto.EventDto() { Url = "http://www.teste.pt/123?a=456", UserId = "user" }));
            _mockRepo.Verify(mock => mock.Add("http%3A%2F%2Fwww.teste.pt%2F123%3Fa%3D456", "user"), Times.Once());
        }
    }
}