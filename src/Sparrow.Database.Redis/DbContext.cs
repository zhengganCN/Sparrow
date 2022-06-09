using StackExchange.Redis;
using System;

namespace Sparrow.Database.Redis
{
    /// <summary>
    /// RedisDB上下文
    /// </summary>
    public abstract class DbContext : IDisposable
    {
        private ConnectionMultiplexer _connection;
        private readonly DbContextOptionsBuilder _builder = new DbContextOptionsBuilder();
        private bool disposedValue;
        /// <summary>
        /// RedisDB上下文
        /// </summary>
        protected DbContext()
        {
            OnConfiguring(_builder);
        }

        /// <summary>
        /// Redis客户端
        /// </summary>
        public RedisClient RedisClient(int db = 0)
        {
            var client = new RedisClient(CacheConnection.GetDatabase(db));
            return client;
        }

        /// <summary>
        /// 缓存数据库，数据库连接
        /// </summary>
        private ConnectionMultiplexer CacheConnection
        {
            get
            {
                if (_connection == null || !_connection.IsConnected)
                {
                    _connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_builder.ConfigurationOptions)).Value;
                }
                return _connection;
            }
        }

        /// <summary>
        /// 配置Redis连接参数等
        /// </summary>
        /// <param name="builder"></param>
        protected internal abstract void OnConfiguring(DbContextOptionsBuilder builder);

        /// <summary>
        /// 清理
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // 释放托管状态(托管对象)
                }
                _connection?.Dispose();
                disposedValue = true;
            }
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
