using Identity.Application.Contracts.Enums;

namespace Identity.Application.Contracts.Dtos
{
    public class ResponseDto
    {
        public Status Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
