using System.Net;

namespace BookRecord.Domain.Exceptions;

public class RecordOperationException : ApplicationException
{
    public RecordOperationException(string message, HttpStatusCode code) : base(message)
    {
        HttpStatusCode = code;
    }

    public HttpStatusCode HttpStatusCode { get; set; }
}