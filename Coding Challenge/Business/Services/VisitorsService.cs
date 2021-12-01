using Coding_Challenge.Common.Aspect.Logging;
using Coding_Challenge.Common.Dto;
using Coding_Challenge.Common.Exceptions;
using Coding_Challenge.Common.Logging;
using Coding_Challenge.Repository;
using Newtonsoft.Json;
using System;

namespace Coding_Challenge.Business
{
    public class VisitorsService : IVisitorsService
    {
        private readonly IVisitorsRepository _visitorsRepository;
        private readonly ILogg log;

        public VisitorsService(IVisitorsRepository visitorsRepository, ILogg logger)
        {
            _visitorsRepository = visitorsRepository;
            log = logger;
        }

        /// <summary>
        /// Get Number of Visitors by Url
        /// </summary>
        /// <param name="url">The Url.</param>
        /// <returns>Number of visitors and Url object.</returns>
        [LogAspect]
        public VisitorsDto GetNumberOfVisitors(string url)
        {
            url ??= string.Empty;
            return new VisitorsDto() { Url = url, NVisitors = _visitorsRepository.GetNumberOfVisitors(System.Uri.EscapeDataString(url)) };
        }

        /// <summary>
        /// Register a visitor for a url
        /// </summary>
        /// <param name="requestBody">The HTTP request body.</param>
        /// <returns>true if successful</returns>
        /// <exception cref="CouldNotParseEventFromBodyException">
        /// Request body could not be parsed.
        /// </exception>
        [LogAspect]
        public bool RegisterVisitor(string requestBody)
        {
            if (string.IsNullOrEmpty(requestBody))
            {
                return false;
            }
            EventDto _event;
            try
            {
                _event = JsonConvert.DeserializeObject<EventDto>(requestBody);
            }
            catch (Exception ex)
            {
                throw new CouldNotParseEventFromBodyException("Unknown object sent on request's body. Ex:" + ex.Message);
            }
            log.LogInformation("Url: " + _event.Url + "; UserId: " + _event.UserId);

            return _visitorsRepository.Add(Uri.EscapeDataString(_event.Url), _event.UserId);
        }
    }
}