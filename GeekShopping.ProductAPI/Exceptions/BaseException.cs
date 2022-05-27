namespace GeekShopping.ProductAPI.Exceptions
{
    public class BaseException: ApplicationException
    {
        public string Detail { get; private set; }

        public string Action { get; private set; }

        public string Controller { get; private set; }

        public int Status { get; private set; }

        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();

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
