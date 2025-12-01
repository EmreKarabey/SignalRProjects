using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SignalRApiProject.Hubs;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();


//SignalR çalýþmasý için yapýlan Cors Politikalarý
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        //Ýstemciden (client) gelen HTTP isteklerinde Content-Type, Authorization vb. her türlü baþlýða (header) izin verilir.
        builder.AllowAnyHeader()

        //GET, POST, PUT, DELETE, PATCH gibi tüm HTTP metotlarýna izin verilir.
        .AllowAnyMethod()

        //Bu kod, gelen Host adresi ne olursa olsun true(doðru) döndürerek dünyadaki tüm kaynaklardan(origin) gelen isteklere kapýyý açar.
        .SetIsOriginAllowed((Host) => true)

        // Tarayýcýnýn sunucuya kimlik bilgileri(Cookies, Authorization headerlarý veya TLS client sertifikalarý) göndermesine izin verir.
        .AllowCredentials();
    });
});

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
