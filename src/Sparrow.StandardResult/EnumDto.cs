using System.ComponentModel;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 枚举类
    /// </summary>
    public class EnumDto
    {
        /// <summary>
        /// 枚举结果
        /// </summary>
        public enum EnumResult
        {
            /// <summary>
            /// 调用失败
            /// </summary>
            [Description("调用失败")]
            Error = -1,
            /// <summary>
            /// 调用成功
            /// </summary>
            [Description("调用成功")]
            Success = 200
        }
        /// <summary>
        /// 枚举授权错误
        /// </summary>
        public enum EnumAuthError
        {
            /// <summary>
            /// 账号或密码验证不通过
            /// </summary>
            [Description("账号或密码验证不通过")]
            LoginFailed = 100001,
            /// <summary>
            /// 权限不足
            /// </summary>
            [Description("权限不足")]
            InsufficientAuthoritys = 100002,
            /// <summary>
            /// 未登录
            /// </summary>
            [Description("未登录")]
            UnLogin = 100003,
            /// <summary>
            /// 无效令牌
            /// </summary>
            [Description("无效令牌")]
            InvalidToken = 100004,
            /// <summary>
            /// 令牌验证不通过
            /// </summary>
            [Description("令牌验证不通过")]
            TokenValidFaild = 100005
        }
        /// <summary>
        /// 数据验证结果提示枚举
        /// </summary>
        public enum EnumModelError
        {
            /// <summary>
            /// 数据验证失败
            /// </summary>
            [Description("数据验证失败")]
            ModelVaildFaild = 101001
        }
        /// <summary>
        /// 数据操作结果枚举
        /// </summary>
        public enum EnumDataOperation
        {
            /// <summary>
            /// 数据添加成功
            /// </summary>
            [Description("数据添加成功")]
            InsertSucceed = 102001,
            /// <summary>
            /// 数据添加失败
            /// </summary>
            [Description("数据添加失败")]
            InsertFaild = 102002,
            /// <summary>
            /// 数据删除成功
            /// </summary>
            [Description("数据删除成功")]
            DeleteSucceed = 102003,
            /// <summary>
            /// 数据删除失败
            /// </summary>
            [Description("数据删除失败")]
            DeleteFaild = 102004,
            /// <summary>
            /// 数据更新成功
            /// </summary>
            [Description("数据更新成功")]
            UpdateSucceed = 102005,
            /// <summary>
            /// 数据更新失败
            /// </summary>
            [Description("数据更新失败")]
            UpdateFaild = 102006,
            /// <summary>
            /// 数据查询成功
            /// </summary>
            [Description("数据查询成功")]
            SelectSucceed = 102007,
            /// <summary>
            /// 数据查询失败
            /// </summary>
            [Description("数据查询失败")]
            SelectFaild = 102008
        }

        /// <summary>
        /// 枚举异常
        /// </summary>
        public enum EnumException
        {
            /// <summary>
            /// 服务异常，请稍后再试
            /// </summary>
            [Description("服务异常，请稍后再试")]
            ServerError = 103000,
            /// <summary>
            /// 服务繁忙，请稍后再试
            /// </summary>
            [Description("服务繁忙，请稍后再试")]
            ServerBusy = 103001
        }
    }
}
