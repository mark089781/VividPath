var builder = WebApplication.CreateBuilder(args);


// Session
builder.Services.AddAuthentication("UserSession")
    .AddCookie("UserSession", options =>
    {
        options.LoginPath = "/Home/LogIn";
        options.AccessDeniedPath = "/Home/Main";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);

        options.SlidingExpiration = false;
        options.Cookie.IsEssential = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.MaxAge = options.ExpireTimeSpan;
    });

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1); // session expires after inactivity
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // POSSIBLE MAY CAUSE ERRORS
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Main}/{id?}")
    .WithStaticAssets();

app.Run();


