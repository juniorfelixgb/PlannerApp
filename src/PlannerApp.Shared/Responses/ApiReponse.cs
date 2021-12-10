// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

namespace PlannerApp.Shared.Responses
{
    public class ApiReponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class ApiResponse<T> : ApiReponse
    {
        public T Value { get; set; }
    }
}
