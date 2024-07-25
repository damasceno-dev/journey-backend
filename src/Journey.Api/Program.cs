using dotenv.net;
using Journey.Api.Filters;

string root = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
string envPath = Path.Combine(root, ".env");
DotEnv.Load(new DotEnvOptions(envFilePaths: new[] { envPath }));

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseCors("AllowAll");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();