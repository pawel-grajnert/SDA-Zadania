using System.Net;

namespace ProductManagement.Mvc.Domain.Types;

public class ProductManagementException : ApplicationException
{
    public ProductManagementException(HttpStatusCode code, string message) : base(message)
    {
        StatusCode = code;
    }

    public HttpStatusCode StatusCode { get; set; }
}