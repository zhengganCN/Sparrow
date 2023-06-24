using Microsoft.Extensions.Logging;
using System;
using System.Collections.Immutable;

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
                    CheckLoggerFactory();
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
            var categoryName = typeof(T).FullName;
            if (!_loggers.TryGetValue(categoryName, out ILogger logger))
            {
                CheckLoggerFactory();
                logger = LoggerFactory.CreateLogger(categoryName);
                _loggers = _loggers.Add(categoryName, logger);
            }
            return logger;
        }

        /// <summary>
        /// 日志，需要在<see cref="ILoggingBuilder"/>中注册<see cref="LoggingBuilderExtension.AddSparrowLogger"/>
        /// </summary>
        /// <example>
        ///  .ConfigureLogging(loggingBuilder =>
        ///  {
        ///     loggingBuilder.AddSparrowLogger();
        ///  });
        /// </example>
        /// <exception cref="ArgumentNullException"></exception>
        public static ILogger GetLogger(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentNullException(nameof(categoryName));
            }
            if (!_loggers.TryGetValue(categoryName, out ILogger logger))
            {
                CheckLoggerFactory();
                logger = LoggerFactory.CreateLogger(categoryName);
                _loggers = _loggers.Add(categoryName, logger);
            }
            return logger;
        }

        private static void CheckLoggerFactory()
        {
            if (LoggerFactory is null)
            {
                throw new ArgumentNullException(nameof(LoggerFactory));
            }
        }
    }
}
