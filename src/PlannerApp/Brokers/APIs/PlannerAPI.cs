// ********************************************************************** 
//  ** CodingWithJunior - PlannerApp Application v1.0.0 
//  ** Copyright (c) 2021 Microsoft Corporation 
//  *********************************************************************

using System.Net.Http;

namespace PlannerApp.Brokers.APIs
{
    public class PlannerAPI : IPlannerAPI
    {
        private readonly HttpClient _http;
        public PlannerAPI(
            HttpClient http)
        {
            _http = http;
        }
    }
}
