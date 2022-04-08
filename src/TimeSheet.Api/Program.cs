using System.Text;
using Microsoft.VisualStudio.Services.Common;
using TimeSheet.Core.Interfaces.Repositories;
using TimeSheet.Core.Interfaces.Services;
using TimeSheet.Core.Services;
using TimeSheet.Infrastructure.Context;
using TimeSheet.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

RegisterApplicationServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void RegisterApplicationServices(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton(InitializeCosmosDb(builder.Configuration.GetSection("CosmosDb")).GetAwaiter()
        .GetResult());
    builder.Services.AddSingleton(InitializeDevOpsContext(builder.Configuration.GetSection("DevOps")).GetAwaiter()
        .GetResult());

    builder.Services.AddScoped<ITimeSheetEntryService, TimeSheetEntryService>();
    builder.Services.AddScoped<IDevOpsRepository, DevOpsRepository>();
    builder.Services.AddScoped<IWorkItemRepository, WorkItemRepository>();
}

static async Task<WorkItemDbContext> InitializeCosmosDb(IConfigurationSection configurationSection)
{
    var account = configurationSection.GetSection("account").Value;
    var key = configurationSection.GetSection("key").Value;

    return new WorkItemDbContext(account, key);
}

static async Task<DevOpsContext> InitializeDevOpsContext(IConfigurationSection configurationSection)
{
    var defaultUri = configurationSection.GetSection("defaultUri").Value;
    var organization = configurationSection.GetSection("organization").Value;
    var personalAccessToken = configurationSection.GetSection("personalAccessToken").Value;

    var stringBuilder = new StringBuilder();
    stringBuilder.Append(defaultUri);
    stringBuilder.Append(organization);
    stringBuilder.Append("/");

    var uri = new Uri(stringBuilder.ToString());
    var credentials = new VssBasicCredential("", personalAccessToken);

    return new DevOpsContext(uri, credentials);
}