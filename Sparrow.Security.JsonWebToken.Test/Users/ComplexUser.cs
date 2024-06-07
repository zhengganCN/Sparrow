namespace Sparrow.Security.JsonWebToken.Test.Users
{
    public class ComplexUser
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] scope { get; set; }
        /// <summary>
        /// 用户扩展信息
        /// </summary>
        public BaseUserExtra extra { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? exp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string userId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string[] authorities { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string jti { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string client_id { get; set; }
    }
    /// <summary>
    /// 用户扩展信息
    /// </summary>
    public class BaseUserExtra
    {
        /// <summary>
        /// 地区码
        /// </summary>
        public string baseAreaCode { get; set; } = "";
        /// <summary>
        /// 项目id
        /// </summary>
        public long? baseProjectId { get; set; }
        /// <summary>
        /// 总行id
        /// </summary>
        public string baseBankCode { get; set; } = "";
        /// <summary>
        /// 支行id
        /// </summary>
        public string baseBranchBankCode { get; set; } = "";
        /// <summary>
        /// 企业id
        /// </summary>
        public long? baseCorpId { get; set; }
        /// <summary>
        /// 项目分类
        /// </summary>
        public string baseProjectCategory { get; set; }
        /// <summary>
        /// 班组id
        /// </summary>
        public long? baseTeamId { get; set; }
        /// <summary>
        /// 企业角色编码
        /// </summary>
        public string baseRoleCode { get; set; }
    }
}
