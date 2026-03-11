using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MyColabApiProject.Repository;

public class Program
{
    public static void Main(string[] args)
    {

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<PersonDbContext>(
            options =>
                options.UseInMemoryDatabase("PeopleDb"));

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
        });

        builder.Services.AddControllers();
        builder.Services.AddTransient<IPersonRepository, PersonRepository>();


        WebApplication app = builder.Build();

        using (IServiceScope scope = app.Services.CreateScope())
        {
            PersonDbContext personDbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

            personDbContext.Set<Person>().Add(new Person { Id = Guid.NewGuid(), Name = "Jane Doe" });
            personDbContext.Set<Person>().Add(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler" });
            personDbContext.SaveChanges();
        }

        app.MapControllers();

        app.Run();
    }
}