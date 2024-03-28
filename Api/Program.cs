using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
DotNetEnv.Env.Load();

// Add services to the container.
builder.Services.AddInfrastructure(configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLocalization();
builder.Services.AddSingleton(configuration);
builder.Services.AddHttpContextAccessor();


var app = builder.Build();


app.UseInfrastructure();
app.UseAuthentication();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
