var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //To enable attribute based routing
    endpoints.MapControllers();
});

app.Run();
