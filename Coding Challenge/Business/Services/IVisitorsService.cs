using Coding_Challenge.Common.Dto;

namespace Coding_Challenge.Business
{
    public interface IVisitorsService
    {
        public VisitorsDto GetNumberOfVisitors(string url);

        public bool RegisterVisitor(string requestBody);
    }
}