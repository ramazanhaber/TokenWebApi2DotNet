using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;

namespace WebApplication3.Filters
{
    public class AuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Swashbuckle.Swagger.Parameter>();

            //var authorizeAttributes = apiDescription
            //    .ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();

            //if (authorizeAttributes.ToList().Any(attr => attr.GetType() == typeof(AllowAnonymousAttribute)) == false)
            //{
            //    operation.parameters.Add(new Swashbuckle.Swagger.Parameter()
            //    {
            //        name = "Authorization",
            //        @in = "header",
            //        type = "string",
            //        description = "Authorization Token. Please remember the Bearer part",
            //        @default = "Bearer ",
            //        required = true
            //    });

            //}

            var authorizeAttributes = apiDescription
              .ActionDescriptor.GetCustomAttributes<JwtAuthenticationAttribute>();

            if (authorizeAttributes.ToList().Any(attr => attr.GetType() == typeof(JwtAuthenticationAttribute)) == true)
            {
                operation.parameters.Add(new Swashbuckle.Swagger.Parameter()
                {
                    name = "Authorization",
                    @in = "header",
                    type = "string",
                    description = "Authorization Token. Please remember the Bearer part",
                    @default = "Bearer ",
                    required = true
                });
               
            }
        }
    }
}