using eCopon.Services.Competitions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<ICompetitionServices, CompetitionServices>();
}


var app = builder.Build();

{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}