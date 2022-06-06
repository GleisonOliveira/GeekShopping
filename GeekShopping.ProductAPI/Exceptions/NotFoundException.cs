namespace GeekShopping.ProductAPI.Exceptions
{
    /// <summary>
    /// Exception used when item is not founded
    /// </summary>
    public class NotFoundException : BaseException
    {
        public NotFoundException(string resource, string action, string controller, int status = 404) : base(resource, action, controller, status)
        {
            Detail = String.Format("{0}.{1}.The {2} was not founded.", controller, action, resource);
        }

        public NotFoundException(string resource, string action, string controller, Dictionary<string, string[]>? errors, int status = 404) : base(resource, action, controller, errors, status)
        {
        }
    }
}
