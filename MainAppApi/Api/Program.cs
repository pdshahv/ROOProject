
using BookManagement;
using Borrowing;
using UserManagement;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container
builder.Services
    .AddBookManagementModule(builder.Configuration)
    .AddBorrowingModule(builder.Configuration)
    .AddUserManagementModule(builder.Configuration);

var app = builder.Build();
// Configure the HTTP request pipeline
app.Run();
