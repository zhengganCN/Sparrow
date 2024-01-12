using Renci.SshNet;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Sparrow.Database.SqlSugar
{
    public partial class DbContext
    {
        /// <summary>
        /// 连接ssh
        /// </summary>
        private void SshConnect()
        {
            if (builder.SshConfig is null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(builder.SshConfig.SshHost))
            {
                throw new ArgumentNullException(nameof(builder.SshConfig.SshHost));
            }
            int forwardedPort = GetUnActiveTcpPort();
            var loopback = IPAddress.Loopback.ToString();
            ReplaceConnectionString(forwardedPort, loopback);
            var auth = new PasswordAuthenticationMethod(builder.SshConfig.SshUser, builder.SshConfig.SshPassword);
            ConnectionInfo conInfo = new ConnectionInfo(builder.SshConfig.SshHost, (int)builder.SshConfig.SshPort, builder.SshConfig.SshUser, auth);
            sshClient = new SshClient(conInfo);
            var forwarded = new ForwardedPortLocal(loopback, (uint)forwardedPort, builder.SshConfig.DbHost, (uint)builder.SshConfig.DbPort);
            sshClient.Connect();
            if (!sshClient.IsConnected)
            {
                throw new Exception("ssh连接失败");
            }
            sshClient.AddForwardedPort(forwarded);
            forwarded.Start();
        }

        /// <summary>
        /// 替换连接字符串中的ip为本机的回环地址，端口为转发端口
        /// </summary>
        /// <param name="forwardedPort">转发端口</param>
        /// <param name="loopback">本机的回环地</param>
        private void ReplaceConnectionString(int forwardedPort, string loopback)
        {
            var connect = client.CurrentConnectionConfig.ConnectionString;
            var ipRegex = new Regex("(.*)(=)([0-9]*\\.[0-9]*\\.[0-9]*\\.[0-9]*)(.*)");
            connect = ipRegex.Replace(connect, $"$1={loopback}$4");
            var portRegex = new Regex("(.*)(=)([0-9]{4,5})(.*)");
            connect = portRegex.Replace(connect, $"$1={forwardedPort}$4");
            client.CurrentConnectionConfig.ConnectionString = connect;
        }

        /// <summary>
        /// 随机获取未使用的端口
        /// </summary>
        /// <returns></returns>
        private static int GetUnActiveTcpPort()
        {
            var random = new Random();
            var port = random.Next(10000, 65535);
            while (IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(p => p.Port == port))
            {
                port = random.Next(10000, 65535);
            }
            return port;
        }
    }
}
