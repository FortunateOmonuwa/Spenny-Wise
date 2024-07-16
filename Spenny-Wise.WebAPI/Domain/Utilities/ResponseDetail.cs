namespace Spenny_Wise.WebAPI.Domain.Utilities
{
    public class ResponseDetail<T>
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
        public int? ResultCode { get; set; }



        public ResponseDetail<T> FailedResultData(T result)
        {
            var r = new ResponseDetail<T>
            {
                Message = "Operation was not successful: Please try again",
               // Result = result,
                IsSuccessful = false,
                ResultCode = 400
            };

            return r;
        }

        public ResponseDetail<T> SuccessResultData(T result)
        {
            var r = new ResponseDetail<T>
            {
                Message = "Operation Successful",
                IsSuccessful = true,
                Result = result,
                ResultCode = 200
            };

            return r;
        }


    }

    
}
