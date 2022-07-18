using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// jwt帮助类
    /// </summary>
    public class JsonWebToken
    {
        private readonly string Issuer;
        private readonly int Expires;
        private readonly byte[] Key;
        private readonly string Audience;
        private readonly List<Claim> Claims = new List<Claim>();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="issuer">签发者</param>
        /// <param name="expires">过期时间间隔</param>
        /// <param name="key">加密密钥</param>
        /// <param name="audience">受众</param>
        public JsonWebToken(string issuer, int expires, byte[] key, string audience)
        {
            Issuer = issuer;
            Expires = expires;
            Key = key;
            Audience = audience;
        }

        /// <summary>
        /// 获取Claim列表
        /// </summary>
        /// <returns></returns>
        public List<Claim> GetClaims()
        {
            return Claims;
        }

        /// <summary>
        /// 设置Claim
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="value">值</param>
        public void SetClaims(string type, string value)
        {
            Claims.Add(new Claim(type, value));
        }

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <returns></returns>
        public string GenerateToken()
        {
            var key = new SymmetricSecurityKey(Key);
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: Claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(Expires),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
