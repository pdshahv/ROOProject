
var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services
    .AddBookCatalogModule(builder.Configuration)
    .AddBorrowingModule(builder.Configuration)
    .AddUserCatalogModule(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline

app.
    UseBookCatalogModule()
    .UseUserCatalogModule()
    .UseBorrowingModule();
app.Run();
