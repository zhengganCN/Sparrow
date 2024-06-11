using Microsoft.Extensions.DependencyInjection;
using Sparrow.StandardResult.Test.Models;

namespace Sparrow.StandardResult.Test.Utils
{
    internal static class StandardOutputTypes
    {
        public static Standard GetDefault()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult();
            return new Standard();
        }

        public static DefinedStandard GetOverrideDefault()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
                option.FormatStandard = (standard) =>
                {
                    return new DefinedStandard
                    {
                        defined_success = standard.Success,
                        defined_code = standard.Code?.ToString(),
                        defined_data = standard.Data,
                        defined_message = standard.Message,
                        defined_time = standard.Time,
                        defined_traceid = standard.TraceId
                    };
                };
                option.FormatStandardPagination = (pagination) =>
                {
                    return new DefinedPagination
                    {
                        list = pagination.List,
                        page_num = pagination.PageIndex,
                        page_size = pagination.PageSize,
                        total = pagination.Count,
                        page_count = pagination.PageCount,
                    };
                };
            });
            return new DefinedStandard();
        }
        public static DefinedStandard GetDefined(string key)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddStandardResult(key, option =>
            {
                option.FormatStandard = (standard) =>
                {
                    return new DefinedStandard
                    {
                        defined_success = standard.Success,
                        defined_code = standard.Code?.ToString(),
                        defined_data = standard.Data,
                        defined_message = standard.Message,
                        defined_time = standard.Time,
                        defined_traceid = standard.TraceId
                    };
                };
            });
            return new DefinedStandard();
        }
    }
}
