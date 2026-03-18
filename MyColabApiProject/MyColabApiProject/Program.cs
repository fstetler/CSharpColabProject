using Common.CommonRepository;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MyColabApiProject.Queries;
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
            cfg.RegisterServicesFromAssemblyContaining<GetAllPersonsQuery>();
            cfg.RegisterServicesFromAssemblyContaining<GetAllPersonsHandler>(); 
            // TODO ADD THESE WHEN MAKING CREATE ABILITY
            //cfg.RegisterServicesFromAssemblyContaining<CreateBaseCommand<object>>(); // scan Common assembly too
            //cfg.RegisterServicesFromAssemblyContaining<CreateBaseHandler<object>>(); // scan Common assembly too
        });

        builder.Services.AddControllers();
        builder.Services.AddTransient<IRepository<Person>, PersonRepository>();
        builder.Services.AddTransient<IPersonRepository, PersonRepository>();

        WebApplication app = builder.Build();

        // rewrite when ability to add person is added
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