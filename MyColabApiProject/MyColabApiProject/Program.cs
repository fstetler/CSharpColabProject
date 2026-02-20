using Microsoft.EntityFrameworkCore;
using MyColabApiProject;
using MediatR;

public class Program
{
    public static void Main(string[] args)
    {

        string licenseKey = 
            "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODAzMDgxNjAwIiwiaWF0IjoiMTc3MTU5NTIzNyIsImFjY291bnRfaWQiOiIwMTljN2I0ZGMzNjg3NzljYjEwMmY3NWQ4NWFjYTUyNSIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa2h4bXcyNW5hN21nZms4OXRiYnlkMHpzIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.mgJcNobOPS9J7NfJUheDFZuzj2vbGQQ60zjjZshS74Z9Oqi7gjAxFbUAkG3K5SVRJ8X3Bm-fp-IXkh8eODhr0ejwph1kniRXae6cwfp-ddtNbefJZaW36BpxCGjfPgNPYGAjeUTxIERJ_SiM8ugrcVuEEsQ7gDTfXVau3eYjk_CkLQZZFaW86aX1V7gLmv4LbMwdY0zih9PHfnq2ITgC8Gqhhbs78XuXx6cX6zyPB4zVYRnG0NoOM-R0ZzTZwBcYj_3Hp7r0h7NnovWIP7NGYHGN4OeL9fDtNy-JBpaF_RFEGqGKqdYLjUJSdx2AQ7SMSDczjB4bM6Q_pvuLtRF5aQ";

        var builder = WebApplication.CreateBuilder(args);

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