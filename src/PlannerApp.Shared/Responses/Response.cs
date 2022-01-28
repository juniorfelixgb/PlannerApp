using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Shared.Responses
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class Response<T> : Response
    {
        public T Value { get; set; }
    }

    public class ErrorResponse
    {
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
