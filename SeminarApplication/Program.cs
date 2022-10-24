using FastEndpoints;
using FastEndpoints.Swagger;
using SeminarApplication.Contracts.Responses;
using SeminarApplication.Database;
using SeminarApplication.Repositories;
using SeminarApplication.Services;
using SeminarApplication.Validation;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200");
        });
});

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.AddSingleton<ISqlConnectionFactory>(_ =>
    new SqlConnectionFactory(config.GetValue<string>("Database:ConnectionString")!));
builder.Services.AddSingleton<Initializer>();

builder.Services.AddSingleton<IParticipantRepository, ParticipantRepository>();
builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
builder.Services.AddSingleton<ISeminarRepository, SeminarRepository>();

builder.Services.AddSingleton<IParticipantService, ParticipantService>();
builder.Services.AddSingleton<ICourseService, CourseService>();
builder.Services.AddSingleton<ISeminarService, SeminarService>();

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.UseCors("CORSPolicy");

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

var databaseInitializer = app.Services.GetRequiredService<Initializer>();
await databaseInitializer.InitializeAsync();

app.Run();