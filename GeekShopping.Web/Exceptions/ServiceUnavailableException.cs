namespace GeekShopping.Web.Exceptions
{
    /// <summary>
    /// Exception used when item is not founded
    /// </summary>
    public class ServiceUnavailableException : BaseException
    {
        public ServiceUnavailableException(string resource, string action, string controller, int status = 503) : base(resource, action, controller, status)
        {
            Detail = String.Format("{0}.{1}.The {2} was not available.", controller, action, resource);
        }

        public ServiceUnavailableException(string resource, string action, string controller, Dictionary<string, string[]>? errors, int status = 404) : base(resource, action, controller, errors, status)
        {
        }
    }
}
