using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Services;
using GeekShopping.ProductAPI.Shared;
using Microsoft.EntityFrameworkCore;
using Hellang.Middleware.ProblemDetails;
using GeekShopping.ProductAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using GeekShopping.ProductAPI.Errors;
using Microsoft.Extensions.Localization;
using GeekShopping.ProductAPI.Config;
using GeekShopping.ProductAPI.Repository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

// add a translator service
builder.Services.AddScoped<TranslatorService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add a db context to database
builder.Services.AddDbContext<MySQLContext>(options => {
    options.UseMySql(connection, new MySqlServerVersion(new Version(10, 4, 21)));
});

// add a automapper
builder.Services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// register the repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// add a folder as localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// configure mvc options and messages to translate
builder.Services.AddMvc(options =>
        {
            var provider = builder.Services.BuildServiceProvider();
            var localizer = provider.GetRequiredService<IStringLocalizer<SharedResources>>();

            options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) =>
                localizer["The value '{0}' is not valid for {1}.", x, y]);

            options.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor((x) =>
                localizer["A value for the '{0}' parameter or property was not provided.", x]);

            options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() =>
                localizer["A value is required."]);

            options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() =>
                localizer["A non-empty request body is required."]);

            options.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) =>
                localizer["The value '{0}' is not valid.", x]);

            options.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() =>
                localizer["The supplied value is invalid."]);

            options.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() =>
                localizer["The field must be a number."]);

            options.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) =>
                localizer["The supplied value is invalid for {0}.", x]);

            options.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) =>
                localizer["The value '{0}' is invalid.", x]);

            options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor((x) =>
                localizer["The field {0} must be a number.", x]);

            options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor((x) =>
                localizer["The value '{0}' is invalid.", x]);

        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.MaxDepth = 0;
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        })
        .ConfigureApiBehaviorOptions(options =>
        {
            // add a translator service and call bad request error to translate the errors
            options.InvalidModelStateResponseFactory = context =>
            {
                var provider = builder.Services.BuildServiceProvider();
                var translator = provider.GetService<TranslatorService>();

                var problems = new BadRequestError(context, translator);

                return new BadRequestObjectResult(problems);
            };
        })
        .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResources));
        });

// add a problem details to catch exceptions
builder.Services.AddProblemDetails(options =>
{
    var provider = builder.Services.BuildServiceProvider();
    var translator = provider.GetService<TranslatorService>();

    // create a map of exceptions and call translator to convert exception in problem details.
    options.IncludeExceptionDetails = (ctx, ex) => builder.Environment.IsDevelopment();
    options.Map<BaseException>(ex => translator.convertExceptionToProblemDetails(ex));
});

var app = builder.Build();

app.UseProblemDetails();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// create a list of supported languages
var supportedCultures = new[] { "pt-BR" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
