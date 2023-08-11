using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Swashbuckle.Application;
namespace CinimaServer.Tools
{
    public class SwaggerConfigModel
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
            {
                // Cấu hình thông tin Swagger
                c.SingleApiVersion("v1", "Your API Title");

                // Cấu hình xác thực token
                c.ApiKey("token")
                    .Description("Bearer token")
                    .Name("Authorization")
                    .In("header");
            })
            .EnableSwaggerUi(c =>
            {
                // Tùy chỉnh giao diện Swagger UI
                c.DocExpansion(DocExpansion.None);

                // Thêm chỗ để điền token
                c.InjectJavaScript(typeof(SwaggerConfig).Assembly, "YourNamespace.SwaggerUI.token-script.js");
            });
        }
    }
}