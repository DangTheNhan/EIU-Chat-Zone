using EiuAnonymousChat.Api.Data;
using EiuAnonymousChat.Api.Hubs;
using EiuAnonymousChat.Api.Services;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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