using BlazorCrud_Api.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorCrud_Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddAuthorization();
			builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


			builder.Services.AddCors(options => options.AddPolicy("BlazorYTPolicy", policyBuilder =>
			{
				policyBuilder.WithOrigins("https://localhost:7064");
				policyBuilder.AllowAnyHeader();
                policyBuilder.AllowAnyMethod();

            }));
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseCors("BlazorYTPolicy");
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
