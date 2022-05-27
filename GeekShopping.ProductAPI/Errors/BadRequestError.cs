using GeekShopping.ProductAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Errors
{
    public class BadRequestError : ValidationProblemDetails
    {
        private readonly object? _action;

        public BadRequestError(ActionContext context, TranslatorService translator) : base(context.ModelState)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var translatedDetail = translator.translateProperty(Title);

            if(translatedDetail == Detail)
            {
                translatedDetail = translator.translateProperty(string.Format("{0}.{1}.{2}", controller.ToString(), action.ToString(), Title));
            }

            Detail = translatedDetail;
            Status = 400;
            Instance = context.HttpContext.TraceIdentifier;
            this.Type = _action != null ? _action.ToString() : null;
            Title = null;
        }
    }
}
