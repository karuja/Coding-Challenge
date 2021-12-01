using Coding_Challenge.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace Coding_Challenge
{
    public class RegisterEventFunction
    {
        private readonly IVisitorsService visitorsService;

        public RegisterEventFunction(IVisitorsService visitorsService)
        {
            this.visitorsService = visitorsService;
        }

        /// <summary>
        /// Register a visitor of a Url.
        /// </summary>
        /// <param name="req">The HTTP request containing an Event object on its body.</param>
        /// <param name="log">The logger.</param>
        /// <returns></returns>
        [FunctionName("RegisterVisitor")]
        public async Task<IActionResult> RegisterVisitor(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "register-visitor")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("RegisterVisitor function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            bool success = false;
            try
            {
                success = this.visitorsService.RegisterVisitor(requestBody);
            }
            catch (Exception ex) {
                return new BadRequestObjectResult(ex.Message);
            };

            if (success) return new OkObjectResult("Visitor registered successfully.");

            return new BadRequestObjectResult("Visitor not registered, please validate your request data.");
        }
    }
}