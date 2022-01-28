// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using PlannerApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApp.Client.Services.Exceptions
{
    public class ApiException : Exception
    {
        public ErrorResponse ErrorResponse { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public ApiException(
            ErrorResponse errorResponse,
            HttpStatusCode statusCode) : this(errorResponse)
        {
            StatusCode = statusCode;
        }

        public ApiException(
            ErrorResponse errorResponse)
        {
            ErrorResponse = errorResponse;
        }
    }
}
