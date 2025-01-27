using Project.Bll.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextService();     //DependencyResolvers'tan geldi.
builder.Services.AddIdentityService();      //DependencyResolvers'tan geldi.
builder.Services.AddRepositoryService();    //DependencyResolvers'tan geldi.
builder.Services.AddMapperService();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
