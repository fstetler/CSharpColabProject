using Common;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MyColabApiProject.Repository;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<CommonDbContext<Person>>(
            options =>
                options.UseInMemoryDatabase("PeopleDb"));

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
        });

        builder.Services.AddControllers();
        builder.Services.AddTransient<IRepository<Person>, PersonRepository>();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<CommonDbContext<Person>>();

            if (!dbContext.GetAll.Any())
            {
                dbContext.GetAll.Add(new Person { Id = Guid.NewGuid(), Name = "John Doe" });
                dbContext.GetAll.Add(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler" });
                dbContext.SaveChanges();
            }
        }

        app.MapControllers();

        app.Run();


    }
}