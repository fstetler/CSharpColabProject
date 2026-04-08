using Common.CommonRepository;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MyColabApiProject.Repository;
namespace Program
{
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
            builder.Services.AddTransient<IRepository<Person>, PersonRepository>();
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();

            WebApplication app = builder.Build();


            using (IServiceScope scope = app.Services.CreateScope())
            {
                PersonDbContext personDbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

                personDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Jane Doe" });
                personDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler" });
                personDbContext.SaveChangesAsync();
            }

            app.MapControllers();

            app.Run();
        }
    } 
}