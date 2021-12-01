using MethodBoundaryAspect.Fody.Attributes;
using Microsoft.Extensions.Logging;
using System;

namespace Coding_Challenge.Common.Aspect.Logging
{
    public class LogAspect : OnMethodBoundaryAspect
    {
        private readonly ILogger _logger;

        public LogAspect()
        {
            this._logger = new LoggerFactory().CreateLogger<LogAspect>();
        }

        public override void OnEntry(MethodExecutionArgs arg)
        {
            Console.WriteLine($"[Application Log] - Entering method {arg.Method.Name}");
            _logger.LogInformation("[Application Log] - Entering method {args.Method.Name}", arg.Method.Name);
        }

        public override void OnException(MethodExecutionArgs arg)
        {
            Console.WriteLine($"[Application Log] - Exception caught on method {arg.Method.Name}. Message: {arg.Exception.Message}");
            _logger.LogError("[Application Log] - Exception caught on method {args.Method.Name}. Message: {args.Exception.Message}", arg.Method.Name, arg.Exception.Message);
        }

        public override void OnExit(MethodExecutionArgs arg)
        {
            Console.WriteLine($"[Application Log] - Exiting method {arg.Method.Name}");
            _logger.LogInformation("[Application Log] - Exiting method {args.Method.Name}", arg.Method.Name);
        }
    }
}