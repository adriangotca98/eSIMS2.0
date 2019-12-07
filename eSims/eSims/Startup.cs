using eSims.Models;
using eSims.Services;
using eSIMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace eSims

{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// requires using Microsoft.Extensions.Options
			services.Configure<eSimsDatabaseSettings>(
				Configuration.GetSection(nameof(eSimsDatabaseSettings)));

			services.AddSingleton<IeSimsDatabaseSettings>(sp =>
				sp.GetRequiredService<IOptions<eSimsDatabaseSettings>>().Value);
			services.AddScoped<IProfessorService, ProfessorService>();
			services.AddScoped<IAttendanceService, AttendanceService>();
			services.AddScoped<IGradeService, GradeService>();
			services.AddScoped<ISubjectService, SubjectService>();
			services.AddScoped<IStudentService, StudentService>();
			services.AddControllers()
				.AddNewtonsoftJson(options => options.UseMemberCasing());
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
