using GeekShopping.Web.Exceptions;
using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Shared;
using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddDataAnnotationsLocalization(options => {
            options.DataAnnotationLocalizerProvider = (type, factory) =>
                factory.Create(typeof(SharedResources));
        });;

// add a http client
builder.Services.AddHttpClient<IProductService, ProductService>(options =>
{
    options.BaseAddress = new Uri(builder.Configuration["ServiceURLS:ProductAPI"]);
});

// add a translator service
builder.Services.AddScoped<TranslatorService>();

// add a folder as localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
