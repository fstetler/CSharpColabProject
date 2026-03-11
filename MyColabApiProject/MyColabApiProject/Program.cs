using Common;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MyColabApiProject.Repository;

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
        builder.Services.AddTransient<IPersonRepository, PersonRepository>();


        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var personDbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            personDbContext.Set<Person>().Add(new Person { Id = Guid.NewGuid(), Name = "Jane Doe" });
            personDbContext.Set<Person>().Add(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler" });
            personDbContext.SaveChanges();
        }

        app.MapControllers();

        app.Run();


    }
}