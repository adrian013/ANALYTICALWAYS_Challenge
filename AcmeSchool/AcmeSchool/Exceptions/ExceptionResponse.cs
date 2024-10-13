using System.Net;

namespace AcmeSchool.Exceptions
{
    public class ExceptionResponse
    {
        public ExceptionResponse(HttpStatusCode httpStatusCode, string description)
        {
            StatusCode = httpStatusCode;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string Description { get; set; }
    }
}
