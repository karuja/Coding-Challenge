using Coding_Challenge.Common.Aspect.Logging;
using System.Collections.Generic;

namespace Coding_Challenge.Repository
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private readonly Dictionary<string, HashSet<string>> _repository;

        public VisitorsRepository()
        {
            _repository = new Dictionary<string, HashSet<string>>();
        }

        /// <summary>
        /// Add new Visitor to the Url.
        /// </summary>
        /// <param name="url">The Url.</param>
        /// <param name="userId">The user unique id.</param>
        /// <returns>true if valid parameters.</returns>
        [LogAspect]
        public bool Add(string url, string userId)
        {
            if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(userId))
            {
                if (_repository.ContainsKey(url))
                {
                    _repository[url].Add(userId);
                }
                else
                {
                    _repository.Add(url, new HashSet<string>() { userId });
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get number of distinct visitors of a given url.
        /// </summary>
        /// <param name="url">The url.</param>
        /// <returns>Number of distinct visitors.</returns>
        [LogAspect]
        public int GetNumberOfVisitors(string url)
        {
            if (!string.IsNullOrEmpty(url) && _repository.ContainsKey(url))
            {
                return _repository[url].Count;
            }
            return 0;
        }
    }
}