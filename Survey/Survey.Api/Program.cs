


var _builder = WebApplication.CreateBuilder(args);

// Add services to the container.

_builder.Services.AddControllers();


var _app = _builder.Build();



_app.UseHttpsRedirection();

_app.UseAuthorization();

_app.MapControllers();

_app.Run();
