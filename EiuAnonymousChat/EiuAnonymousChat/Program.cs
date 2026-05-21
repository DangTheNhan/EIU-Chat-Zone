using EiuAnonymousChat.Api.Data;
using EiuAnonymousChat.Api.Hubs;
using EiuAnonymousChat.Api.Services;
using Microsoft.EntityFrameworkCore;
using EiuAnonymousChat.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký DbContext kết nối SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Đăng ký SignalR
builder.Services.AddSignalR();

// 3. Đăng ký Background Service chạy ngầm
builder.Services.AddHostedService<MatchmakingWorker>();

// Đăng ký Controllers và Swagger (đã có sẵn)
builder.Services.AddControllers();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<RevealService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbSeeder.Seed(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Lỗi khi đổ dữ liệu: {ex.Message}");
    }
}
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    DbSeeder.Seed(db);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// 4. Map các Endpoints của SignalR
app.MapHub<MatchmakingHub>("/hubs/matchmaking");
app.MapHub<ChatHub>("/hubs/chat");

app.Run();