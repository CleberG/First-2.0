namespace First2._0.Tests.Integration.Utils
{
    public class ValidationErrorResponse
    {
        public ValidationErrorResponse(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
