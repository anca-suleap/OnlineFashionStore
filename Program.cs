using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineFashionStore.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Products");
    options.Conventions.AllowAnonymousToPage("/Products/Index");
    options.Conventions.AllowAnonymousToPage("/Products/Details");
});

builder.Services.AddDbContext<OnlineFashionStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineFashionStoreContext") ?? throw new InvalidOperationException("Connection string 'OnlineFashionStoreContext' not found.")));

builder.Services.AddDbContext<StoreIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineFashionStoreContext") ?? throw new InvalidOperationException("Connection string 'OnlineFashionStoreContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<StoreIdentityContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
