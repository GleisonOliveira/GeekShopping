using GeekShopping.ProductAPI.Exceptions;
using GeekShopping.ProductAPI.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace GeekShopping.ProductAPI.Services
{
    /// <summary>
    /// Translate all messages in current locale
    /// </summary>
    public class TranslatorService
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public TranslatorService(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        /// <summary>
        /// Translate a property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public string? translateProperty(string? property)
        {
            if (property == null)
            {
                return null;
            }

            return _localizer[property];
        }

        /// <summary>
        /// Copnvert an exception into problem details
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public ValidationProblemDetails convertExceptionToProblemDetails(BaseException exception)
        {
            var problemDetails = new ValidationProblemDetails()
            {
                Title = null,
                Detail = translateProperty(exception.Detail),
                Status = exception.Status,
                Type = exception.Action,
                Instance = exception.Controller,
            };

            var errors = translateErrors(exception.Errors);

            foreach (var error in errors)
            {
                problemDetails.Errors.Add(error);
            }

            return problemDetails;
        }

        /// <summary>
        /// Translate all errors in a dictionary of errors
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public IDictionary<string, string[]> translateErrors(IDictionary<string, string[]> errors)
        {
            foreach (var error in errors)
            {
                for (int i = 0; i < error.Value.Length; i++)
                {
                    if (error.Value[i] != null)
                    {
                        error.Value[i] = translateProperty(error.Value[i]) ?? "";
                    }
                }
            }

            return errors;
        }
    }
}
