using Phoenix.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

{

    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();

    builder.Services.AddMvc();

    builder.Services.AddEntityFrameworkNpgsql()
                    .AddDbContext<PhoenixContext>(options => options.UseNpgsql(@"Host=localhost;Username=amxsistemas;Password=@I19c11m13*/;Database=phoenixc;port=5433"));

    var app = builder.Build();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
