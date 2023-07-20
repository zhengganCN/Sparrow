using Microsoft.AspNetCore.Builder;

namespace Sparrow.Monitor
{
    public static class SparrowMonitorApplicationExtension
    {
        public static IApplicationBuilder UseSparrowMonitor(this IApplicationBuilder builder)
        {
            return builder;
        }
    }
}
