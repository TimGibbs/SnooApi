using SnooSharp;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var opts = builder.Configuration.GetSection("SnooClientOptions").Get<SnooClientOptions>();
builder.Services.AddTransient(_=>opts);
builder.Services.AddHttpClient<ISnooClient, SnooClient>();
builder.Services.AddSingleton<ISnooClient, SnooClient>();
WebApplication app = builder.Build();

app.MapGet("/data", async (ISnooClient client) => await client.GetDataResponses(DateTime.Now.AddDays(-1), DateTime.Now));

app.Run("http://*:80");