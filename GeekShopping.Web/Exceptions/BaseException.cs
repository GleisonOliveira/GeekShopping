namespace GeekShopping.Web.Exceptions
{
    /// <summary>
    /// Base class to all exceptions
    /// </summary>
    public class BaseException: ApplicationException
    {
        public string Detail { get; protected set; }

        public string Action { get; protected set; }

        public string Controller { get; protected set; }

        public int Status { get; protected set; }

        public IDictionary<string, string[]> Errors { get; protected set; } = new Dictionary<string, string[]>();

        public BaseException(string detail, string action, string controller, int status = 400): base(detail)
        {
            Detail = detail;
            Action = action;
            Controller = controller;
            Status = status;
        }

        public BaseException(
            string detail, 
            string action, 
            string controller,
            Dictionary<string, string[]>? errors,
            int status = 400
        ) : this(detail, action, controller, status)
        {
            if (errors != null)
            {
                Errors = errors;
                return;
            }
            
            Errors = new Dictionary<string, string[]>();
        }
    }
}
