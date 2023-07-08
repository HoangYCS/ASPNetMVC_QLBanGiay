using ASIGNMENT_FPOLY.IServices;
using ASIGNMENT_FPOLY.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IBrandService, BrandService>();
builder.Services.AddTransient<IColorService, ColorService>();
builder.Services.AddTransient<ISizeService, SizeService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<ICartDetailService,CartDetailService>();
builder.Services.AddTransient<IRoleService,RoleService>();
builder.Services.AddMvc();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddHttpContextAccessor();

//builder.Services.AddSingleton<IProductService, ProductService>();
//builder.Services.AddScoped<IProductService, ProductService>();
/*
AddSingleton: sẽ chỉ được tạo 1 lần trong suốt lifetime của ứng dụng phù hợp các service có tính toàn cụ không thay đổi
Scope: Mỗi 1 request sẽ khởi tạo lại service 1 lần. Dùng cho các service có tính đặc thù nào đó
Transient: Được khỏi tạo mỗi khi có yêu cầu, mỗi request sẽ được nhận 1 service khác nhau, và được sử dụng với services có nhiều yêu cầu http
 */

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
