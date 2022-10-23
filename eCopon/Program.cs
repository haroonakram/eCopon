using eCopon.Services.Competitions;
using eCopon.Services.Winners;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ICompetitionServices, CompetitionServices>();
    builder.Services.AddScoped<IWinnerServices, WinnerServices>();
}


var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}