//using AI_Programming_Assistant.Models;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AiProgrammingAssistantContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// HTTP Client
//builder.Services.AddHttpClient();

//// 🔥 Session
//builder.Services.AddSession();

//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//// 🔥 مهم
//app.UseSession();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=landing_page}/{action=landing_page}/{id?}");

//app.Run();


using AI_Programming_Assistant.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AiProgrammingAssistantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// HTTP Client
builder.Services.AddHttpClient();

builder.Services.AddScoped<AI_Programming_Assistant.Services.ILearningService,
                            AI_Programming_Assistant.Services.LearningService>();
builder.Services.AddHttpClient<AI_Programming_Assistant.Services.IOllamaService,
                               AI_Programming_Assistant.Services.OllamaService>();

// 🔥 Session
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔥 مهم
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=landing_page}/{action=landing_page}/{id?}");

app.Run();