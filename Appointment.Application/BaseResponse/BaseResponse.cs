namespace Appointment.Application.BaseResponse
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public BaseResponse()
        {
            Success = false;
            Message = "";
        }

        public void CreateBaseResponse(bool success, string message, T data)
        {
            this.Data = data;
            this.Message = message;
            this.Success = success;
        }
    }
}
