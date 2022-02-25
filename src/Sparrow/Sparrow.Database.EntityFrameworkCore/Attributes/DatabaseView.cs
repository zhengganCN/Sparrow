using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Database.EntityFrameworkCore
{
    /// <summary>
    /// 视图特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class DatabaseViewAttribute : Attribute
    {
    }
}
