namespace Spenny_Wise.WebAPI.Domain.Utilities
{
    public class ResponseDetail<T>
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
        public int? ResultCode { get; set; }
    }
}
