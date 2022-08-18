using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sparrow.StandardResult.WebTest
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
            services.AddDefaultStandardResult(option =>
            {
                option.FormatDto = (dto) =>
                {
                    return new
                    {
                        we_data = dto.Data,
                        we_msg = dto.Message,
                        we_code = dto.Code,
                        we_time = dto.Time,
                        we_traceId = dto.TraceId,
                        we_success = dto.Success,
                    };
                };
            });
            services.AddControllers(options =>
            {
                //options.Filters.Add<HttpResponseExceptionFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseExceptionHandler("/error");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
