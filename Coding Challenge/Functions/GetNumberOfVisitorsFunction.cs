using Coding_Challenge.Business;
using Coding_Challenge.Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Coding_Challenge
{
    public class GetNumberOfVisitorsFunction
    {
        private readonly IVisitorsService visitorsService;

        public GetNumberOfVisitorsFunction(IVisitorsService visitorsService)
        {
            this.visitorsService = visitorsService;
        }

        /// <summary>
        /// Function to get Number of Visitors
        /// </summary>
        /// <param name="req">The http request containing url query parameter.</param>
        /// <param name="log">The logger.</param>
        /// <returns></returns>
        [FunctionName("GetNumberOfVisitors")]
        public IActionResult GetNumberOfVisitors(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "number-of-visitors")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetNumberOfVisitors function processed a request.");

            string url = req.Query["url"];

            VisitorsDto visitors = visitorsService.GetNumberOfVisitors(url);

            return new OkObjectResult(visitors);
        }
    }
}