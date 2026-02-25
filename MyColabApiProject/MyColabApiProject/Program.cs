using Microsoft.EntityFrameworkCore;
using MyColabApiProject;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<PersonDbContext>(
            options =>
                options.UseInMemoryDatabase("PeopleDb"));

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
        });

        builder.Services.AddControllers();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            if (!dbContext.Persons.Any())
            {
                dbContext.Persons.Add(new Person { Id = Guid.NewGuid(), Name = "John Doe" });
                dbContext.SaveChanges();
            }
        }

        app.MapControllers();

        app.Run();


    }
}