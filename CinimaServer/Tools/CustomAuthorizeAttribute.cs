using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;
namespace CinimaServer.Tools
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Kiểm tra token ở đây và thực hiện xác thực
            string token = GetTokenFromHeader(actionContext);
            if (IsValidToken(token))
            {
                //base.OnAuthorization(actionContext); // Xác thực thành công
                //actionContext.RequestContext.Principal = principal;


            }
            else
            {
                HandleUnauthorizedRequest(actionContext); // Xác thực thất bại
            }
        }

        private string GetTokenFromHeader(HttpActionContext actionContext)
        {
            // Lấy token từ header (thay đổi theo cách bạn lưu trữ token)
            var tokenHeader = actionContext.Request.Headers.Authorization;
            if (tokenHeader != null)
            {
                // Trích xuất token từ header
                string token = tokenHeader.Scheme;

                return token; // Trả về token
            }
            return null;
        }

        private bool IsValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyToken.secretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true, // Có thể điều chỉnh dựa trên cấu hình của bạn
                ValidIssuer = KeyToken.issuer, // Thay thế bằng issuer của bạn
                ValidateAudience = true, // Có thể điều chỉnh dựa trên cấu hình của bạn
                ValidAudience = KeyToken.audience, // Thay thế bằng audience của bạn
                ValidateLifetime = true
            };

            try
            {
                SecurityToken validatedToken;
                tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}