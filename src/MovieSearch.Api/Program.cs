using MovieSearch.Api.Application.Contracts;
using MovieSearch.Api.Application.Services;
using MovieSearch.Api.Filters;
using MovieSearch.Api.Infrastructure.Database;
using MovieSearch.Api.Infrastructure.Integrations;
using MovieSearch.Api.Shared.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.Configure<ApiKeyOptions>(builder.Configuration.GetSection(ApiKeyOptions.AuthenticationApiKey));
builder.Services.Configure<MovieApiOptions>(builder.Configuration.GetSection(MovieApiOptions.MovieApiSettings));
builder.Services.Configure<MongoOptions>(builder.Configuration.GetSection(MongoOptions.MongoSettings));

builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddScoped<IMovieSearchService, MovieSearchService>();
builder.Services.AddScoped<IMovieApiClientContract, MovieApiClient>();

builder.Services.AddSingleton<IMongoDbConnectionProvider, MongoDbConnectionProvider>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
