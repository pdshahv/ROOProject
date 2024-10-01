

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));
// common services :carter, mediator, fluent validation
var BooksCatalogAssembly = typeof(BooksCatalogModule).Assembly;
var BorrowAssembly = typeof(Borrowingmodule).Assembly;


builder.Services.AddCarterWithAssembilies(
    typeof(BooksCatalogModule).Assembly,
    typeof(Borrowingmodule).Assembly);
// Add services to the container
builder.Services
    .AddBookCatalogModule(builder.Configuration)
    .AddBorrowingModule(builder.Configuration)
    .AddUserCatalogModule(builder.Configuration);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(BooksCatalogAssembly, BorrowAssembly);
    //config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
builder.Services.AddValidatorsFromAssemblies([BooksCatalogAssembly, BorrowAssembly]);


var app = builder.Build();
// Configure the HTTP request pipeline
app.MapCarter();
// Extension methods
app.
    UseBookCatalogModule()
    .UseUserCatalogModule()
    .UseBorrowingModule();

// global exception handling
    app.UseExceptionHandler(exceptionHandlerApp =>
    {
        exceptionHandlerApp.Run(async context =>
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // using static System.Net.Mime.MediaTypeNames;
            context.Response.ContentType = Text.Plain;

            await context.Response.WriteAsync("An exception was thrown.");

            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
            {
                await context.Response.WriteAsync(" The file was not found.");
            }

            if (exceptionHandlerPathFeature?.Path == "/")
            {
                await context.Response.WriteAsync(" Page: Home.");
            }
        });
    });

app.Run();
