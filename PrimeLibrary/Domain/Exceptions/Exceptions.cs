using System;
using System.Collections.Generic;
using System.Text;

namespace Prime.Library.Domain.Exceptions
{
    public class HttpClientException : Exception
    {
        public HttpClientException() { }
        public HttpClientException(string message) : base(message) { }
        public HttpClientException(string message, Exception inner) : base(message, inner) { }
    }

    public class ApiException : Exception
    {
        public ApiException() { }
        public ApiException(string message) : base(message) { }
        public ApiException(string message, Exception inner) : base(message, inner) { }
    }

    public class UserException : Exception
    {
        public UserException() { }
        public UserException(string message) : base(message) { }
        public UserException(string message, Exception inner) : base(message, inner) { }
    }

    public class DatabaseException : Exception
    {
        public DatabaseException() { }
        public DatabaseException(string message) : base(message) { }
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
    }
}
