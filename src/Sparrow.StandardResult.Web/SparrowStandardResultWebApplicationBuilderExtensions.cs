using Sparrow.StandardResult.Web;

namespace Microsoft.AspNetCore.Builder
{
    public static class SparrowStandardResultWebApplicationBuilderExtensions
    {
        public static void UseSparrowExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(WebValues.ErrorTemplatePath);
        }

        public static void UseSparrowExceptionHandler(this IApplicationBuilder app, string key)
        {
            WebValues.StardandKey = key;
            app.UseExceptionHandler(WebValues.ErrorTemplatePath);
        }
    }
}
