using BlazingPizza.Data;
using BlazingPizza.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// App services
builder.Services.AddSingleton<PizzaService>(); // Provides pizza data
builder.Services.AddScoped<PizzaSalesState>(); // Tracks pizzas sold
builder.Services.AddHttpClient();
builder.Services.AddScoped<OrderState>();

// Database
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

// Add API support
builder.Services.AddControllers();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Map endpoints
app.MapRazorPages();
app.MapBlazorHub();
app.MapControllers(); // Enables API endpoints
app.MapFallbackToPage("/_Host");

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();