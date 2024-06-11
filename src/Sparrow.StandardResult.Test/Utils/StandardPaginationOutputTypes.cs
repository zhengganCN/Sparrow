using Microsoft.Extensions.DependencyInjection;
using Sparrow.StandardResult.Test.Models;

namespace Sparrow.StandardResult.Test.Utils
{
    internal static class StandardPaginationOutputTypes
    {

        public static StandardPagination<T> GetDefault<T>()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult();
            return new StandardPagination<T>();
        }

        public static DefinedPagination GetOverrideDefault()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDefaultStandardResult(option =>
            {
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
            return new DefinedPagination();
        }
        public static DefinedPagination GetDefined(string key)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddStandardResult(key, option =>
            {
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
            return new DefinedPagination();
        }
    }
}
