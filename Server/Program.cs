using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketHiveSpaceKittens.Server.Data;
using TicketHiveSpaceKittens.Server.Models;
using TicketHiveSpaceKittens.Server.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var uConnectionString = builder.Configuration.GetConnectionString("UserConnectionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(uConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var tHiveConnectionString = builder.Configuration.GetConnectionString("TicketHiveConnectionString") ?? throw new InvalidOperationException("Connection string 'TicketHiveConnectionString' not found.");
builder.Services.AddDbContext<EventDbContext>(options =>
    options.UseSqlServer(tHiveConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ExtendedUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ExtendedUser, ApplicationDbContext>(options =>
    {
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
    });

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBookingRepo, BookingRepo>();
builder.Services.AddScoped<IEventRepo, EventRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

using (var serviceProvider = builder.Services.BuildServiceProvider())
{
    var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
    var signInManager = serviceProvider.GetRequiredService<SignInManager<ExtendedUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    context.Database.Migrate();

    ExtendedUser adminUser = signInManager.UserManager.FindByNameAsync("admin").GetAwaiter().GetResult();

    if (adminUser == null)
    {
        adminUser = new()
        {
            UserName = "admin"
        };
        signInManager.UserManager.CreateAsync(adminUser, "Password1234!").GetAwaiter().GetResult();
    }

    ExtendedUser user = signInManager.UserManager.FindByNameAsync("user").GetAwaiter().GetResult();

    if (user == null)
    {
        user = new()
        {
            UserName = "user"
        };
        signInManager.UserManager.CreateAsync(user, "Password1234!").GetAwaiter().GetResult();
    }

    IdentityRole? adminRole = roleManager.FindByNameAsync("Admin").GetAwaiter().GetResult();

    if (adminRole == null)
    {
        adminRole = new()
        {
            Name = "Admin"
        };
        signInManager.UserManager.CreateAsync(adminUser, "Admin").GetAwaiter().GetResult();
    }
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
