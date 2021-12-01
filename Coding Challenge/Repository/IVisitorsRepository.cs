namespace Coding_Challenge.Repository
{
    public interface IVisitorsRepository
    {
        public bool Add(string url, string userId);

        public int GetNumberOfVisitors(string url);
    }
}