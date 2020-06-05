using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HardwareMall.Manage
{
    /// <summary>
    /// 身份验证类
    /// </summary>
    public class Jwt : IJwt
    {
        private string _base64Secret;
        private JwtSetting _setting = new JwtSetting();
        private IConfiguration _configuration;
        public Jwt(IConfiguration configration)
        {
            this._configuration = configration;
            configration.GetSection("JwtSettings").Bind(_setting);
            this.GetSecret();
        }

        public Jwt()
        {
        }

        /// <summary>
        /// 获取到加密串
        /// </summary>
        private void GetSecret()
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(_setting.SecretKey);
            byte[] messageBytes = encoding.GetBytes(_setting.SecretKey);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                this._base64Secret = Convert.ToBase64String(hashmessage);
            }
        }
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="Claims"></param>
        /// <returns></returns>
        public string CreateToken(Dictionary<string, string> Claims)
        {
            List<Claim> claimsAll = new List<Claim>();
            foreach (var item in Claims)
            {
                claimsAll.Add(new Claim(item.Key, item.Value ?? ""));
            }
            var symmetricKey = Convert.FromBase64String(this._base64Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _setting.Issuer,
                Audience = _setting.Audience,
                Subject = new ClaimsIdentity(claimsAll),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(_setting.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey),
                                           SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// 验证Token是否有效
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="Clims"></param>
        /// <returns></returns>
        public bool IsToken(string Token, out Dictionary<string, string> Clims)
        {
            Clims = new Dictionary<string, string>();
            ClaimsPrincipal principal = null;
            if (string.IsNullOrWhiteSpace(Token))
            {
                return false;
            }
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwt = handler.ReadJwtToken(Token);

                if (jwt == null)
                {
                    return false;
                }
                var secretBytes = Convert.FromBase64String(this._base64Secret);
                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = _setting.ValidateLifetime,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = _setting.Audience,
                    ValidIssuer = _setting.Issuer
                };
                SecurityToken securityToken;
                principal = handler.ValidateToken(Token, validationParameters, out securityToken);
                foreach (var item in principal.Claims)
                {
                    Clims.Add(item.Type, item.Value);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
