using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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
            services.AddStandardResult("weather", option =>
            {
                option.FormatStandard = (dto) =>
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
                option.FormatStandardPagination = (pagination) =>
                {
                    return new
                    {
                        list = pagination.List,
                        pageNum = pagination.PageIndex,
                        pages = pagination.PageCount,
                        pageSize = pagination.PageSize,
                        total = pagination.Count
                    };
                };
            });
            services.AddControllers();
            //.ConfigureApiBehaviorOptions(options =>
            //{
            //    options.InvalidModelStateResponseFactory = StardandResultWeb.StardandResultModelStateResponse;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseStandardExceptionHandler();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
