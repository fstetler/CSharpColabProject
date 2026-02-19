using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MediatR;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<PersonDbContext>(
            options =>
                options.UseInMemoryDatabase("PeopleDb"));

        builder.Services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblyContaining<Program>());

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();


    }
}