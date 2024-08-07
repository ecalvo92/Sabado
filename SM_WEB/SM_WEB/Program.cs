using SM_WEB.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUsuarioModel, UsuarioModel>();
builder.Services.AddScoped<IComunModel, ComunModel>();
builder.Services.AddScoped<IRolesModel, RolesModel>();
builder.Services.AddScoped<IPerfilModel, PerfilModel>();
builder.Services.AddScoped<IProductoModel, ProductoModel>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();