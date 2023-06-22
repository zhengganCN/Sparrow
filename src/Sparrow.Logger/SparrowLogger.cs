using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sparrow.Logger
{
    /// <summary>
    /// Sparrow日志
    /// </summary>
    public class SparrowLogger
    {
        /// <summary>
        /// 日志工厂
        /// </summary>
        public static ILoggerFactory LoggerFactory { get; internal set; }
        private static ILogger _logger;
        private static ImmutableDictionary<string, ILogger> _loggers = ImmutableDictionary.Create<string, ILogger>();
        /// <summary>
        /// 日志，需要在<see cref="ILoggingBuilder"/>中注册<see cref="LoggingBuilderExtension.AddSparrowLogger"/>
        /// </summary>
        public static ILogger Logger
        {
            get
            {
                if (_logger is null)
                {
                    _logger = LoggerFactory.CreateLogger(nameof(SparrowLogger));
                }
                return _logger;
            }
        }

        /// <summary>
        /// 日志，需要在<see cref="ILoggingBuilder"/>中注册<see cref="LoggingBuilderExtension.AddSparrowLogger"/>
        /// </summary>
        public static ILogger GetLogger<T>() where T : class
        {
            if (!_loggers.TryGetValue(typeof(T).FullName, out ILogger logger))
            {
                var name = typeof(T).FullName;
                logger = LoggerFactory.CreateLogger(name);
                _loggers = _loggers.Add(name, logger);
            }
            return logger;
        }

        /// <summary>
        /// 日志，需要在<see cref="ILoggingBuilder"/>中注册<see cref="LoggingBuilderExtension.AddSparrowLogger"/>
        /// </summary>
        public static ILogger GetLogger(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException(nameof(categoryName));
            }
            if (!_loggers.TryGetValue(categoryName, out ILogger logger))
            {
                logger = LoggerFactory.CreateLogger(categoryName);
                _loggers = _loggers.Add(categoryName, logger);
            }
            return logger;
        }
    }
}
