using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MediatR;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        var keyFilePath = Path.Combine(builder.Environment.ContentRootPath, "Resources", "MediatRKey.txt");
        if (!File.Exists(keyFilePath))
        {
            throw new FileNotFoundException($"MediatR license key file not found: {keyFilePath}");
        }

        var licenseKey = File.ReadAllText(keyFilePath).Trim();

        builder.Services.AddDbContext<PersonDbContext>(
            options =>
                options.UseInMemoryDatabase("PeopleDb"));

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<Program>();
            cfg.LicenseKey = licenseKey;
        });

        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();


    }
}