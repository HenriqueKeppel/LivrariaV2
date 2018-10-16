using System;

namespace LoggerApi.Domain.PostObjects
{
    public class LoggerPost
    {
        public int StatusCode {get;}

        public LoggerPost(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}