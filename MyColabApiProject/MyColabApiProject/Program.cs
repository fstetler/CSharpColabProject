using Common.CommonBehaviors;
using Microsoft.EntityFrameworkCore;
using MyColabApiProject.Data;
using MyColabApiProject.Repository;
namespace MyColabApiProject
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyColabDbContext>(
                options =>
                    options.UseInMemoryDatabase("PeopleDb"));

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<Program>();
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            builder.Services.AddOpenApi();
            builder.Services.AddControllers();
            builder.Services.AddTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddTransient<IAddressRepository, AddressRepository>();

            WebApplication app = builder.Build();

            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "Mittfinaste api");
                options.EnableTryItOutByDefault();
                options.RoutePrefix = "swagger";
            });


            using (IServiceScope scope = app.Services.CreateScope())
            {
                MyColabDbContext myColabDbContext = scope.ServiceProvider.GetRequiredService<MyColabDbContext>();

                await myColabDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Jane Doe"});
                await myColabDbContext.AddAsync(new Person { Id = Guid.NewGuid(), Name = "Fredrik Stetler"});

                await myColabDbContext.AddAsync(new Address { Id = Guid.NewGuid(), StreetName = "Magasinsgatan", StreetNumber = "9A", PostalCode = "75342", City = "Uppsala" });
                await myColabDbContext.SaveChangesAsync();
            }

            app.MapControllers();

            app.Run();
        }
    } 
}