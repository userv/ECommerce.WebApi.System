namespace ECommerce.WebApi.System.Services
{
    public class UserManagerResponse
    {
        public UserManagerResponse()
        {

        }
        
        public UserManagerResponse(string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
            
        }

        public UserManagerResponse(string message, bool isSuccess, IEnumerable<string> errors)
        {
            Message = message;
            IsSuccess = isSuccess;
            Errors = errors;
            
        }
        public UserManagerResponse(string message, bool isSuccess, IEnumerable<string> errors, DateTime? expireDate, string token)
        {
            Message = message;
            IsSuccess = isSuccess;
            Errors = errors;
            ExpireDate = expireDate;
            Token = token;
        }

        public string Message { get; set; }
            public bool IsSuccess { get; set; }
            public IEnumerable<string>? Errors { get; set; }
            public DateTime? ExpireDate { get; set; }
            public string? Token { get; set; }


        

    }
}
