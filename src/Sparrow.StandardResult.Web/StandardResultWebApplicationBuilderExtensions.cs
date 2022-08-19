using Sparrow.StandardResult.Web;

namespace Microsoft.AspNetCore.Builder
{
    public static class StandardResultWebApplicationBuilderExtensions
    {
        public static void UseStandardExceptionHandler(this IApplicationBuilder app)
        {
            app.UseStandardExceptionHandler(default);
        }

        public static void UseStandardExceptionHandler(this IApplicationBuilder app, string key)
        {
            WebValues.StardandKey = key;
            app.UseExceptionHandler(WebValues.ErrorTemplatePath);
        }
    }
}
