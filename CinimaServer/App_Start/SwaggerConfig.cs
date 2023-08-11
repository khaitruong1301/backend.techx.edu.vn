using System.Web.Http;
using WebActivatorEx;
using CinimaServer;
using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace CinimaServer
{

    public class AddAuthHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Thêm header xác thực vào yêu cầu API
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "Bearer token",
                required = false, // Hoặc true tùy theo yêu cầu
                type = "string"
            });
        }
    }
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        // Cấu hình thông tin Swagger
                        c.SingleApiVersion("v1", "Your API Title");

                        // Cấu hình xác thực token
                        c.ApiKey("token")
                            .Description("Bearer token")
                            .Name("Authorization")
                            .In("header");
                        c.OperationFilter<AddAuthHeaderOperationFilter>();

                    })
                .EnableSwaggerUi(c =>
                    {
                        // Tùy chỉnh giao diện Swagger UI
                        c.DocExpansion(DocExpansion.List);

                      
                    });
        }
    }
}
