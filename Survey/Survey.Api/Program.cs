


using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Survey.Api.Repositories;
using Survey.Api.Services;
using Survey.EntityFramework.Contexts;

//using Survey.EntityFramework.Extensions;
using Survey.ServiceDefaults.Models;
using Microsoft.Extensions.Hosting;

var _builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_builder.Services.AddControllers();

_builder.Services.AddHttpClient();

_builder.Services.AddSingleton<IJsonSerializer, JsonSerializer>();
_builder.Services.AddSingleton<IAiAgentService, AiAgentService>();

_builder.Services.AddDbContext<ApplicationContext>();

_builder.Services.AddScoped(typeof(IRepository<AnalysisResultModel>), typeof(AnalysisResultRepository));
_builder.Services.AddScoped(typeof(IRepository<AnswerVariantModel>), typeof(AnswerVariantRepository));
_builder.Services.AddScoped(typeof(IRepository<CompanyModel>), typeof(CompanyRepository));
_builder.Services.AddScoped(typeof(IRepository<MetricModel>), typeof(MetricRepository));
_builder.Services.AddScoped(typeof(IRepository<QueryModel>), typeof(QueryRepository));
_builder.Services.AddScoped(typeof(IRepository<QuestionModel>), typeof(QuestionRepository));
_builder.Services.AddScoped(typeof(ISurveyRepository), typeof(SurveyRepository));
_builder.Services.AddScoped(typeof(IRepository<ContactModel>), typeof(UserRepository));

// Добавление Swagger
_builder.Services.AddEndpointsApiExplorer();
_builder.Services.AddSwaggerGen();

_builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var _app = _builder.Build();

// Включение Swagger только в режиме разработки
if (_app.Environment.IsDevelopment())
{
    _app.UseSwagger();
    _app.UseSwaggerUI();
}

_app.UseHttpsRedirection();

_app.UseCors();

_app.UseAuthorization();

_app.MapControllers();

_app.Run();
