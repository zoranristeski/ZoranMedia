using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ZoranMedia.Application.Repositories;
using ZoranMedia.Application.Services;
using ZoranMedia.Domain.Entities;
using ZoranMedia.Domain.Interfaces;
using ZoranMedia.Infrastructure;
using ZoranMedia.Infrastructure.Repositories;
using ZoranMedia.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ZoranMediaDataContext>(options =>
                                    options.UseSqlServer(
                                        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ZoranMediaDataContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<IClientService,ClientService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<IConfigurationService, ConfigurationService>();

builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddScoped<ITemplateRepository, TemplateRepository>();
builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();


builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
