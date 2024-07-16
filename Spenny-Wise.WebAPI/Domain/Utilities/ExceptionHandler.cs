using Microsoft.AspNetCore.Diagnostics;

namespace Spenny_Wise.WebAPI.Domain.Utilities
{
    public class ExceptionHandler //: IExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger;
     

        public ExceptionHandler( ILogger<ExceptionHandler> logger)
        {
            this.logger = logger;
        }


        public void LogException(Exception ex)
        {
            logger.LogInformation($"An error occured in:$ {ex.Source} \n\n{ex.InnerException} \n\n {ex.Message} ");
            Console.WriteLine($"An error occured: ${ex.InnerException} \n\n {ex.Message} \n\n {ex.Source}");
            //throw new Exception($"An error occured: ${ex.InnerException} \n\n {ex.Message} \n\n {ex.Source}");

        }

        //public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
