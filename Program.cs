using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using ODataDemo.Data;
using ODataDemo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));

var odataBuilder = new ODataConventionModelBuilder();
odataBuilder.EntitySet<Product>("Products");
odataBuilder.EntitySet<Category>("Categories");
odataBuilder.EntitySet<Order>("Orders");
odataBuilder.EntitySet<OrderLine>("OrderLines");

builder.Services.AddControllers().AddOData(opt =>
    opt.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
       .AddRouteComponents("api", odataBuilder.GetEdmModel())
);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger()
        .UseSwaggerUI();
}

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

await app.RunAsync();
