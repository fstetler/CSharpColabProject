using Common.CommonRepository;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject.Repository;
using Microsoft.OpenApi;
namespace MyColabApiProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<PersonDbContext>(
                options =>
                    options.UseInMemoryDatabase("PeopleDb"));

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<Program>();
            });

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddTransient<IRepository<Person>, PersonRepository>();
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();

            WebApplication app = builder.Build();

            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Mittfinaste api");
                options.EnableTryItOutByDefault();
                options.RoutePrefix = "swagger"; // optional but recommended
            });


            using (IServiceScope scope = app.Services.CreateScope())
            {
                PersonDbContext personDbContext = scope.ServiceProvider.GetRequiredService<PersonDbContext>();

                await personDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Jane Doe" });
                await personDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler" });
                await personDbContext.SaveChangesAsync();
            }

            app.MapControllers();

            app.Run();
        }
    } 
}